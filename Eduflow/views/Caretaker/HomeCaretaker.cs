using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eduflow.views.Admin.Student;
using System.Windows.Forms.VisualStyles;
using Eduflow.views.Caretaker;

namespace Eduflow.views
{
    public partial class HomeCaretaker : Form
    {
        private Form lastForm;

        public HomeCaretaker(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            lastForm.Show();
        }

        private void HomeCaretaker_Load(object sender, EventArgs e)
        {
            lblName.Text = "Nome: Cuidador X";
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

                Rectangle viewButton = new Rectangle(
                    e.CellBounds.Left + spacing,
                    e.CellBounds.Top + spacing,
                    buttonWidth,
                    e.CellBounds.Height - 2 * spacing);

                Rectangle logbookButton = new Rectangle(
                    viewButton.Right + spacing,
                    e.CellBounds.Top + spacing,
                    buttonWidth,
                    e.CellBounds.Height - 2 * spacing);

                ButtonRenderer.DrawButton(e.Graphics, viewButton, "👁", dataGridStudent.Font, false, PushButtonState.Default);
                ButtonRenderer.DrawButton(e.Graphics, logbookButton, "📕", dataGridStudent.Font, false, PushButtonState.Default);

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
                int mouseX = dataGridStudent.PointToClient(Cursor.Position).X - cellRect.X;
                string id = dataGridStudent.Rows[e.RowIndex].Cells["id"].Value.ToString();

                if (mouseX < buttonWidth + spacing)
                {
                    ListStudentCaretaker listStudentForm = new ListStudentCaretaker(this, id);
                    this.Hide();
                    listStudentForm.Show();
                }
                else if (mouseX < 2 * (buttonWidth + spacing))
                {
                    LogbookCaretaker logbookForm = new LogbookCaretaker(this);
                    this.Hide();
                    logbookForm.Show();
                }
            }
        }
    }
}
