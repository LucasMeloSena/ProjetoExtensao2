namespace Eduflow.views
{
    partial class HomeCaretakerAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSchool = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnAddCaretaker = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridCaretakers = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expandir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCaretakers)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSchool);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(172, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(300, 210);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // lblSchool
            // 
            this.lblSchool.AutoSize = true;
            this.lblSchool.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchool.Location = new System.Drawing.Point(73, 181);
            this.lblSchool.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(0, 15);
            this.lblSchool.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(73, 155);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 15);
            this.lblName.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Eduflow.Properties.Resources.profile;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(92, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(528, 16);
            this.btnSair.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(136, 27);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Voltar";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnAddCaretaker
            // 
            this.btnAddCaretaker.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCaretaker.Location = new System.Drawing.Point(528, 45);
            this.btnAddCaretaker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddCaretaker.Name = "btnAddCaretaker";
            this.btnAddCaretaker.Size = new System.Drawing.Size(136, 27);
            this.btnAddCaretaker.TabIndex = 6;
            this.btnAddCaretaker.Text = "Adicionar Cuidador";
            this.btnAddCaretaker.UseVisualStyleBackColor = true;
            this.btnAddCaretaker.Click += new System.EventHandler(this.btnAddCaretaker_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 300);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(678, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Listagem Cuidadores Cadastrados";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridCaretakers
            // 
            this.dataGridCaretakers.AllowUserToAddRows = false;
            this.dataGridCaretakers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCaretakers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridCaretakers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridCaretakers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCaretakers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Matricula,
            this.Nome,
            this.Expandir,
            this.Editar});
            this.dataGridCaretakers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridCaretakers.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridCaretakers.Location = new System.Drawing.Point(0, 330);
            this.dataGridCaretakers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridCaretakers.Name = "dataGridCaretakers";
            this.dataGridCaretakers.ReadOnly = true;
            this.dataGridCaretakers.RowHeadersWidth = 82;
            this.dataGridCaretakers.RowTemplate.Height = 33;
            this.dataGridCaretakers.Size = new System.Drawing.Size(678, 193);
            this.dataGridCaretakers.TabIndex = 9;
            this.dataGridCaretakers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCaretakers_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Matricula
            // 
            this.Matricula.HeaderText = "Matricula";
            this.Matricula.Name = "Matricula";
            this.Matricula.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Expandir
            // 
            this.Expandir.HeaderText = "Ação 1";
            this.Expandir.Name = "Expandir";
            this.Expandir.ReadOnly = true;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "Ação 2";
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // HomeCaretakerAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 523);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridCaretakers);
            this.Controls.Add(this.btnAddCaretaker);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HomeCaretakerAdmin";
            this.Text = "Admin - Cuidador";
            this.Load += new System.EventHandler(this.Caretaker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCaretakers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnAddCaretaker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridCaretakers;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewButtonColumn Expandir;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
    }
}