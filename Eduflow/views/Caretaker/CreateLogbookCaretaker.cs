using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eduflow.views.Caretaker
{
    public partial class CreateLogbookCaretaker : Form
    {
        private Form lastForm;

        public CreateLogbookCaretaker(Form lastForm)
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
            this.Close();
            lastForm.Show();
        }
    }
}
