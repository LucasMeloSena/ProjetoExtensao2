using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eduflow.utils.database;
using Eduflow.views.Admin.Student;

namespace Eduflow.views.Admin.Logbook
{
    public partial class LogbookReport: Form
    {
        private Form lastForm;
        private models.Admin admin;
        private string studentId;
        LogbookBd logbookBd = new LogbookBd();
        public LogbookReport(Form lastForm, models.Admin admin, string studentId)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.admin = admin;
            this.studentId = studentId;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogbookReport_Load(object sender, EventArgs e)
        {
            StudentBd studentBd = new StudentBd();
            models.Student student = studentBd.getStudent(studentId);

            lblName.Text = $"Nome: {admin.name}";
            lblSchool.Text = $"Escola: {admin.schoolName}";
            lblStudentName.Text = student.name;

            searchLogbooks();
        }

        public void searchLogbooks()
        {
            List<models.Logbook> logbooks = logbookBd.getLogbooksByStudent(studentId);

            dataGridLogbookReport.Rows.Clear();
            dataGridLogbookReport.CellContentClick += dataGridLogbookReport_CellContentClick;

            foreach (var logbook in logbooks)
            {
                dataGridLogbookReport.Rows.Add(logbook.id, logbook.registerDate.ToString("dd/MM/yyyy"), logbook.observation, logbook.caretakerName, "Editar", "Excluir");
            }

            dataGridLogbookReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridLogbookReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridLogbookReport.RowTemplate.Height = 60;
            dataGridLogbookReport.RowHeadersVisible = false;
        }

        private void dataGridLogbookReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridLogbookReport.Columns[e.ColumnIndex].Name;
            var id = dataGridLogbookReport.Rows[e.RowIndex].Cells["id"].Value;

            if (columnName == "Editar")
            {
                UpdateLogbook updateLogbook = new UpdateLogbook(this, id.ToString());
                updateLogbook.ShowDialog();
            }
            else if (columnName == "Excluir")
            {
                DialogResult result = MessageBox.Show(
                    "Tem certeza que deseja deletar este item?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    logbookBd.deleteLogbook(id.ToString());
                    MessageBox.Show("Diario de Bordo excluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    searchLogbooks();
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            RegisterLogbook createObservationLogbook = new RegisterLogbook(this);
            createObservationLogbook.ShowDialog();
        }
    }
}
