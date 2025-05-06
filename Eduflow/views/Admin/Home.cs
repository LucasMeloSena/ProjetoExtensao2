using Eduflow.models;
using Eduflow.views.Admin.Logbook;
using Eduflow.views.Admin.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Eduflow.views
{
    public partial class Home : Form
    {
        private Form lastForm;

        public Home(Form lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            lblName.Text = "Nome: Coordenador Geral";
            lblSchool.Text = "Escola: Escola X";

            dataGridLastInfo.ColumnCount = 3;
            dataGridLastInfo.Columns[0].Name = "Data";
            dataGridLastInfo.Columns[1].Name = "Cuidador";
            dataGridLastInfo.Columns[2].Name = "Observação";

            string[] row1 = new string[] {
                "25/03/2043",
                "Valdirene Mendes",
                "Relato de incidente em sala de aula. Olá Srs Pais/Responsáveis. Gostaria de informar..."
            };

            string[] row2 = new string[] {
                "11/01/2043",
                "Valdirene Mendes",
                "Olá Srs Pais/Responsáveis, feliz ano novo! O Gabriel irá voltar essa semana?"
            };

            dataGridLastInfo.Rows.Add(row1);
            dataGridLastInfo.Rows.Add(row2);

            dataGridLastInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridLastInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridLastInfo.RowTemplate.Height = 60;
            dataGridLastInfo.RowHeadersVisible = false;
        }

        private void btnCaretakers_Click(object sender, EventArgs e)
        {
            Caretaker caretakerHomeForm = new Caretaker(this);
            caretakerHomeForm.Show();
            this.Hide();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm(this);
            studentForm.Show();
            this.Hide();
        }

        private void btnLogboox_Click(object sender, EventArgs e)
        {
            LogbookForm logbookForm = new LogbookForm(this);
            logbookForm.Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            lastForm.Show();
        }
    }
}
