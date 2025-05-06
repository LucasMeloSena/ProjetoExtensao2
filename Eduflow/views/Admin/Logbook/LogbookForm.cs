using Eduflow.views.Admin.Student;
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

namespace Eduflow.views.Admin.Logbook
{
    public partial class LogbookForm: Form
    {
        private Form lastForm;

        public LogbookForm(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            lastForm.Show();
        }

        private void LogbookForm_Load(object sender, EventArgs e)
        {
            lblName.Text = "Nome: Coordenador Geral";
            lblSchool.Text = "Escola: Escola X";

            dataGridLogbook.ColumnCount = 4;
            dataGridLogbook.Columns[0].Name = "id";
            dataGridLogbook.Columns[0].Visible = false;
            dataGridLogbook.Columns[1].Name = "Nome";
            dataGridLogbook.Columns[2].Name = "Matricula";
            dataGridLogbook.Columns[3].Name = "Nome do Responsavel";

            DataGridViewColumn actionsColumn = new DataGridViewColumn();
            actionsColumn.Name = "Acoes";
            actionsColumn.HeaderText = "Acoes";
            actionsColumn.CellTemplate = new DataGridViewTextBoxCell();

            string[] row1 = new string[]
            {
                "1",
                "Daniel Molo",
                "A88UW32",
                "Aline Maria"
            };

            string[] row2 = new string[]
            {
                "2",
                "Maria Joana",
                "PNMGF88",
                "João Lucas"
            };

            string[] row3 = new string[]
            {
                "3",
                "Letícia Carvalho",
                "823SBND",
                "Pedro Alves"
            };

            dataGridLogbook.Rows.Add(row1);
            dataGridLogbook.Rows.Add(row2);
            dataGridLogbook.Rows.Add(row3);
            dataGridLogbook.Columns.Add(actionsColumn);
            dataGridLogbook.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridLogbook.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridLogbook.RowTemplate.Height = 60;
            dataGridLogbook.RowHeadersVisible = false;
        }

        private void dataGridLogbook_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridLogbook.Columns["Acoes"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                int buttonWidth = 24;
                int spacing = 4;

                Rectangle report = new Rectangle(
                    e.CellBounds.Left + spacing,
                    e.CellBounds.Top + spacing,
                    buttonWidth,
                    e.CellBounds.Height - 2 * spacing);

                ButtonRenderer.DrawButton(e.Graphics, report, "📝", dataGridLogbook.Font, false, PushButtonState.Default);

                e.Handled = true;
            }
        }

        private void dataGridLogbook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridLogbook.Columns["Acoes"].Index && e.RowIndex >= 0)
            {
                var cellRect = dataGridLogbook.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int buttonWidth = 24;
                int spacing = 4;
                int mouseX =
                    dataGridLogbook.PointToClient(Cursor.Position).X - cellRect.X;
                string id = dataGridLogbook.Rows[e.RowIndex].Cells["id"].Value.ToString();

                if (mouseX < buttonWidth + spacing)
                {
                    LogbookReport logbookReportForm = new LogbookReport(this);
                    this.Hide();
                    logbookReportForm.Show();
                }
            }
        }
    }
}
