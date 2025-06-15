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
using Eduflow.utils.enums;

namespace Eduflow.views.Admin.Student
{
    public partial class CreateStudent: Form
    {
        private StudentForm lastForm;
        private List<models.Group> groups;

        public CreateStudent(StudentForm lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void CreateStudent_Load(object sender, EventArgs e)
        {
            inputBornDate.Format = DateTimePickerFormat.Custom;
            inputBornDate.CustomFormat = "dd/MM/yyyy";

            inputRegisterDate.Format = DateTimePickerFormat.Custom;
            inputRegisterDate.CustomFormat = "dd/MM/yyyy";

            GroupBd groupBd = new GroupBd();
            this.groups = groupBd.getGroups();
            cmbGroup.DataSource = this.groups;
            cmbGroup.DisplayMember = "name";
            cmbGroup.ValueMember = "id";
            string[] genres = { Genre.Masculino.ToString(), Genre.Feminino.ToString() };
            cmbGenre.Items.AddRange(genres);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string name = txtStudentName.Text;
            string registration = txtStudentId.Text;
            int age = int.Parse(txtStudentAge.Text);
            DateTime bornDate = inputBornDate.Value;
            DateTime registerDate = inputRegisterDate.Value;
            string restrictions = txtStudentRestrictions.Text;
            string genreStr = cmbGenre.Text;
            string disabilities = txtStudentDisabilities.Text;
            string groupId = cmbGroup.SelectedValue.ToString();

            Genre genre = (Genre)Enum.Parse(typeof(Genre), genreStr, true);

            models.Student student = new models.Student(
                Guid.NewGuid().ToString(),
                name,
                age,
                genre,
                disabilities,
                restrictions,
                registration,
                bornDate,
                registerDate,
                groupId
            );

            try
            {
                StudentBd studentBd = new StudentBd();
                studentBd.insertStudent(student);
                MessageBox.Show("Aluno cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lastForm.searchStudentsAndFillDataGrid();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
