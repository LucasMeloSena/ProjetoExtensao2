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
using Eduflow.utils.database;

namespace Eduflow.views.Admin.Group
{
    public partial class UpdateGroup : Form
    {
        HomeGroup lastForm;
        string groupId;
        GroupBd groupBd = new GroupBd();

        public UpdateGroup(HomeGroup lastForm, string groupId)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.groupId = groupId;
        }

        private void UpdateGroup_Load(object sender, EventArgs e)
        {
            searchGroup(groupId);
        }

        private void searchGroup(string groupId)
        {
            models.Group group = groupBd.getGroup(groupId);


            if (group == null)
            {
                MessageBox.Show("Turma não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtGroupName.Text = group.name;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string name = txtGroupName.Text;

            models.Group groupToUpdate = new models.Group(
                groupId,
                name
            );

            if (name == "")
            {
                MessageBox.Show("Campo nome invalido! Por favor, preencha corretamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                groupBd.updateGroup(groupToUpdate);
                MessageBox.Show("Turma atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lastForm.searchGroupsAndFillDataGrid();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar a turma: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
