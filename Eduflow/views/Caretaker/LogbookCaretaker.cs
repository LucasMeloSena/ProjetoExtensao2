using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eduflow.views.Admin.Logbook;

namespace Eduflow.views.Caretaker
{
    public partial class LogbookCaretaker : Form
    {
        private Form lastForm;

        public LogbookCaretaker(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void LogbookCaretaker_Load(object sender, EventArgs e)
        {
            lblName.Text = "Nome: Cuidador X";
            lblSchool.Text = "Escola: Escola X";

            dataGridLogbookReportReport.ColumnCount = 5;
            dataGridLogbookReportReport.Columns[0].Name = "id";
            dataGridLogbookReportReport.Columns[0].Visible = false;
            dataGridLogbookReportReport.Columns[1].Name = "Data da Observacao";
            dataGridLogbookReportReport.Columns[2].Name = "Observacao";
            dataGridLogbookReportReport.Columns[3].Name = "Cuidador Responsavel";
            dataGridLogbookReportReport.Columns[4].Name = "Situacao";

            string[] row1 = new string[]
            {
                "1",
                "04/08/2024",
                "Prezados pais/responsáveis gostaria de informar que a o lanche do Daniel acabou caindo no chão e decidimos não deixar ele comer o que havia caído no chão. Fizemos para ele um misto quente mas aparentemente ele não gostou ...",
                "Alice Neves",
                "Visto"
            };

            string[] row2 = new string[]
            {
                "2",
                "16/10/2024",
                "Prezados país/responsáveis, hoje o Daniel acabou passando mal durante a aula de educação física. Ele reclamou de dor no estômago e um pouco de falta de ar, ele voltou para a areá de descanso e dormiu até 15:30 e comeu um pouco dep...",
                "Alice Neves",
                "Visto"
            };

            dataGridLogbookReportReport.Rows.Add(row1);
            dataGridLogbookReportReport.Rows.Add(row2);

            dataGridLogbookReportReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridLogbookReportReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridLogbookReportReport.RowTemplate.Height = 60;
            dataGridLogbookReportReport.RowHeadersVisible = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CreateLogbookCaretaker createLogbook = new CreateLogbookCaretaker(this);
           
            createLogbook.ShowDialog();
        }
    }
}
