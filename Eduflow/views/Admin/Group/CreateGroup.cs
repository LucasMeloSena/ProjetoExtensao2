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

namespace Eduflow.views.Admin.Group
{
    public partial class CreateGroup : Form
    {
        HomeGroup lastForm;

        public CreateGroup(HomeGroup lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            GroupBd groupBd = new GroupBd();

            string name = txtGroupName.Text;
            string id = Guid.NewGuid().ToString();

            try
            {
                models.Group group = new models.Group(
                    id,
                    name
                );

                groupBd.insertGroup(group);
                MessageBox.Show("Turma cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lastForm.searchGroupsAndFillDataGrid();
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
