using Eduflow.models;
using Eduflow.utils.database;
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
        private Eduflow.models.Admin admin;

        public LogbookForm(Form lastForm, models.Admin admin)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.admin = admin;
        }

        private void LogbookForm_Load(object sender, EventArgs e)
        {
            lblName.Text = $"Nome: {admin.name}";
            lblSchool.Text = $"Escola: {admin.schoolName}";

            searchStudentsAndFillDataGrid();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void searchStudentsAndFillDataGrid()
        {
            dataGridLogbookReport.Rows.Clear();
            dataGridLogbookReport.CellContentClick += dataGridLogbookReport_CellContentClick;

            StudentBd studentBd = new StudentBd();
            List<models.Student> students = studentBd.getStudents();

            foreach (var student in students)
            {
                dataGridLogbookReport.Rows.Add(student.id, student.name, student.registration, student.age, "Visualizar Diario");
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

            if (columnName == "SeeDiary")
            {
                LogbookReport logbookReportForm = new LogbookReport(this, admin, id.ToString());
                logbookReportForm.ShowDialog();
            }
        }
    }
}
