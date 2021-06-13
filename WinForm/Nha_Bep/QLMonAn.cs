using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nha_Bep
{
    public partial class QLMonAn : Form
    {
        public string rootFolder = @"D:\bài tập\API\Test1\Image\";
        MonAnCanLam ma = new MonAnCanLam();
        public QLMonAn()
        {
            InitializeComponent();
            loadMonAn();
        }
        private async void loadMonAn()
        {
            ImageList imlist = new ImageList();
            var monan = await ma.GetMonAn();
            listView1.Columns.Add("Ảnh Và Tên Món Ăn ", 210);
            listView1.Columns.Add("Số Lượng", 100);
            //listView1.Columns.Add("Giá", 100);
            Button bt = new Button();
            int j = -1;
            while (j <= monan.Count)
            {
                j++;
                for (int i = 0; i < 1; i++)
                {
                    if (j < monan.Count)
                    {
                        imlist.ImageSize = new Size(40, 40);
                        imlist.Images.Add("pic " + j, Image.FromFile(rootFolder + monan[j].HinhAnh));
                        listView1.SmallImageList = imlist;
                        ListViewItem item = new ListViewItem(monan[j].TenMonAn.ToString(), j);
                        item.Tag = monan[j].MaDatMon;
                        listView1.Items.Add(item);

                        ListViewItem.ListViewSubItem subitem1 = new ListViewItem.ListViewSubItem(item, (monan[j].SoLuong.ToString()));
                        item.SubItems.Add(subitem1);

                        //ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, (hoadon[j].GiaMon.ToString()));
                        //item.SubItems.Add(subitem);


                    }
                    else
                    {

                        break;
                    }

                }
            }
        }
    }
}
