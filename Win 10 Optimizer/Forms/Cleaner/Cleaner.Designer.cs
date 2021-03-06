
namespace Win_10_Optimizer.Forms
{
    partial class Cleaner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cleaner));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.WindowsFilesCheckBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label1 = new System.Windows.Forms.Label();
            this.GameTrashFilesCheckBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ScreenShotsFilesCheckBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label5 = new System.Windows.Forms.Label();
            this.MediaFilesCheckBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.LogsFilesCheckBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.CacheFilesCheckBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.label6 = new System.Windows.Forms.Label();
            this.ClearButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.SuspendLayout();
            // 
            // WindowsFilesCheckBox
            // 
            this.WindowsFilesCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.WindowsFilesCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.WindowsFilesCheckBox.Checked = false;
            this.WindowsFilesCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.WindowsFilesCheckBox.ForeColor = System.Drawing.Color.White;
            this.WindowsFilesCheckBox.Location = new System.Drawing.Point(221, 9);
            this.WindowsFilesCheckBox.Name = "WindowsFilesCheckBox";
            this.WindowsFilesCheckBox.Size = new System.Drawing.Size(20, 20);
            this.WindowsFilesCheckBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Windows файлы (Windows garbage)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GameTrashFilesCheckBox
            // 
            this.GameTrashFilesCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.GameTrashFilesCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.GameTrashFilesCheckBox.Checked = false;
            this.GameTrashFilesCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.GameTrashFilesCheckBox.ForeColor = System.Drawing.Color.White;
            this.GameTrashFilesCheckBox.Location = new System.Drawing.Point(169, 65);
            this.GameTrashFilesCheckBox.Name = "GameTrashFilesCheckBox";
            this.GameTrashFilesCheckBox.Size = new System.Drawing.Size(20, 20);
            this.GameTrashFilesCheckBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Мусор игр (Game garbage)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Логи (Logs)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(12, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Скриншоты (Screenshots)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScreenShotsFilesCheckBox
            // 
            this.ScreenShotsFilesCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.ScreenShotsFilesCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.ScreenShotsFilesCheckBox.Checked = false;
            this.ScreenShotsFilesCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.ScreenShotsFilesCheckBox.ForeColor = System.Drawing.Color.White;
            this.ScreenShotsFilesCheckBox.Location = new System.Drawing.Point(169, 37);
            this.ScreenShotsFilesCheckBox.Name = "ScreenShotsFilesCheckBox";
            this.ScreenShotsFilesCheckBox.Size = new System.Drawing.Size(20, 20);
            this.ScreenShotsFilesCheckBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(12, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Видео (Video)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MediaFilesCheckBox
            // 
            this.MediaFilesCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.MediaFilesCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.MediaFilesCheckBox.Checked = false;
            this.MediaFilesCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.MediaFilesCheckBox.ForeColor = System.Drawing.Color.White;
            this.MediaFilesCheckBox.Location = new System.Drawing.Point(98, 94);
            this.MediaFilesCheckBox.Name = "MediaFilesCheckBox";
            this.MediaFilesCheckBox.Size = new System.Drawing.Size(20, 20);
            this.MediaFilesCheckBox.TabIndex = 15;
            // 
            // LogsFilesCheckBox
            // 
            this.LogsFilesCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.LogsFilesCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.LogsFilesCheckBox.Checked = false;
            this.LogsFilesCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.LogsFilesCheckBox.ForeColor = System.Drawing.Color.White;
            this.LogsFilesCheckBox.Location = new System.Drawing.Point(87, 122);
            this.LogsFilesCheckBox.Name = "LogsFilesCheckBox";
            this.LogsFilesCheckBox.Size = new System.Drawing.Size(20, 20);
            this.LogsFilesCheckBox.TabIndex = 16;
            // 
            // CacheFilesCheckBox
            // 
            this.CacheFilesCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.CacheFilesCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.CacheFilesCheckBox.Checked = false;
            this.CacheFilesCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.CacheFilesCheckBox.ForeColor = System.Drawing.Color.White;
            this.CacheFilesCheckBox.Location = new System.Drawing.Point(87, 148);
            this.CacheFilesCheckBox.Name = "CacheFilesCheckBox";
            this.CacheFilesCheckBox.Size = new System.Drawing.Size(20, 20);
            this.CacheFilesCheckBox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(12, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Кэш (Cache)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClearButton
            // 
            this.ClearButton.AllowToggling = false;
            this.ClearButton.AnimationSpeed = 200;
            this.ClearButton.AutoGenerateColors = false;
            this.ClearButton.BackColor = System.Drawing.Color.Transparent;
            this.ClearButton.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClearButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ClearButton.BackgroundImage")));
            this.ClearButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.ClearButton.ButtonText = "Очистить";
            this.ClearButton.ButtonTextMarginLeft = -80;
            this.ClearButton.ColorContrastOnClick = 45;
            this.ClearButton.ColorContrastOnHover = 45;
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = false;
            borderEdges1.BottomRight = false;
            borderEdges1.TopLeft = false;
            borderEdges1.TopRight = false;
            this.ClearButton.CustomizableEdges = borderEdges1;
            this.ClearButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ClearButton.DisabledBorderColor = System.Drawing.Color.Empty;
            this.ClearButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.ClearButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.ClearButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.ClearButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ClearButton.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.ClearButton.IconMarginLeft = 0;
            this.ClearButton.IconPadding = 0;
            this.ClearButton.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.ClearButton.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClearButton.IdleBorderRadius = 3;
            this.ClearButton.IdleBorderThickness = 1;
            this.ClearButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClearButton.IdleIconLeftImage = null;
            this.ClearButton.IdleIconRightImage = null;
            this.ClearButton.IndicateFocus = true;
            this.ClearButton.Location = new System.Drawing.Point(12, 171);
            this.ClearButton.Name = "ClearButton";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties1.BorderRadius = 3;
            stateProperties1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties1.BorderThickness = 1;
            stateProperties1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties1.ForeColor = System.Drawing.Color.White;
            stateProperties1.IconLeftImage = null;
            stateProperties1.IconRightImage = null;
            this.ClearButton.onHoverState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.BorderRadius = 3;
            stateProperties2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties2.BorderThickness = 1;
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.ForeColor = System.Drawing.Color.Gainsboro;
            stateProperties2.IconLeftImage = null;
            stateProperties2.IconRightImage = null;
            this.ClearButton.OnPressedState = stateProperties2;
            this.ClearButton.Size = new System.Drawing.Size(235, 30);
            this.ClearButton.TabIndex = 19;
            this.ClearButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ClearButton.TextMarginLeft = -80;
            this.ClearButton.UseDefaultRadiusAndThickness = true;
            this.ClearButton.Click += new System.EventHandler(this.OptimizeButton_Click);
            // 
            // Cleaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(254, 207);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.CacheFilesCheckBox);
            this.Controls.Add(this.LogsFilesCheckBox);
            this.Controls.Add(this.MediaFilesCheckBox);
            this.Controls.Add(this.ScreenShotsFilesCheckBox);
            this.Controls.Add(this.GameTrashFilesCheckBox);
            this.Controls.Add(this.WindowsFilesCheckBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cleaner";
            this.Text = "Cleaner";
            this.Load += new System.EventHandler(this.Cleaner_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCheckbox WindowsFilesCheckBox;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuCheckbox GameTrashFilesCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuCheckbox ScreenShotsFilesCheckBox;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuCheckbox MediaFilesCheckBox;
        private Bunifu.Framework.UI.BunifuCheckbox LogsFilesCheckBox;
        private Bunifu.Framework.UI.BunifuCheckbox CacheFilesCheckBox;
        private System.Windows.Forms.Label label6;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton ClearButton;
    }
}