namespace Eduflow.views.Admin.Caretaker
{
    partial class ListCaretaker
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
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblCaretakerId = new System.Windows.Forms.Label();
            this.lblCaretakerName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVoltar);
            this.groupBox1.Controls.Add(this.lblCaretakerId);
            this.groupBox1.Controls.Add(this.lblCaretakerName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(59, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1238, 880);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exibir Informacoes Cuidador";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(1010, 810);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(189, 55);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblCaretakerId
            // 
            this.lblCaretakerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaretakerId.Location = new System.Drawing.Point(150, 355);
            this.lblCaretakerId.Name = "lblCaretakerId";
            this.lblCaretakerId.Size = new System.Drawing.Size(816, 31);
            this.lblCaretakerId.TabIndex = 2;
            this.lblCaretakerId.Text = "Matricula do Cuidador:";
            // 
            // lblCaretakerName
            // 
            this.lblCaretakerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaretakerName.Location = new System.Drawing.Point(150, 298);
            this.lblCaretakerName.Name = "lblCaretakerName";
            this.lblCaretakerName.Size = new System.Drawing.Size(816, 31);
            this.lblCaretakerName.TabIndex = 0;
            this.lblCaretakerName.Text = "Nome do Cuidador:";
            // 
            // ListCaretaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 1006);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListCaretaker";
            this.Text = "Listar";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblCaretakerId;
        private System.Windows.Forms.Label lblCaretakerName;
    }
}