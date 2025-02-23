using System.Windows.Forms;

namespace BlizzardApp
{
    partial class Catalogo
    {
        private System.ComponentModel.IContainer components = null;

        private FlowLayoutPanel flowLayoutPanel;

        // Inicializa el FlowLayoutPanel en el método InitializeComponent
        private void InitializeComponent()
        {
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel.Size = new System.Drawing.Size(654, 256);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // Catalogo
            // 
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "Catalogo";
            this.Size = new System.Drawing.Size(626, 256);
            this.ResumeLayout(false);

        }
    }

}
