using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class thanhtoan_Hd : Form
    {
        banan ban = new banan();
        Hoadon hd = new Hoadon();
        public thanhtoan_Hd()
        {
            InitializeComponent();
            loadban();
        }
        private async void loadban()
        {
            var listq = await ban.Getlist();
            Button oldbtn = new Button() { Width = 0, Location = new Point(0, 0) };

            int k = -1;
            while (k <= listq.Count)
            {
                for (int j = 0; j <=3; j++)
                {
                    k++;
                    if (k < listq.Count)
                    {

                        Button btn = new Button()
                        {
                            Width = cons.table_wight,
                            Height = cons.table_heigh,
                            Location = new Point(oldbtn.Location.X + oldbtn.Width, oldbtn.Location.Y),
                            Text = listq[k].TenBan + "\n" + listq[k].Vitri,
                            Name = listq[k].MaBan
                        };
                        btn.Click += Btn_Click;

                        panelBan.Controls.Add(btn);
                        oldbtn = btn;

                    }
                    else
                    {
                        break;
                    }

                }

                oldbtn.Location = new Point(0, oldbtn.Location.Y + cons.table_heigh + 10);
                oldbtn.Width = 0;
                //oldbtn.Height = 0;

            }
        }

        public async void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ImageList imlist = new ImageList();
            imlist.Images.Add("pic1", Image.FromFile(@"D:\bài tập\API\Test1\Image\breakfast-7.jpg"));
            imlist.Images.Add("pic2", Image.FromFile(@"D:\bài tập\API\Test1\Image\breakfast-7.jpg"));
            imlist.Images.Add("pic3", Image.FromFile(@"D:\bài tập\API\Test1\Image\dinner-1.jpg"));
            imlist.Images.Add("pic4", Image.FromFile(@"D:\bài tập\API\Test1\Image\dinner-2.jpg"));
            imlist.Images.Add("pic5", Image.FromFile(@"D:\bài tập\API\Test1\Image\dinner-4.jpg"));
            imlist.Images.Add("pic6", Image.FromFile(@"D:\bài tập\API\Test1\Image\dinner-3.jpg"));
            var hoadon = await hd.GetHD(btn.Name);

            listView1.Columns.Add("Ảnh Và Tên Món Ăn", 210);
            listView1.Columns.Add("Số Lượng", 80);
            listView1.Columns.Add("Giá", 100);
            int j = -1;
            while (j <= hoadon.Count)
            {
                j++;
                for (int i = 0; i < 1; i++)
                {
                    if (j < hoadon.Count)
                    {
                        imlist.ImageSize = new Size(40, 40);
                        listView1.SmallImageList = imlist;
                        ListViewItem item = new ListViewItem(hoadon[j].TenMonAn.ToString(), j);
                        listView1.Items.Add(item);
                        ListViewItem.ListViewSubItem subitem1 = new ListViewItem.ListViewSubItem(item, (hoadon[j].SoLuong.ToString()));
                        item.SubItems.Add(subitem1);
                        ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, (hoadon[j].GiaMon.ToString()));
                        item.SubItems.Add(subitem);


                    }
                    else
                    {

                        break;
                    }

                }

            }
            double tong = 0;
           
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string s = listView1.Items[i].SubItems[2].Text;
                tong += Convert.ToDouble(s);
            }
            ListViewItem g = new ListViewItem("Tổng Tiền");
            g.SubItems.Add(" ");
            g.SubItems.Add(tong.ToString());
            listView1.Items.Add(g);
           
        }


        public class cons
        {
            public static int table_wight = 60;
            public static int table_heigh = 60;
            public static int usecontrol_height = 60;
            public static int usecontrol_wightt = 150;
        }
    }
}


