namespace From_Report.From_Dstore
{
    partial class Frm_Group_type
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
            this.gridControl_Group_Type = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.line = new DevExpress.XtraGrid.Columns.GridColumn();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Group_Type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Group_Type
            // 
            this.gridControl_Group_Type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Group_Type.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Group_Type.MainView = this.gridView1;
            this.gridControl_Group_Type.Name = "gridControl_Group_Type";
            this.gridControl_Group_Type.Size = new System.Drawing.Size(413, 225);
            this.gridControl_Group_Type.TabIndex = 0;
            this.gridControl_Group_Type.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl_Group_Type.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControl_Group_Type_KeyDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.line,
            this.name});
            this.gridView1.GridControl = this.gridControl_Group_Type;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // line
            // 
            this.line.Caption = "ID";
            this.line.FieldName = "line";
            this.line.Name = "line";
            this.line.OptionsColumn.AllowEdit = false;
            this.line.OptionsColumn.AllowMove = false;
            this.line.OptionsColumn.AllowSize = false;
            this.line.OptionsColumn.FixedWidth = true;
            this.line.Visible = true;
            this.line.VisibleIndex = 0;
            this.line.Width = 35;
            // 
            // name
            // 
            this.name.Caption = "Mã Nhóm";
            this.name.FieldName = "name";
            this.name.Name = "name";
            this.name.OptionsColumn.FixedWidth = true;
            this.name.Visible = true;
            this.name.VisibleIndex = 1;
            this.name.Width = 360;
            // 
            // Frm_Group_type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 225);
            this.Controls.Add(this.gridControl_Group_Type);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Group_type";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Frm_Group_type";
            this.Load += new System.EventHandler(this.Frm_Group_type_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Group_Type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Group_Type;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn line;
        private DevExpress.XtraGrid.Columns.GridColumn name;
    }
}