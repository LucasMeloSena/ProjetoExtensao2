using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Eduflow.models;
using Eduflow.utils.database;

namespace Eduflow.views.Admin.Student
{
    public partial class StudentForm: Form
    {
        private Form lastForm;
        private Eduflow.models.Admin admin;

        public StudentForm(Form lastForm, models.Admin admin)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.admin = admin;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            lastForm.Show();
        }

        private void btnAddCaretaker_Click(object sender, EventArgs e)
        {
            CreateStudent createStudentForm = new CreateStudent(this);
            this.Hide();
            createStudentForm.Show();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            lblName.Text = $"Nome: {admin.name}";
            lblSchool.Text = $"Escola: {admin.schoolName}";

            dataGridStudent.Rows.Clear();
            dataGridStudent.CellContentClick += dataGridStudent_CellContentClick;

            StudentBd studentBd = new StudentBd();
            List<models.Student> students = studentBd.getStudents();

            foreach (var student in students)
            {
                dataGridStudent.Rows.Add(student.id, student.name, student.registration, student.age, "Expandir", "Editar");
            }

            dataGridStudent.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridStudent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridStudent.RowTemplate.Height = 60;
            dataGridStudent.RowHeadersVisible = false;
        }

        private void dataGridStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridStudent.Columns[e.ColumnIndex].Name;
            var id = dataGridStudent.Rows[e.RowIndex].Cells["id"].Value;

            if (columnName == "Expandir")
            {
                ListStudent listStudentForm = new ListStudent(this, id.ToString());
                this.Hide();
                listStudentForm.Show();
            }
            else if (columnName == "Editar")
            {
                UpdateStudent updateStudentForm = new UpdateStudent(this, id.ToString());
                this.Hide();
                updateStudentForm.Show();
            }
        }


    }
}
