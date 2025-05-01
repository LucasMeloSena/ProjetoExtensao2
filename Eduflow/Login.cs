using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eduflow.utils.enums;
using Eduflow.views;

namespace Eduflow
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string password = txtPassword.Text;

            if (user == null || user == "" || password == null || password == "")
            {
                MessageBox.Show("Usuario ou Senha invalidos!", "Informacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                UserType userType = UserType.Admin;

                if (userType == UserType.Admin)
                {
                    Home adminHomeForm = new Home(this);
                    this.Hide();
                    adminHomeForm.Show();
                } else if (userType == UserType.Caretaker)
                {
                    
                } else
                {
                    MessageBox.Show("Ocorreu um erro no sistema! Por favor, tente novamente mais tarde", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
