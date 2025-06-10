using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eduflow.models;
using Eduflow.utils.database;

namespace Eduflow.views.Admin.Logbook
{
    public partial class UpdateLogbook : Form
    {
        LogbookReport lastForm;
        string logbookId;

        public UpdateLogbook(LogbookReport lastForm, string logbookId)
        {
            this.lastForm = lastForm;
            this.logbookId = logbookId;
            InitializeComponent();
        }

        private void UpdateLogbook_Load(object sender, EventArgs e)
        {
            inputObservationDate.MinDate = DateTime.Now;
            inputObservationDate.Format = DateTimePickerFormat.Custom;
            inputObservationDate.CustomFormat = "dd/MM/yyyy";

            LogbookBd logbookBd = new LogbookBd();
            models.Logbook logbook = logbookBd.getLogbookById(logbookId);

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

            if (logbook.registerDate < inputObservationDate.MinDate)
            {
                inputObservationDate.MinDate = logbook.registerDate.AddDays(-1);
            }
            inputObservationDate.Value = logbook.registerDate;

            txtObservation.Text = logbook.observation;
            cmbObservationType.SelectedValue = logbook.observationTypeId;
            cmbCaretaker.SelectedValue = logbook.caretakerId;
            cmbStudent.SelectedValue = logbook.studentId;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DateTime observationDate = inputObservationDate.Value;
            string observation = txtObservation.Text;
            string observationType = cmbObservationType.SelectedValue.ToString();
            string caretakerId = cmbCaretaker.SelectedValue.ToString();
            string caretakerName = ((models.Caretaker)cmbCaretaker.SelectedItem).name;
            string studentId = cmbStudent.SelectedValue.ToString();
            string studentName = ((models.Student)cmbStudent.SelectedItem).name;

            try
            {
                models.Logbook logbook = new models.Logbook(logbookId, observationDate, observation, observationType, caretakerId, caretakerName, studentId, studentName);
                LogbookBd logbookBd = new LogbookBd();
                logbookBd.updateLogbook(logbook);
                MessageBox.Show("Diario de Bordo atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lastForm.searchLogbooks();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
