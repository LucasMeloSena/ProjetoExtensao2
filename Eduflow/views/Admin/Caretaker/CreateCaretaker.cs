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
            lastForm.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }
    }
}
