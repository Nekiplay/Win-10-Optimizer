﻿
namespace Win_10_Optimizer.Forms
{
    partial class EnergyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnergyForm));
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuCheckbox1 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.bunifuCheckbox3 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuCheckbox2 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Максимальная производительность\r\n(Электропитание)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuCheckbox1
            // 
            this.bunifuCheckbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.Checked = false;
            this.bunifuCheckbox1.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.bunifuCheckbox1.ForeColor = System.Drawing.Color.White;
            this.bunifuCheckbox1.Location = new System.Drawing.Point(221, 18);
            this.bunifuCheckbox1.Name = "bunifuCheckbox1";
            this.bunifuCheckbox1.Size = new System.Drawing.Size(20, 20);
            this.bunifuCheckbox1.TabIndex = 3;
            this.bunifuCheckbox1.OnChange += new System.EventHandler(this.bunifuCheckbox1_OnChange);
            // 
            // bunifuCheckbox3
            // 
            this.bunifuCheckbox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox3.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox3.Checked = false;
            this.bunifuCheckbox3.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.bunifuCheckbox3.ForeColor = System.Drawing.Color.White;
            this.bunifuCheckbox3.Location = new System.Drawing.Point(186, 57);
            this.bunifuCheckbox3.Name = "bunifuCheckbox3";
            this.bunifuCheckbox3.Size = new System.Drawing.Size(20, 20);
            this.bunifuCheckbox3.TabIndex = 3;
            this.bunifuCheckbox3.OnChange += new System.EventHandler(this.bunifuCheckbox3_OnChange);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Уменьшить пинг\r\n(Отключить алгоритм нейгла)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Отключить гибернацию\r\n(Умный спящий режим)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuCheckbox2
            // 
            this.bunifuCheckbox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox2.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox2.Checked = false;
            this.bunifuCheckbox2.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.bunifuCheckbox2.ForeColor = System.Drawing.Color.White;
            this.bunifuCheckbox2.Location = new System.Drawing.Point(154, 96);
            this.bunifuCheckbox2.Name = "bunifuCheckbox2";
            this.bunifuCheckbox2.Size = new System.Drawing.Size(20, 20);
            this.bunifuCheckbox2.TabIndex = 3;
            this.bunifuCheckbox2.OnChange += new System.EventHandler(this.bunifuCheckbox2_OnChange);
            // 
            // EnergyOptimize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(255, 130);
            this.Controls.Add(this.bunifuCheckbox1);
            this.Controls.Add(this.bunifuCheckbox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuCheckbox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnergyOptimize";
            this.Text = "EnergyOptimize";
            this.Load += new System.EventHandler(this.EnergyOptimize_Load_1);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox1;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox2;
    }
}