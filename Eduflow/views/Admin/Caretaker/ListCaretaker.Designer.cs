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
            this.txtCaretakerRegistration = new System.Windows.Forms.TextBox();
            this.txtCaretakerName = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblCaretakerId = new System.Windows.Forms.Label();
            this.lblCaretakerName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCaretakerRegistration);
            this.groupBox1.Controls.Add(this.txtCaretakerName);
            this.groupBox1.Controls.Add(this.btnVoltar);
            this.groupBox1.Controls.Add(this.lblCaretakerId);
            this.groupBox1.Controls.Add(this.lblCaretakerName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(619, 458);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exibir Informacoes Cuidador";
            // 
            // txtCaretakerRegistration
            // 
            this.txtCaretakerRegistration.Location = new System.Drawing.Point(221, 218);
            this.txtCaretakerRegistration.Name = "txtCaretakerRegistration";
            this.txtCaretakerRegistration.Size = new System.Drawing.Size(304, 24);
            this.txtCaretakerRegistration.TabIndex = 6;
            // 
            // txtCaretakerName
            // 
            this.txtCaretakerName.Location = new System.Drawing.Point(198, 188);
            this.txtCaretakerName.Name = "txtCaretakerName";
            this.txtCaretakerName.Size = new System.Drawing.Size(327, 24);
            this.txtCaretakerName.TabIndex = 5;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(505, 421);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(94, 29);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblCaretakerId
            // 
            this.lblCaretakerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaretakerId.Location = new System.Drawing.Point(68, 222);
            this.lblCaretakerId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaretakerId.Name = "lblCaretakerId";
            this.lblCaretakerId.Size = new System.Drawing.Size(408, 16);
            this.lblCaretakerId.TabIndex = 2;
            this.lblCaretakerId.Text = "Matricula do Cuidador:";
            // 
            // lblCaretakerName
            // 
            this.lblCaretakerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaretakerName.Location = new System.Drawing.Point(68, 192);
            this.lblCaretakerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaretakerName.Name = "lblCaretakerName";
            this.lblCaretakerName.Size = new System.Drawing.Size(408, 16);
            this.lblCaretakerName.TabIndex = 0;
            this.lblCaretakerName.Text = "Nome do Cuidador:";
            // 
            // ListCaretaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 523);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ListCaretaker";
            this.Text = "Listar";
            this.Load += new System.EventHandler(this.ListCaretaker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblCaretakerId;
        private System.Windows.Forms.Label lblCaretakerName;
        private System.Windows.Forms.TextBox txtCaretakerRegistration;
        private System.Windows.Forms.TextBox txtCaretakerName;
    }
}