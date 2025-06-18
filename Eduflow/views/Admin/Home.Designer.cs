namespace Eduflow.views
{
    partial class Home
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
            this.btnCaretakers = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnLogboox = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSchool = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridLogbookReport = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegistrationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aluno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caretaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGroup = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogbookReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCaretakers
            // 
            this.btnCaretakers.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaretakers.Location = new System.Drawing.Point(39, 46);
            this.btnCaretakers.Name = "btnCaretakers";
            this.btnCaretakers.Size = new System.Drawing.Size(303, 107);
            this.btnCaretakers.TabIndex = 0;
            this.btnCaretakers.Text = "Gerenciamento de Cuidadores";
            this.btnCaretakers.UseVisualStyleBackColor = true;
            this.btnCaretakers.Click += new System.EventHandler(this.btnCaretakers_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudents.Location = new System.Drawing.Point(39, 168);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(303, 107);
            this.btnStudents.TabIndex = 1;
            this.btnStudents.Text = "Gerenciamento de Alunos";
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnLogboox
            // 
            this.btnLogboox.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogboox.Location = new System.Drawing.Point(39, 303);
            this.btnLogboox.Name = "btnLogboox";
            this.btnLogboox.Size = new System.Drawing.Size(303, 107);
            this.btnLogboox.TabIndex = 2;
            this.btnLogboox.Text = "Gerenciamento Diario de Bordo";
            this.btnLogboox.UseVisualStyleBackColor = true;
            this.btnLogboox.Click += new System.EventHandler(this.btnLogboox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSchool);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(489, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 403);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblSchool
            // 
            this.lblSchool.AutoSize = true;
            this.lblSchool.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchool.Location = new System.Drawing.Point(146, 349);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(0, 27);
            this.lblSchool.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(146, 299);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 27);
            this.lblName.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Eduflow.Properties.Resources.profile;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(184, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(1225, 12);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(119, 51);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(-43, -88);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 79);
            this.listBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-12, 566);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1356, 35);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ultimas Observacoes Diarias";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridLogbookReport
            // 
            this.dataGridLogbookReport.AllowUserToAddRows = false;
            this.dataGridLogbookReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridLogbookReport.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridLogbookReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridLogbookReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLogbookReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.RegistrationDate,
            this.Observation,
            this.Aluno,
            this.Caretaker});
            this.dataGridLogbookReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridLogbookReport.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridLogbookReport.Location = new System.Drawing.Point(0, 635);
            this.dataGridLogbookReport.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridLogbookReport.Name = "dataGridLogbookReport";
            this.dataGridLogbookReport.ReadOnly = true;
            this.dataGridLogbookReport.RowHeadersWidth = 82;
            this.dataGridLogbookReport.RowTemplate.Height = 33;
            this.dataGridLogbookReport.Size = new System.Drawing.Size(1370, 371);
            this.dataGridLogbookReport.TabIndex = 17;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 10;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // RegistrationDate
            // 
            this.RegistrationDate.HeaderText = "Data de Registro";
            this.RegistrationDate.MinimumWidth = 10;
            this.RegistrationDate.Name = "RegistrationDate";
            this.RegistrationDate.ReadOnly = true;
            // 
            // Observation
            // 
            this.Observation.HeaderText = "Observação";
            this.Observation.MinimumWidth = 10;
            this.Observation.Name = "Observation";
            this.Observation.ReadOnly = true;
            // 
            // Aluno
            // 
            this.Aluno.HeaderText = "Aluno";
            this.Aluno.MinimumWidth = 10;
            this.Aluno.Name = "Aluno";
            this.Aluno.ReadOnly = true;
            // 
            // Caretaker
            // 
            this.Caretaker.HeaderText = "Cuidador";
            this.Caretaker.MinimumWidth = 10;
            this.Caretaker.Name = "Caretaker";
            this.Caretaker.ReadOnly = true;
            // 
            // btnGroup
            // 
            this.btnGroup.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroup.Location = new System.Drawing.Point(39, 440);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(303, 107);
            this.btnGroup.TabIndex = 18;
            this.btnGroup.Text = "Gerenciamento de Turmas";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.Location = new System.Drawing.Point(1023, 456);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(303, 107);
            this.btnCategory.TabIndex = 19;
            this.btnCategory.Text = "Gerenciamento Categorias Diario";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1119, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 107);
            this.button1.TabIndex = 20;
            this.button1.Text = "Criar Administrador";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 1006);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.dataGridLogbookReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLogboox);
            this.Controls.Add(this.btnStudents);
            this.Controls.Add(this.btnCaretakers);
            this.Name = "Home";
            this.Text = "Admin - Home";
            this.Load += new System.EventHandler(this.AdminHome_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogbookReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCaretakers;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnLogboox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridLogbookReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegistrationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aluno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caretaker;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button button1;
    }
}