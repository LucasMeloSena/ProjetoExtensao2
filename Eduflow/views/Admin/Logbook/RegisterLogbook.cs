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
using Eduflow.utils.enums;

namespace Eduflow.views.Admin.Logbook
{
    public partial class RegisterLogbook: Form
    {
        private LogbookReport lastForm;

        public RegisterLogbook(LogbookReport lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void CreateObservationLogbook_Load(object sender, EventArgs e)
        {
            inputObservationDate.Value = DateTime.Now;
            inputObservationDate.MinDate = DateTime.Now;
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

            CaretakerBd caretakerBd = new CaretakerBd();
            List<models.Caretaker> caretakers = caretakerBd.getCaretakers();
            cmbCaretaker.DataSource = caretakers;
            cmbCaretaker.DisplayMember = "name";
            cmbCaretaker.ValueMember = "id";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string id = Guid.NewGuid().ToString();
            DateTime observationDate = DateTime.Parse(inputObservationDate.Text);
            string observation = txtObservation.Text;
            string observationType = cmbObservationType.SelectedValue.ToString();
            string caretakerName = cmbCaretaker.SelectedText;
            string caretakerId = cmbCaretaker.SelectedValue.ToString();
            string studentId = cmbStudent.SelectedValue.ToString();
            string studentName = cmbStudent.SelectedItem.ToString();

            try
            {
                models.Logbook logbook = new models.Logbook(id, observationDate, observation, observationType, caretakerId, caretakerName, studentId, studentName);
                LogbookBd logbookBd = new LogbookBd();
                logbookBd.insertLogbook(logbook);
                MessageBox.Show("Diario de bordo cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lastForm.searchLogbooks();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
