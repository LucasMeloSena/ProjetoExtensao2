using Eduflow.utils.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Eduflow.views.Admin.Caretaker
{
    public partial class UpdateCaretaker : Form
    {
        private Form lastForm;
        private string caretakerId;

        public UpdateCaretaker(Form lastForm, string caretakerId)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.caretakerId = caretakerId;
            
            
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string name = txtNewCaretakerName.Text;
            string registration = txtNewCaretakerId.Text;

            CaretakerBd caretakerBd = new CaretakerBd();
            models.Caretaker existingCaretaker = caretakerBd.getCaretakerById(caretakerId);

            if (existingCaretaker == null)
            {
                MessageBox.Show("Não foi possível localizar o cuidador existente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            models.Caretaker updatedCaretaker = new models.Caretaker(
                caretakerId,
                name,
                registration,
                existingCaretaker.userId
            );

            try
            {
                caretakerBd.updateCaretaker(updatedCaretaker);
                MessageBox.Show("Cuidador atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                lastForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o cuidador: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void searchCaretaker(string caretakerId)
        {
            CaretakerBd caretakerBd = new CaretakerBd();
            models.Caretaker caretaker = caretakerBd.getCaretakerById(caretakerId);


            if (caretaker == null)
            {
                MessageBox.Show("Cuidador não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtNewCaretakerName.Text = caretaker.name;
            txtNewCaretakerId.Text = caretaker.registration;
        }

        private void UpdateCaretaker_Load(object sender, EventArgs e)
        {
            searchCaretaker(caretakerId);
        }
    }
}
