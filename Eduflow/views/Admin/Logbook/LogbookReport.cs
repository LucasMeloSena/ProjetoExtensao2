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
            LogbookBd logbookBd = new LogbookBd();
            List<models.Logbook> logbooks = logbookBd.getLogbooksByStudent(studentId);

            dataGridLogbookReport.Rows.Clear();

            foreach (var logbook in logbooks)
            {
                dataGridLogbookReport.Rows.Add(logbook.id, logbook.registerDate.ToString("d"), logbook.observation, logbook.caretakerName, "Editar", "Excluir");
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
                
            }
            else if (columnName == "Excluir")
            {
               
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            RegisterLogbook createObservationLogbook = new RegisterLogbook(this);
            createObservationLogbook.ShowDialog();
        }
    }
}
