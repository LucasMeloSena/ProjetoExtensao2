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

namespace Eduflow.views.Admin.Student
{
    public partial class ListStudent: Form
    {
        private Form lastForm;
        private string studentId;

        public ListStudent(Form lastForm, string studentId)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.studentId = studentId;
        }

        private void ListStudent_Load(object sender, EventArgs e)
        {
            searchStudent(studentId);
        }

        private void searchStudent(string studentId)
        {
            StudentBd studentBd = new StudentBd();
            GroupBd groupBd = new GroupBd();
            models.Student student = studentBd.getStudent(studentId);
            models.Group group = groupBd.getGroup(student.classId);

            txtStudentName.Text = student.name;
            txtRegistration.Text = student.registration;
            txtAge.Text = student.age.ToString();
            txtRestrictions.Text = student.restrictions;
            txtBornDate.Text = student.bornDate.ToString("dd/MM/yyyy");
            txtRegistrationDate.Text = student.registrationDate.ToString("dd/MM/yyyy");
            txtGenre.Text = student.genre.ToString();
            txtDisabilities.Text = student.disabilities.ToString();
            txtGroup.Text = group.name;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
