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
using Eduflow.views.Admin.Caretaker;

namespace Eduflow.views.Admin.Group
{
    public partial class HomeGroup : Form
    {
        Home lastForm;
        models.Admin admin;

        public HomeGroup(Home lastForm, models.Admin admin)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.admin = admin;
        }

        private void HomeGroup_Load(object sender, EventArgs e)
        {
            lblName.Text = $"Nome: {admin.name}";
            lblSchool.Text = $"Escola: {admin.schoolName}";

            searchGroupsAndFillDataGrid();
        }

        public void searchGroupsAndFillDataGrid()
        {
            dataGridGroups.Rows.Clear();
            dataGridGroups.CellContentClick += dataGridGroups_CellContentClick;

            GroupBd groupBd = new GroupBd();
            List<models.Group> groups = groupBd.getGroups();

            foreach (var group in groups)
            {
                dataGridGroups.Rows.Add(group.id, group.name, "Editar");
            }

            dataGridGroups.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridGroups.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridGroups.RowTemplate.Height = 60;
            dataGridGroups.RowHeadersVisible = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCaretaker_Click(object sender, EventArgs e)
        {
            CreateGroup createGroupForm = new CreateGroup(this);
            createGroupForm.ShowDialog();
        }

        private void dataGridGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridGroups.Columns[e.ColumnIndex].Name;
            string id = dataGridGroups.Rows[e.RowIndex].Cells["id"].Value.ToString();

            if (columnName == "Editar")
            {
                UpdateGroup updateGroupForm = new UpdateGroup(this, id);
                updateGroupForm.ShowDialog();
            }
        }
    }
}
