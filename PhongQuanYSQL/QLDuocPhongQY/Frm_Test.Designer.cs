namespace QLDuocPhongQY
{
    partial class Frm_Test
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
            this.btbConnect = new DevExpress.XtraEditors.SimpleButton();
            this.lst_database = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btbConnect
            // 
            this.btbConnect.Location = new System.Drawing.Point(12, 12);
            this.btbConnect.Name = "btbConnect";
            this.btbConnect.Size = new System.Drawing.Size(131, 37);
            this.btbConnect.TabIndex = 1;
            this.btbConnect.Text = "Kiemtra Ket Noi";
            this.btbConnect.Click += new System.EventHandler(this.btbConnect_Click);
            // 
            // lst_database
            // 
            this.lst_database.FormattingEnabled = true;
            this.lst_database.Location = new System.Drawing.Point(181, 14);
            this.lst_database.Name = "lst_database";
            this.lst_database.Size = new System.Drawing.Size(209, 368);
            this.lst_database.TabIndex = 2;
            // 
            // Frm_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 544);
            this.Controls.Add(this.lst_database);
            this.Controls.Add(this.btbConnect);
            this.Name = "Frm_Test";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btbConnect;
        private System.Windows.Forms.ListBox lst_database;
    }
}

