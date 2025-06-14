using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eduflow.models;
using Eduflow.utils.database;
using Eduflow.utils.enums;
using Org.BouncyCastle.Crmf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Eduflow.views.Admin.Caretaker
{
    public partial class CreateCaretaker : Form
    {
        private Form lastForm;

        public CreateCaretaker(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            UserBd userBd = new UserBd();

            string name = txtCaretakerName.Text;
            string registration = txtCaretakerId.Text;

            string email = txtCaretakerEmail.Text;
            string password = txtCaretakerPassword.Text;

            string id = Guid.NewGuid().ToString();



            try
            {
                UserType userType = UserType.CARETAKER;
                User user = new User(null, email, password, userType);
                string idUsuario = userBd.insertUser(user);

                Eduflow.models.Caretaker caretaker = new Eduflow.models.Caretaker(
                id,
                name,
                registration,
                idUsuario
                );

                CaretakerBd caretakerBd = new CaretakerBd();
                caretakerBd.insertCaretaker(caretaker);

                MessageBox.Show("Cuidador cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
