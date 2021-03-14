
namespace Win_10_Optimizer.Forms
{
    partial class ServicesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesForm));
            this.WindowsUpdaterCheckBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label1 = new System.Windows.Forms.Label();
            this.WindowsDefenderCheckBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WindowsUpdaterCheckBox
            // 
            this.WindowsUpdaterCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.WindowsUpdaterCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.WindowsUpdaterCheckBox.Checked = false;
            this.WindowsUpdaterCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.WindowsUpdaterCheckBox.ForeColor = System.Drawing.Color.White;
            this.WindowsUpdaterCheckBox.Location = new System.Drawing.Point(205, 11);
            this.WindowsUpdaterCheckBox.Name = "WindowsUpdaterCheckBox";
            this.WindowsUpdaterCheckBox.Size = new System.Drawing.Size(20, 20);
            this.WindowsUpdaterCheckBox.TabIndex = 5;
            this.WindowsUpdaterCheckBox.OnChange += new System.EventHandler(this.WindowsUpdaterCheckBox_OnChange);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Отключить обновления Windows";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WindowsDefenderCheckBox
            // 
            this.WindowsDefenderCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.WindowsDefenderCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.WindowsDefenderCheckBox.Checked = false;
            this.WindowsDefenderCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.WindowsDefenderCheckBox.ForeColor = System.Drawing.Color.White;
            this.WindowsDefenderCheckBox.Location = new System.Drawing.Point(192, 43);
            this.WindowsDefenderCheckBox.Name = "WindowsDefenderCheckBox";
            this.WindowsDefenderCheckBox.Size = new System.Drawing.Size(20, 20);
            this.WindowsDefenderCheckBox.TabIndex = 7;
            this.WindowsDefenderCheckBox.OnChange += new System.EventHandler(this.WindowsDefenderCheckBox_OnChange);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Отключить защитник Windows";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(241, 72);
            this.Controls.Add(this.WindowsDefenderCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WindowsUpdaterCheckBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServicesForm";
            this.Text = "Services";
            this.Load += new System.EventHandler(this.Services_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCheckbox WindowsUpdaterCheckBox;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCheckbox WindowsDefenderCheckBox;
        private System.Windows.Forms.Label label2;
    }
}