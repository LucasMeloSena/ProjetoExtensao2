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
    public partial class CreateLogbookType : Form
    {
        HomeLogbookType lastForm;

        public CreateLogbookType(HomeLogbookType lastForm)
        {
            InitializeComponent();
            this.lastForm = lastForm;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            LogbookTypeBd logbookTypeBd = new LogbookTypeBd();

            string name = txtCategoryName.Text;
            string id = Guid.NewGuid().ToString();

            try
            {
                models.LogbookType logbookType = new models.LogbookType(
                    id,
                    name
                );

                logbookTypeBd.insertLogbookType(logbookType);
                MessageBox.Show("Categoria Diario cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lastForm.searchCategoriesAndFillDataGrid();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateLogbookType_Load(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
