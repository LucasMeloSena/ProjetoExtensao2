using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Eduflow.views.Admin.Student
{
    public partial class StudentForm: Form
    {
        private Form lastForm;

        public StudentForm(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            lastForm.Show();
        }

        private void btnAddCaretaker_Click(object sender, EventArgs e)
        {
            CreateStudent createStudentForm = new CreateStudent(this);
            this.Hide();
            createStudentForm.Show();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            lblName.Text = "Nome: Coordenador Geral";
            lblSchool.Text = "Escola: Escola X";

            dataGridStudent.ColumnCount = 4;
            dataGridStudent.Columns[0].Name = "id";
            dataGridStudent.Columns[0].Visible = false;
            dataGridStudent.Columns[1].Name = "Nome";
            dataGridStudent.Columns[2].Name = "Matricula";
            dataGridStudent.Columns[3].Name = "Responsavel";
                
            DataGridViewColumn actionsColumn = new DataGridViewColumn();
            actionsColumn.Name = "Acoes";
            actionsColumn.HeaderText = "Acoes";
            actionsColumn.CellTemplate = new DataGridViewTextBoxCell();

            string[] row1 = new string[]
            {
                "1",
                "Maria Joana",
                "PNMGF88", 
                "John Doe"
            };

            string[] row2 = new string[]
            {
                "2",
                "Letícia Carvalho",
                "823SBND",
                "John Doe II"
            };

            dataGridStudent.Rows.Add(row1);
            dataGridStudent.Rows.Add(row2);
            dataGridStudent.Columns.Add(actionsColumn);

            dataGridStudent.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridStudent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridStudent.RowTemplate.Height = 60;
            dataGridStudent.RowHeadersVisible = false;
        }

        private void dataGridStudent_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridStudent.Columns["Acoes"].Index && e.RowIndex >= 0)
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

                ButtonRenderer.DrawButton(e.Graphics, editButton, "🖊️", dataGridStudent.Font, false, PushButtonState.Default);
                ButtonRenderer.DrawButton(e.Graphics, deleteButton, "🗑", dataGridStudent.Font, false, PushButtonState.Default);
                ButtonRenderer.DrawButton(e.Graphics, viewButton, "👁", dataGridStudent.Font, false, PushButtonState.Default);

                e.Handled = true;
            }
        }

        private void dataGridStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridStudent.Columns["Acoes"].Index && e.RowIndex >= 0)
            {
                var cellRect = dataGridStudent.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int buttonWidth = 24;
                int spacing = 4;
                int mouseX =
                    dataGridStudent.PointToClient(Cursor.Position).X - cellRect.X;
                string id = dataGridStudent.Rows[e.RowIndex].Cells["id"].Value.ToString();

                if (mouseX < buttonWidth + spacing)
                {
                    UpdateStudent updateStudentForm = new UpdateStudent(this, id);
                    this.Hide();
                    updateStudentForm.Show();
                }
                else if (mouseX < 2 * (buttonWidth + spacing))
                {
                    DialogResult result = MessageBox.Show(
                        $"Tem certeza que deseja excluir o Aluno?",
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
                    ListStudent listStudentForm = new ListStudent(this, id);
                    this.Hide();
                    listStudentForm.Show();
                }
            }
        }
    }
}
