namespace Test1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.loaiMonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaLoaiMon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenLoaiMon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTieuDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThuTuXuatHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTuKhoaTimKiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.thongTinNguoiQuanLyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiMonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinNguoiQuanLyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.loaiMonBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 235);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1133, 425);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // loaiMonBindingSource
            // 
            this.loaiMonBindingSource.DataSource = typeof(Test1.Models.LoaiMon);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaLoaiMon,
            this.colTenLoaiMon,
            this.colTieuDe,
            this.colNgayTao,
            this.colThuTuXuatHien,
            this.colTuKhoaTimKiem});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colMaLoaiMon
            // 
            this.colMaLoaiMon.FieldName = "MaLoaiMon";
            this.colMaLoaiMon.MinWidth = 25;
            this.colMaLoaiMon.Name = "colMaLoaiMon";
            this.colMaLoaiMon.Visible = true;
            this.colMaLoaiMon.VisibleIndex = 0;
            this.colMaLoaiMon.Width = 94;
            // 
            // colTenLoaiMon
            // 
            this.colTenLoaiMon.FieldName = "TenLoaiMon";
            this.colTenLoaiMon.MinWidth = 25;
            this.colTenLoaiMon.Name = "colTenLoaiMon";
            this.colTenLoaiMon.Visible = true;
            this.colTenLoaiMon.VisibleIndex = 1;
            this.colTenLoaiMon.Width = 94;
            // 
            // colTieuDe
            // 
            this.colTieuDe.FieldName = "TieuDe";
            this.colTieuDe.MinWidth = 25;
            this.colTieuDe.Name = "colTieuDe";
            this.colTieuDe.Visible = true;
            this.colTieuDe.VisibleIndex = 2;
            this.colTieuDe.Width = 94;
            // 
            // colNgayTao
            // 
            this.colNgayTao.FieldName = "NgayTao";
            this.colNgayTao.MinWidth = 25;
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.Visible = true;
            this.colNgayTao.VisibleIndex = 3;
            this.colNgayTao.Width = 94;
            // 
            // colThuTuXuatHien
            // 
            this.colThuTuXuatHien.FieldName = "ThuTuXuatHien";
            this.colThuTuXuatHien.MinWidth = 25;
            this.colThuTuXuatHien.Name = "colThuTuXuatHien";
            this.colThuTuXuatHien.Visible = true;
            this.colThuTuXuatHien.VisibleIndex = 4;
            this.colThuTuXuatHien.Width = 94;
            // 
            // colTuKhoaTimKiem
            // 
            this.colTuKhoaTimKiem.FieldName = "TuKhoaTimKiem";
            this.colTuKhoaTimKiem.MinWidth = 25;
            this.colTuKhoaTimKiem.Name = "colTuKhoaTimKiem";
            this.colTuKhoaTimKiem.Visible = true;
            this.colTuKhoaTimKiem.VisibleIndex = 5;
            this.colTuKhoaTimKiem.Width = 94;
            // 
            // thongTinNguoiQuanLyBindingSource
            // 
            this.thongTinNguoiQuanLyBindingSource.DataSource = typeof(Test1.Models.ThongTinNguoiQuanLy);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1133, 176);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "THÊM";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "SỬA";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Load";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // LoaiMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 660);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "LoaiMon";
            this.Text = "LoaiMon";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiMonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinNguoiQuanLyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource loaiMonBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaLoaiMon;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLoaiMon;
        private DevExpress.XtraGrid.Columns.GridColumn colTieuDe;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTao;
        private DevExpress.XtraGrid.Columns.GridColumn colThuTuXuatHien;
        private DevExpress.XtraGrid.Columns.GridColumn colTuKhoaTimKiem;
        private System.Windows.Forms.BindingSource thongTinNguoiQuanLyBindingSource;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}