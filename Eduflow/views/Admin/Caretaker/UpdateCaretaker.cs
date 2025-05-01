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
            lastForm.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }
    }
}
