namespace From_Report
{
    partial class FrmBHYT
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
            this.txtBA = new DevExpress.XtraEditors.TextEdit();
            this.btnBhyt = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtBA.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBA
            // 
            this.txtBA.Location = new System.Drawing.Point(32, 10);
            this.txtBA.Name = "txtBA";
            this.txtBA.Size = new System.Drawing.Size(145, 20);
            this.txtBA.TabIndex = 0;
            // 
            // btnBhyt
            // 
            this.btnBhyt.Location = new System.Drawing.Point(211, 4);
            this.btnBhyt.Name = "btnBhyt";
            this.btnBhyt.Size = new System.Drawing.Size(141, 32);
            this.btnBhyt.TabIndex = 1;
            this.btnBhyt.Text = "Tổng hợp BHYT";
            this.btnBhyt.Click += new System.EventHandler(this.btnBhyt_Click);
            // 
            // FrmBHYT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 41);
            this.Controls.Add(this.btnBhyt);
            this.Controls.Add(this.txtBA);
            this.Name = "FrmBHYT";
            this.Text = "Tổng hợp BHYT";
            ((System.ComponentModel.ISupportInitialize)(this.txtBA.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtBA;
        private DevExpress.XtraEditors.SimpleButton btnBhyt;
    }
}