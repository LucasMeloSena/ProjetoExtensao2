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

namespace Eduflow.views.Admin.LogbookType
{
    public partial class UpdateLogbookType : Form
    {
        HomeLogbookType lastForm;
        string categoryId;
        LogbookTypeBd logbookTypeBd = new LogbookTypeBd();

        public UpdateLogbookType(HomeLogbookType lastForm, string categoryId)
        {
            InitializeComponent();
            this.lastForm = lastForm;
            this.categoryId = categoryId;
        }

        private void searchLogbookType(string logbookTypeId)
        {
            models.LogbookType logbookType = logbookTypeBd.getLogbookType(logbookTypeId);


            if (logbookType == null)
            {
                MessageBox.Show("Categoria de observação não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtCategoryName.Text = logbookType.name;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;

            models.LogbookType logbookTypeToUpdate = new models.LogbookType(
                categoryId,
                name
            );

            if (name == "")
            {
                MessageBox.Show("Campo nome invalido! Por favor, preencha corretamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                logbookTypeBd.updateLogbookType(logbookTypeToUpdate);
                MessageBox.Show("Categoria Diario atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lastForm.searchCategoriesAndFillDataGrid();
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

        private void UpdateLogbookType_Load(object sender, EventArgs e)
        {
            searchLogbookType(categoryId);
        }
    }
}
