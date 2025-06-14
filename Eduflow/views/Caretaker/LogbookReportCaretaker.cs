using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eduflow.models;
using Eduflow.utils.database;
using Eduflow.views.Admin.Logbook;

namespace Eduflow.views.Caretaker
{
    public partial class LogbookReportCaretaker : Form
    {
        private Form lastForm;
        private models.Caretaker caretaker;
        private string studentId;
        LogbookBd logbookBd = new LogbookBd();

        public LogbookReportCaretaker(Form lastForm, models.Caretaker caretaker, string studentId)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.caretaker = caretaker;
            this.studentId = studentId;
        }

        private void LogbookCaretaker_Load(object sender, EventArgs e)
        {
            StudentBd studentBd = new StudentBd();
            models.Student student = studentBd.getStudent(studentId);

            lblName.Text = $"Nome: {caretaker.name}";
            lblSchool.Text = $"Matricula: {caretaker.registration}";
            lblStudentName.Text = student.name;

            searchLogbooks();
        }

        public void searchLogbooks()
        {
            List<models.Logbook> logbooks = logbookBd.getLogbooksByStudent(studentId);

            dataGridLogbookReport.Rows.Clear();

            foreach (var logbook in logbooks)
            {
                dataGridLogbookReport.Rows.Add(logbook.id, logbook.registerDate.ToString("dd/MM/yyyy"), logbook.observation);
            }

            dataGridLogbookReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridLogbookReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridLogbookReport.RowTemplate.Height = 60;
            dataGridLogbookReport.RowHeadersVisible = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            RegisterLogbookCaretaker createLogbook = new RegisterLogbookCaretaker(this);
            createLogbook.ShowDialog();
        }
    }
}
