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
        private Form lastForm;
        private List<Group> groups;

        public CreateStudent(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void CreateStudent_Load(object sender, EventArgs e)
        {
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
            lastForm.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string name = txtStudentName.Text;
            string registration = txtStudentId.Text;
            int age = int.Parse(txtStudentAge.Text);
            string bornDateStr = inputBornDate.Text;
            string registerDateStr = inputRegisterDate.Text;
            string restrictions = txtStudentRestrictions.Text;
            string genreStr = cmbGenre.Text;
            string disabilities = txtStudentDisabilities.Text;
            string groupId = cmbGroup.SelectedValue.ToString();

            Genre genre = (Genre)Enum.Parse(typeof(Genre), genreStr, true);
            DateTime bornDate = DateTime.Parse(bornDateStr);
            DateTime registerDate = DateTime.Parse(registerDateStr);

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
                this.Close();
                lastForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
