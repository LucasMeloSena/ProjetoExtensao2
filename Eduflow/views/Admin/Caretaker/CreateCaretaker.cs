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
        private HomeCaretakerAdmin lastForm;

        public CreateCaretaker(HomeCaretakerAdmin lastForm)
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
            string passwordHashed = BCrypt.Net.BCrypt.HashPassword(password);

            if (name == "")
            {
                MessageBox.Show("Campo nome invalido! Por favor, preencha corretamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (registration == "")
            {
                MessageBox.Show("Campo matricula invalido! Por favor, preencha corretamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (email == "")
            {
                MessageBox.Show("Campo email invalido! Por favor, preencha corretamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (password == "")
            {
                MessageBox.Show("Campo senha invalido! Por favor, preencha corretamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = Guid.NewGuid().ToString();

            try
            {
                UserType userType = UserType.CARETAKER;
                string userId = Guid.NewGuid().ToString();
                User user = new User(userId, email, passwordHashed, userType);
                userBd.insertUser(user);

                Eduflow.models.Caretaker caretaker = new Eduflow.models.Caretaker(
                id,
                name,
                registration,
                userId
                );

                CaretakerBd caretakerBd = new CaretakerBd();
                caretakerBd.insertCaretaker(caretaker);

                MessageBox.Show("Cuidador cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lastForm.searchCaretakersAndFillDataGrid();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
