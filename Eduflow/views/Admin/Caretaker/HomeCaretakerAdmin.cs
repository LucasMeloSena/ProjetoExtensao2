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
            lastForm.Show();
        }

        private void btnAddCaretaker_Click(object sender, EventArgs e)
        {
            CreateCaretaker createCaretakerForm = new CreateCaretaker(this);
            this.Hide();
            createCaretakerForm.Show();
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
                UpdateCaretaker updateCaretakerForm = new UpdateCaretaker(this, id.ToString());
                updateCaretakerForm.Show();
            }
        }
    }
}
