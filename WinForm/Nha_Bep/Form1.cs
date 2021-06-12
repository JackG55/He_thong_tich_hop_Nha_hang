using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test1;
using Test1.Models;

namespace Nha_Bep
{
    public partial class Form1 : Form
    {
        banan ban = new banan();
        // Hoadon hd = new Hoadon();
        NhaBep nb = new NhaBep();
        public string rootFolder = @"D:\bài tập\API\Test1\Image\";
        public Form1()
        {
            InitializeComponent();
            loadban();
        }
        private async void loadban()
        {
            var listq = await ban.Getlist();
            int X = 0;
            int Y = 0;

            int k = -1;
            while (k < listq.Count)
            {
                for (int j = 0; j < 3; j++)
                {
                    k++;
                    if (k < listq.Count)
                    {

                        Button btn = new Button()
                        {
                            Width = cons.table_wight,
                            Height = cons.table_heigh,
                            Location = new Point(X, Y),
                            Text = listq[k].TenBan + "\n" + listq[k].Vitri,
                            Name = listq[k].MaBan
                        };
                        if (listq[k].TrangThai == 1)
                        {
                            btn.BackColor = Color.Yellow;
                        }
                        else if (listq[k].TrangThai != 1)
                        {
                            btn.BackColor = Color.GreenYellow;
                        }
                         btn.Click += Btn_Click;

                        panelBan.Controls.Add(btn);
                        //cap nhat X
                        X = X + cons.table_wight + 20;

                    }
                    else
                    {
                        break;
                    }

                }

                //cap nhat X, Y
                X = 0;
                Y = Y + cons.table_heigh + 20;

            }
        }

        public async void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ImageList imlist = new ImageList();
            //imlist.Images.Add("pic1", Image.FromFile(@"~\Image\dinner-3.jpg"));
            //imlist.Images.Add("pic2", Image.FromFile(@"~\Image\breakfast-7.jpg"));
            //imlist.Images.Add("pic3", Image.FromFile(@"~\Image\dinner-1.jpg"));
            //imlist.Images.Add("pic4", Image.FromFile(@"~\Image\dinner-2.jpg"));
            //imlist.Images.Add("pic5", Image.FromFile(@"~\Image\dinner-4.jpg"));
            //imlist.Images.Add("pic6", Image.FromFile(@"~\Image\dinner-3.jpg"));
            // var hoadon = await hd.GetHD(btn.Name);
            var monan = await nb.GetMonAn(btn.Name);
            listView1.Columns.Add("Ảnh Và Tên Món Ăn đã gọi", 210);
            listView1.Columns.Add("Số Lượng", 80);
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
                        listView1.Items.Add(item);
                        ListViewItem.ListViewSubItem subitem1 = new ListViewItem.ListViewSubItem(item, (monan[j].SoLuong.ToString()));
                        item.SubItems.Add(subitem1);
                        //ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, (hoadon[j].GiaMon.ToString()));
                        //item.SubItems.Add(subitem);
                        listView1.Controls.Add( bt );
                        
                    }
                    else
                    {

                        break;
                    }

                }

            }
            //double tong = 0;

            //for (int i = 0; i < listView1.Items.Count; i++)
            //{
            //    string s = listView1.Items[i].SubItems[2].Text;
            //    tong += Convert.ToDouble(s);
            //}
            //ListViewItem g = new ListViewItem("Tổng Tiền");
            //g.SubItems.Add(" ");
            //g.SubItems.Add(tong.ToString());
            //listView1.Items.Add(g);

        }
    }

        public class cons
        {
            public static int table_wight = 60;
            public static int table_heigh = 60;
            public static int usecontrol_height = 60;
            public static int usecontrol_wightt = 150;
        }
    }

