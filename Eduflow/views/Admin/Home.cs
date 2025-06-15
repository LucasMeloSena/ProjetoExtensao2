using Eduflow.models;
using Eduflow.utils.database;
using Eduflow.views.Admin.Logbook;
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

namespace Eduflow.views
{
    public partial class Home : Form
    {
        private Form lastForm;
        private Eduflow.models.Admin admin;

        public Home(Form lastForm, models.Admin admin)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.admin = admin;
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            lblName.Text = $"Nome: {admin.name}";
            lblSchool.Text = $"Escola: {admin.schoolName}";

            LogbookBd logbookBd = new LogbookBd();
            List<models.Logbook> logbooks = logbookBd.getLastLogbooksRegistered();

            dataGridLogbookReport.Rows.Clear();

            foreach (var logbook in logbooks)
            {
                dataGridLogbookReport.Rows.Add(logbook.id, logbook.registerDate.ToString("dd/MM/yyyy"), logbook.observation, logbook.studentName, logbook.caretakerName);
            }

            dataGridLogbookReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridLogbookReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridLogbookReport.RowTemplate.Height = 60;
            dataGridLogbookReport.RowHeadersVisible = false;
        }

        private void btnCaretakers_Click(object sender, EventArgs e)
        {
            HomeCaretakerAdmin caretakerHomeForm = new HomeCaretakerAdmin(this, admin);
            caretakerHomeForm.ShowDialog();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm(this, admin);
            studentForm.ShowDialog();
        }

        private void btnLogboox_Click(object sender, EventArgs e)
        {
            LogbookForm logbookForm = new LogbookForm(this, admin);
            logbookForm.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {

        }

        private void btnCategory_Click(object sender, EventArgs e)
        {

        }
    }
}
