namespace GeneralCode
{
    partial class General
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
            this.richTxtBox = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.SuspendLayout();
            // 
            // richTxtBox
            // 
            // 
            // 
            // 
            this.richTxtBox.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richTxtBox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTxtBox.Location = new System.Drawing.Point(0, 0);
            this.richTxtBox.Name = "richTxtBox";
            this.richTxtBox.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4" +
    "\\uc1\\pard\\lang1033\\f0\\fs17 Th\\\'f4ng tin Code\\par\r\n}\r\n";
            this.richTxtBox.Size = new System.Drawing.Size(912, 602);
            this.richTxtBox.TabIndex = 0;
            this.richTxtBox.Text = "Thông tin Code";
            // 
            // General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 602);
            this.Controls.Add(this.richTxtBox);
            this.Name = "General";
            this.Text = "General";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.RichTextBoxEx richTxtBox;

    }
}