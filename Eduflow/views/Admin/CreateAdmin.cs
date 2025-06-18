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

namespace Eduflow.views.Admin
{
    public partial class CreateAdmin : Form
    {
        Home lastForm;
        models.Admin admin;

        public CreateAdmin(Home lastForm, models.Admin admin)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.admin = admin;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string userId = Guid.NewGuid().ToString();
                string name = txtNewAdminName.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                string passwordHashed = BCrypt.Net.BCrypt.HashPassword(password);

                UserBd userBd = new UserBd();
                models.User user = userBd.getUser(email);
                if (user != null) {
                    MessageBox.Show("Ja existe um usuario cadastrado com o e-mail fornecido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                models.User newUser = new models.User(userId, email, passwordHashed, utils.enums.UserType.ADMIN);
                userBd.insertUser(newUser);

                string adminId = Guid.NewGuid().ToString();
                AdminBd adminBd = new AdminBd();
                models.Admin newAdmin = new models.Admin(adminId, name, admin.schoolName, userId);
                adminBd.insertAdmin(newAdmin);

                MessageBox.Show("Admin cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao criar um admin. Por favor, tente novamente mais tarde.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
