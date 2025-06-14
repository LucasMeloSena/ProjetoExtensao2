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
using Eduflow.models;
using Eduflow.utils.database;
using Eduflow.views.Admin.Logbook;

namespace Eduflow.views
{
    public partial class HomeCaretaker : Form
    {
        private Form lastForm;
        private models.Caretaker caretaker;

        public HomeCaretaker(Form lastForm, models.Caretaker caretaker)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.caretaker = caretaker;
        }

        private void HomeCaretaker_Load(object sender, EventArgs e)
        {
            lblName.Text = $"Nome: {caretaker.name}";
            lblRegistration.Text = $"Matricula: {caretaker.registration}";

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
                dataGridLogbookReport.Rows.Add(student.id, student.name, student.registration, student.age, "Expandir", "Visualizar Diario");
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
            string id = dataGridLogbookReport.Rows[e.RowIndex].Cells["id"].Value.ToString();

            if (columnName == "Expand")
            {
                ListStudentCaretaker listStudentCaretaker = new ListStudentCaretaker(this, id);
                listStudentCaretaker.ShowDialog();
            }
            else if (columnName == "SeeDiary")
            {
                LogbookReportCaretaker logbookReportCaretaker = new LogbookReportCaretaker(this, caretaker, id);
                logbookReportCaretaker.ShowDialog();
            }
        }
    }
}
