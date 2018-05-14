namespace QLDuocTrangBi.From_ChucNang
{
    partial class Frm_HoatChat
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.txtMa = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gc_hoatchat = new DevExpress.XtraGrid.GridControl();
            this.gv_hoatchat = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_hoatchat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_hoatchat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtTen);
            this.groupControl1.Controls.Add(this.txtMa);
            this.groupControl1.Location = new System.Drawing.Point(0, 54);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(387, 128);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thông tin hoạt chất";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên Hoạt Chất";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Mã Hoạt Chất";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(104, 77);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(271, 20);
            this.txtTen.TabIndex = 0;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(104, 34);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(271, 20);
            this.txtMa.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gc_hoatchat);
            this.groupControl2.Location = new System.Drawing.Point(0, 185);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(387, 325);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Danh sách hoạt chất";
            // 
            // gc_hoatchat
            // 
            this.gc_hoatchat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_hoatchat.Location = new System.Drawing.Point(2, 20);
            this.gc_hoatchat.MainView = this.gv_hoatchat;
            this.gc_hoatchat.Name = "gc_hoatchat";
            this.gc_hoatchat.Size = new System.Drawing.Size(383, 303);
            this.gc_hoatchat.TabIndex = 0;
            this.gc_hoatchat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_hoatchat});
            // 
            // gv_hoatchat
            // 
            this.gv_hoatchat.GridControl = this.gc_hoatchat;
            this.gv_hoatchat.Name = "gv_hoatchat";
            this.gv_hoatchat.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gv_hoatchat.OptionsView.ShowGroupPanel = false;
            this.gv_hoatchat.Click += new System.EventHandler(this.gv_hoatchat_Click);
            // 
            // Frm_HoatChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(387, 541);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Frm_HoatChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_hoatchat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_hoatchat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gc_hoatchat;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_hoatchat;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.TextEdit txtMa;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
