using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eduflow.models;
using Eduflow.utils.database;

namespace Eduflow.views.Caretaker
{
    public partial class RegisterLogbookCaretaker : Form
    {
        private LogbookReportCaretaker lastForm;
        private string caretakerId;

        public RegisterLogbookCaretaker(LogbookReportCaretaker lastForm, string caretakerId)
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
            string id = Guid.NewGuid().ToString();
            DateTime observationDate = inputObservationDate.Value;
            string observation = txtObservation.Text;
            string observationType = cmbObservationType.SelectedValue.ToString();
            string studentId = cmbStudent.SelectedValue.ToString();
            string studentName = ((models.Student)cmbStudent.SelectedItem).name;

            models.Logbook logbook = new models.Logbook(id, observationDate, observation, observationType, caretakerId, null, studentId, studentName);
            string emptyField = logbook.searchEmptyFields();
            if (emptyField != null)
            {
                MessageBox.Show($"Campo {emptyField} invalido. Por favor, preencha corretamente.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LogbookBd logbookBd = new LogbookBd();
                logbookBd.insertLogbook(logbook);
                MessageBox.Show("Diario de Bordo cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lastForm.searchLogbooks();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterLogbookCaretaker_Load(object sender, EventArgs e)
        {
            inputObservationDate.MaxDate = DateTime.Now;
            inputObservationDate.Value = DateTime.Now;
            inputObservationDate.Format = DateTimePickerFormat.Custom;
            inputObservationDate.CustomFormat = "dd/MM/yyyy";

            LogbookTypeBd logbookTypeBd = new LogbookTypeBd();
            List<LogbookType> logbookTypes = logbookTypeBd.getLogbookTypes();
            cmbObservationType.DataSource = logbookTypes;
            cmbObservationType.DisplayMember = "name";
            cmbObservationType.ValueMember = "id";

            StudentBd studentBd = new StudentBd();
            List<models.Student> students = studentBd.getStudents();
            cmbStudent.DataSource = students;
            cmbStudent.DisplayMember = "name";
            cmbStudent.ValueMember = "id";
        }
    }
}
