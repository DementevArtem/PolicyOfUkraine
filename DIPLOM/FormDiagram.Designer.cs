namespace DIPLOM
{
    partial class FormDiagram
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
            this.panelDiagram = new System.Windows.Forms.Panel();
            this.bunifuDataViz1 = new Bunifu.DataViz.WinForms.BunifuDataViz();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDiagram.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDiagram
            // 
            this.panelDiagram.Controls.Add(this.bunifuDataViz1);
            this.panelDiagram.Controls.Add(this.label1);
            this.panelDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDiagram.Location = new System.Drawing.Point(0, 0);
            this.panelDiagram.Name = "panelDiagram";
            this.panelDiagram.Size = new System.Drawing.Size(640, 421);
            this.panelDiagram.TabIndex = 0;
            // 
            // bunifuDataViz1
            // 
            this.bunifuDataViz1.animationEnabled = true;
            this.bunifuDataViz1.AxisLineColor = System.Drawing.Color.LightGray;
            this.bunifuDataViz1.AxisXFontColor = System.Drawing.Color.Gray;
            this.bunifuDataViz1.AxisXGridColor = System.Drawing.Color.Gray;
            this.bunifuDataViz1.AxisXGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bunifuDataViz1.AxisYFontColor = System.Drawing.Color.Gray;
            this.bunifuDataViz1.AxisYGridColor = System.Drawing.Color.Gray;
            this.bunifuDataViz1.AxisYGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bunifuDataViz1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuDataViz1.Location = new System.Drawing.Point(46, 85);
            this.bunifuDataViz1.Name = "bunifuDataViz1";
            this.bunifuDataViz1.Size = new System.Drawing.Size(521, 269);
            this.bunifuDataViz1.TabIndex = 1;
            this.bunifuDataViz1.Theme = Bunifu.DataViz.WinForms.BunifuDataViz._theme.theme1;
            this.bunifuDataViz1.Title = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(267, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "ПУПОК";
            // 
            // FormDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(43)))), ((int)(((byte)(151)))));
            this.ClientSize = new System.Drawing.Size(640, 421);
            this.Controls.Add(this.panelDiagram);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDiagram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDiagram";
            this.panelDiagram.ResumeLayout(false);
            this.panelDiagram.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDiagram;
        private System.Windows.Forms.Label label1;
        private Bunifu.DataViz.WinForms.BunifuDataViz bunifuDataViz1;
    }
}