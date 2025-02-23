namespace BlizzardApp.Forms
{
    partial class CestaForm
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
            this.lblCesta = new System.Windows.Forms.Label();
            this.btnComprar = new System.Windows.Forms.Button();
            this.catalogo = new BlizzardApp.Catalogo();
            this.SuspendLayout();
            // 
            // lblCesta
            // 
            this.lblCesta.AutoSize = true;
            this.lblCesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCesta.Location = new System.Drawing.Point(29, 12);
            this.lblCesta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCesta.Name = "lblCesta";
            this.lblCesta.Size = new System.Drawing.Size(151, 39);
            this.lblCesta.TabIndex = 13;
            this.lblCesta.Text = "Mi Cesta";
            // 
            // btnComprar
            // 
            this.btnComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnComprar.Location = new System.Drawing.Point(593, 135);
            this.btnComprar.Margin = new System.Windows.Forms.Padding(4);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(243, 77);
            this.btnComprar.TabIndex = 14;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // catalogo
            // 
            this.catalogo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.catalogo.Location = new System.Drawing.Point(36, 78);
            this.catalogo.Name = "catalogo";
            this.catalogo.Size = new System.Drawing.Size(550, 200);
            this.catalogo.TabIndex = 15;
            // 
            // CestaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(849, 299);
            this.Controls.Add(this.catalogo);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.lblCesta);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CestaForm";
            this.Text = "CestaForm";
            this.Load += new System.EventHandler(this.CestaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCesta;
        private System.Windows.Forms.Button btnComprar;
        private Catalogo catalogo;
    }
}