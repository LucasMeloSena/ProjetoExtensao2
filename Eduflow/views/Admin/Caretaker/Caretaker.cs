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
using Eduflow.views.Admin.Caretaker;

namespace Eduflow.views
{
    public partial class Caretaker : Form
    {
        private Form lastForm;

        public Caretaker(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void Caretaker_Load(object sender, EventArgs e)
        {
            lblName.Text = "Nome: Coordenador Geral";
            lblSchool.Text = "Escola: Escola X";
            
            dataGridCa.ColumnCount = 3;
            dataGridCa.Columns[0].Name = "id";
            dataGridCa.Columns[0].Visible = false;
            dataGridCa.Columns[1].Name = "Nome";
            dataGridCa.Columns[2].Name = "Matricula";

            DataGridViewColumn actionsColumn = new DataGridViewColumn();
            actionsColumn.Name = "Acoes";
            actionsColumn.HeaderText = "Acoes";
            actionsColumn.CellTemplate = new DataGridViewTextBoxCell();

            string[] row1 = new string[] {
                "1",
                "John Doe",
                "1234"
            };

            string[] row2 = new string[] {
                "2",
                "John Doe II",
                "4321"
            };

            dataGridCa.Rows.Add(row1);
            dataGridCa.Rows.Add(row2);
            dataGridCa.Columns.Add(actionsColumn);

            dataGridCa.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridCa.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridCa.RowTemplate.Height = 60;
            dataGridCa.RowHeadersVisible = false;
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

        private void dataGridCaretakers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridCa.Columns["Acoes"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                int buttonWidth = 24;
                int spacing = 4;

                Rectangle editButton = new Rectangle(
                    e.CellBounds.Left + spacing,
                    e.CellBounds.Top + spacing,
                    buttonWidth,
                    e.CellBounds.Height - 2 * spacing);

                Rectangle deleteButton = new Rectangle(
                    editButton.Right + spacing,
                    e.CellBounds.Top + spacing,
                    buttonWidth,
                    e.CellBounds.Height - 2 * spacing);

                Rectangle viewButton = new Rectangle(
                    deleteButton.Right + spacing,
                    e.CellBounds.Top + spacing,
                    buttonWidth,
                    e.CellBounds.Height - 2 * spacing);

                ButtonRenderer.DrawButton(e.Graphics, editButton, "🖊️", dataGridCa.Font, false, PushButtonState.Default);
                ButtonRenderer.DrawButton(e.Graphics, deleteButton, "🗑", dataGridCa.Font, false, PushButtonState.Default);
                ButtonRenderer.DrawButton(e.Graphics, viewButton, "👁", dataGridCa.Font, false, PushButtonState.Default);

                e.Handled = true;
            }
        }

        private void dataGridCaretakers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridCa.Columns["Acoes"].Index && e.RowIndex >= 0)
            {
                var cellRect = dataGridCa.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int buttonWidth = 24;
                int spacing = 4;
                int mouseX = dataGridCa.PointToClient(Cursor.Position).X - cellRect.X;
                string id = dataGridCa.Rows[e.RowIndex].Cells["id"].Value.ToString();

                if (mouseX < buttonWidth + spacing)
                {
                    UpdateCaretaker updateCaretakerForm = new UpdateCaretaker(this, id);
                    this.Hide();
                    updateCaretakerForm.Show();
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
                    this.Hide();
                    listCaretakerForm.Show();
                }
            }
        }
    }
}
