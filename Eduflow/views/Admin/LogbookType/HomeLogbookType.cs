using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eduflow.utils.database;
using Eduflow.views.Admin.Group;

namespace Eduflow.views.Admin.LogbookType
{
    public partial class HomeLogbookType : Form
    {
        Home lastForm;
        models.Admin admin;

        public HomeLogbookType(Home lastForm, models.Admin admin)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.admin = admin;
        }

        private void HomeLogbookType_Load(object sender, EventArgs e)
        {
            lblName.Text = $"Nome: {admin.name}";
            lblSchool.Text = $"Escola: {admin.schoolName}";

            searchCategoriesAndFillDataGrid();
        }

        public void searchCategoriesAndFillDataGrid()
        {
            dataGridCategories.Rows.Clear();
            dataGridCategories.CellContentClick += dataGridGroups_CellContentClick;

            LogbookTypeBd logbookTypeBd = new LogbookTypeBd();
            List<models.LogbookType> logbookTypes = logbookTypeBd.getLogbookTypes();

            foreach (var logbookType in logbookTypes)
            {
                dataGridCategories.Rows.Add(logbookType.id, logbookType.name, "Editar");
            }

            dataGridCategories.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridCategories.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridCategories.RowTemplate.Height = 60;
            dataGridCategories.RowHeadersVisible = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCaretaker_Click(object sender, EventArgs e)
        {
            CreateLogbookType createLogbookType = new CreateLogbookType(this);
            createLogbookType.ShowDialog();
        }

        private void dataGridGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridCategories.Columns[e.ColumnIndex].Name;
            string id = dataGridCategories.Rows[e.RowIndex].Cells["id"].Value.ToString();

            if (columnName == "Editar")
            {
                UpdateLogbookType updateLogbookType = new UpdateLogbookType(this, id);
                updateLogbookType.ShowDialog();
            }
        }
    }
}
