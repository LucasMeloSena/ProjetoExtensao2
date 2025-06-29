﻿using Eduflow.utils.database;
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
        private HomeCaretakerAdmin lastForm;
        private string caretakerId;

        CaretakerBd caretakerBd = new CaretakerBd();
        UserBd userBd = new UserBd();

        public UpdateCaretaker(HomeCaretakerAdmin lastForm, string caretakerId)
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
            string email = txtCaretakerEmail.Text;
            string password = txtCaretakerPassword.Text;

            if (password == "")
            {
                MessageBox.Show("O preenchimento da senha é obrigatorio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

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
            models.User userToUpdate = new models.User(existingCaretaker.userId, email, hashedPassword, utils.enums.UserType.CARETAKER);

            if (name == "")
            {
                MessageBox.Show("Campo nome invalido! Por favor, preencha corretamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (registration == "")
            {
                MessageBox.Show("Campo matricula invalido! Por favor, preencha corretamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                caretakerBd.updateCaretaker(updatedCaretaker);
                userBd.updateUser(userToUpdate);
                MessageBox.Show("Cuidador atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                lastForm.searchCaretakersAndFillDataGrid();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o cuidador: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void searchCaretaker(string caretakerId)
        {
            models.Caretaker caretaker = caretakerBd.getCaretakerById(caretakerId);
            models.User user = userBd.getUserById(caretaker.userId);

            if (caretaker == null)
            {
                MessageBox.Show("Cuidador não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtNewCaretakerName.Text = caretaker.name;
            txtNewCaretakerId.Text = caretaker.registration;
            txtCaretakerEmail.Text = user.email;
        }

        private void UpdateCaretaker_Load(object sender, EventArgs e)
        {
            searchCaretaker(caretakerId);
        }
    }
}
