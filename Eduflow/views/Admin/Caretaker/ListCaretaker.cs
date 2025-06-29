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

namespace Eduflow.views.Admin.Caretaker
{
    public partial class ListCaretaker : Form
    {
        private Form lastForm;
        private string caretakerId;

        public ListCaretaker(Form lastForm, string caretakerId)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.caretakerId = caretakerId;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListCaretaker_Load(object sender, EventArgs e)
        {
            searchCaretaker(caretakerId);
        }

        private void searchCaretaker(string caretakerId)
        {
            try
            {
                CaretakerBd caretakerBd = new CaretakerBd();
                models.Caretaker caretaker = caretakerBd.getCaretakerFlexible(caretakerId);
                UserBd userBd = new UserBd();

                txtCaretakerName.Text = caretaker.name;
                txtCaretakerRegistration.Text = caretaker.registration;
            }
            catch (Exception)
            {
                MessageBox.Show("Caretaker not found");
            }
        }

    }
}
