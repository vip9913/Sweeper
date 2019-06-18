namespace SharpSweeper
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.panel = new System.Windows.Forms.Panel();
            this.tBoxMine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pBoxSmile = new System.Windows.Forms.PictureBox();
            this.tBoxMineOpen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxSmile)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Location = new System.Drawing.Point(12, 38);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(260, 211);
            this.panel.TabIndex = 1;
            this.panel.Resize += new System.EventHandler(this.panel_Resize);
            // 
            // tBoxMine
            // 
            this.tBoxMine.Enabled = false;
            this.tBoxMine.Location = new System.Drawing.Point(78, 12);
            this.tBoxMine.Name = "tBoxMine";
            this.tBoxMine.Size = new System.Drawing.Size(23, 20);
            this.tBoxMine.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Всего мин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Открыто мин:";
            // 
            // pBoxSmile
            // 
            this.pBoxSmile.Image = global::SharpSweeper.Properties.Resources.bomb;
            this.pBoxSmile.Location = new System.Drawing.Point(118, 13);
            this.pBoxSmile.Name = "pBoxSmile";
            this.pBoxSmile.Size = new System.Drawing.Size(31, 19);
            this.pBoxSmile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxSmile.TabIndex = 6;
            this.pBoxSmile.TabStop = false;
            // 
            // tBoxMineOpen
            // 
            this.tBoxMineOpen.Enabled = false;
            this.tBoxMineOpen.Location = new System.Drawing.Point(249, 12);
            this.tBoxMineOpen.Name = "tBoxMineOpen";
            this.tBoxMineOpen.Size = new System.Drawing.Size(23, 20);
            this.tBoxMineOpen.TabIndex = 7;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tBoxMineOpen);
            this.Controls.Add(this.pBoxSmile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBoxMine);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Саперчик";
            ((System.ComponentModel.ISupportInitialize)(this.pBoxSmile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox tBoxMine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pBoxSmile;
        private System.Windows.Forms.TextBox tBoxMineOpen;
    }
}

