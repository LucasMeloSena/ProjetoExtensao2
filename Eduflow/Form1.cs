using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eduflow
{
    public partial class Form1 : Form
    {
        public Form1()
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
                
            }
        }
    }
}
