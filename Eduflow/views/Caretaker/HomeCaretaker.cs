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
        }

        private void HomeCaretaker_Load(object sender, EventArgs e)
        {
            lblName.Text = "Nome: Cuidador X";
            lblSchool.Text = "Escola: Escola X";

            dataGridLogbookReport.ColumnCount = 4;
            dataGridLogbookReport.Columns[0].Name = "id";
            dataGridLogbookReport.Columns[0].Visible = false;
            dataGridLogbookReport.Columns[1].Name = "Nome";
            dataGridLogbookReport.Columns[2].Name = "Matricula";
            dataGridLogbookReport.Columns[3].Name = "Responsavel";
                
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

            dataGridLogbookReport.Rows.Add(row1);
            dataGridLogbookReport.Rows.Add(row2);
            dataGridLogbookReport.Columns.Add(actionsColumn);
            dataGridLogbookReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridLogbookReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridLogbookReport.RowTemplate.Height = 60;
            dataGridLogbookReport.RowHeadersVisible = false;
        }

        private void dataGridLogbookReport_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridLogbookReport.Columns["Acoes"].Index && e.RowIndex >= 0)
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

                ButtonRenderer.DrawButton(e.Graphics, viewButton, "👁", dataGridLogbookReport.Font, false, PushButtonState.Default);
                ButtonRenderer.DrawButton(e.Graphics, logbookButton, "📕", dataGridLogbookReport.Font, false, PushButtonState.Default);

                e.Handled = true;
            }
        }

        private void dataGridLogbookReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridLogbookReport.Columns["Acoes"].Index && e.RowIndex >= 0)
            {
                var cellRect = dataGridLogbookReport.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int buttonWidth = 24;
                int spacing = 4;
                int mouseX = dataGridLogbookReport.PointToClient(Cursor.Position).X - cellRect.X;
                string id = dataGridLogbookReport.Rows[e.RowIndex].Cells["id"].Value.ToString();

                if (mouseX < buttonWidth + spacing)
                {
                    ListStudentCaretaker listStudentForm = new ListStudentCaretaker(this, id);
                   
                    listStudentForm.ShowDialog();
                }
                else if (mouseX < 2 * (buttonWidth + spacing))
                {
                    LogbookCaretaker logbookForm = new LogbookCaretaker(this);
                   
                    logbookForm.ShowDialog();
                }
            }
        }
    }
}
