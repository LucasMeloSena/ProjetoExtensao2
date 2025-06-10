using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eduflow.views
{
    public partial class ListStudentCaretaker : Form
    {
        private Form lastForm;
        private string studentId;

        public ListStudentCaretaker(Form lastForm, string studentId)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.studentId = studentId;
        }

        private void ListStudentCaretaker_Load(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
