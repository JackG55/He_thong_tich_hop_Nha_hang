using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Test1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {

        LoaiMonRepository loaimonrepo = new LoaiMonRepository();
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            var listLoaiMon =await loaimonrepo.Getlist();
            gridControl1.DataSource = listLoaiMon;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }
    }
}