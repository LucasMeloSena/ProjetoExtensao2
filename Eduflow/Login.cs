﻿using System;
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
            string email = txtUser.Text;
            string password = txtPassword.Text;

            if (email == null || email == "" || password == null || password == "")
            {
                MessageBox.Show("Usuario ou Senha invalidos!", "Informacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else
            {
                try
                {
                    UserBd userBd = new UserBd();
                    User user = userBd.getUser(email);
                    if (user == null)
                    {
                        MessageBox.Show("Usuario ou Senha invalidos!", "Informacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.password);
                    if (!isPasswordValid) {
                        MessageBox.Show("Usuario ou Senha invalidos!", "Informacao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    LoginLog loginLog = new LoginLog(Guid.NewGuid().ToString(), DateTime.Now, user.id);
                    userBd.insertIntoLogs(loginLog);

                    if (user.type == UserType.ADMIN)
                    {
                        AdminBd adminBd = new AdminBd();
                        Admin admin = adminBd.getAdmin(user.id);
                        Home adminHomeForm = new Home(this, admin);
                       
                        adminHomeForm.ShowDialog();
                    }
                    else if (user.type == UserType.CARETAKER)
                    {
                        CaretakerBd caretakerBd = new CaretakerBd();
                        Caretaker caretaker = caretakerBd.getCaretaker(user.id);
                        HomeCaretaker caretakerStudent = new HomeCaretaker(this, caretaker);
                       
                        caretakerStudent.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tipo de usuario invalido! Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
