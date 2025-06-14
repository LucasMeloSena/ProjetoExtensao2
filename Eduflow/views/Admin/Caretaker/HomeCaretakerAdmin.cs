using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Eduflow.models;
using Eduflow.utils.database;
using Eduflow.views.Admin.Caretaker;

namespace Eduflow.views
{
    public partial class HomeCaretakerAdmin : Form
    {
        private Form lastForm;
        private Eduflow.models.Admin admin;

        public HomeCaretakerAdmin(Form lastForm, Eduflow.models.Admin admin)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.admin = admin;
        }

        private void Caretaker_Load(object sender, EventArgs e)
        {
            lblName.Text = $"Nome: {admin.name}";
            lblSchool.Text = $"Escola: {admin.schoolName}";

            searchCaretakersAndFillDataGrid();
        }

        public void searchCaretakersAndFillDataGrid()
        {
            dataGridCaretakers.Rows.Clear();

            CaretakerBd caretakerBd = new CaretakerBd();
            List<models.Caretaker> caretakers = caretakerBd.getCaretakers();
            
            foreach (var caretaker in caretakers)
            {
                dataGridCaretakers.Rows.Add(caretaker.id, caretaker.name, caretaker.registration, "Expandir", "Editar");
            }

            dataGridCaretakers.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridCaretakers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridCaretakers.RowTemplate.Height = 60;
            dataGridCaretakers.RowHeadersVisible = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCaretaker_Click(object sender, EventArgs e)
        {
            CreateCaretaker createCaretakerForm = new CreateCaretaker(this);
           
            createCaretakerForm.ShowDialog();
        }

        private void dataGridCaretakers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridCaretakers.Columns[e.ColumnIndex].Name;
            var id = dataGridCaretakers.Rows[e.RowIndex].Cells["id"].Value;

            if (columnName == "Expandir")
            {
                ListCaretaker listCaretakerForm = new ListCaretaker(this, id.ToString());
                listCaretakerForm.Show();
            }
            else if (columnName == "Editar")
            {
                var cellRect = dataGridCaretakers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int buttonWidth = 24;
                int spacing = 4;
                int mouseX = dataGridCaretakers.PointToClient(Cursor.Position).X - cellRect.X;
                string id = dataGridCaretakers.Rows[e.RowIndex].Cells["id"].Value.ToString();

                if (mouseX < buttonWidth + spacing)
                {
                    UpdateCaretaker updateCaretakerForm = new UpdateCaretaker(this, id);
                   
                    updateCaretakerForm.ShowDialog();
                }
                else if (mouseX < 2 * (buttonWidth + spacing))
                {
                    DialogResult result = MessageBox.Show(
                        $"Tem certeza que deseja excluir o cuidador?",
                        "Confirmação de Exclusão",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {

                    }
                }
                else if (mouseX < 3 * (buttonWidth + spacing))
                {
                    ListCaretaker listCaretakerForm = new ListCaretaker(this, id);
                   
                    listCaretakerForm.ShowDialog();
                }
            }
        }
    }
}
