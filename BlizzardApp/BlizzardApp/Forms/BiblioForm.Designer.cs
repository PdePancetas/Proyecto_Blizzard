namespace BlizzardApp.Forms
{
    partial class BiblioForm
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
            this.catalogo = new BlizzardApp.Catalogo();
            this.SuspendLayout();
            // 
            // lblCesta
            // 
            this.lblCesta.AutoSize = true;
            this.lblCesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCesta.Location = new System.Drawing.Point(13, 9);
            this.lblCesta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCesta.Name = "lblCesta";
            this.lblCesta.Size = new System.Drawing.Size(189, 39);
            this.lblCesta.TabIndex = 14;
            this.lblCesta.Text = "Mis Juegos";
            // 
            // catalogo
            // 
            this.catalogo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.catalogo.Location = new System.Drawing.Point(12, 51);
            this.catalogo.Name = "catalogo";
            this.catalogo.Size = new System.Drawing.Size(547, 223);
            this.catalogo.TabIndex = 16;
            // 
            // BiblioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(694, 345);
            this.Controls.Add(this.catalogo);
            this.Controls.Add(this.lblCesta);
            this.Name = "BiblioForm";
            this.Text = "BiblioForm";
            this.Load += new System.EventHandler(this.BiblioForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCesta;
        private Catalogo catalogo;
    }
}