﻿using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class thanhtoan_Hd : Form
    {
        banan ban = new banan();
        Hoadon hd = new Hoadon();

        string ma_ban = "";
        double tong_tien = 0;

        public string rootFolder = "http://192.168.8.101:8080/Images/";
        public thanhtoan_Hd()
        {
            InitializeComponent();
            Connect();
        }


        public Stream GetImage(string imageName)
        {
            WebRequest request = WebRequest.Create(rootFolder + imageName);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            return stream;
        }
        IPEndPoint IP;
        Socket client;
        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("192.168.8.101"), 8080);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Thread listen = new Thread(loadban);
            listen.IsBackground = true;
            listen.Start();
        }
       
        private async void loadban()
        {
            panelBan.Controls.Clear();
           
            var listq = await ban.Getlist();
            int X = 0;
            int Y = 0;

            int k = -1;
            while (k < listq.Count)
            {
                for (int j = 0; j <3; j++)
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
                        if(listq[k].TrangThai == 1)
                        {
                            btn.BackColor = Color.Red;
                        }
                        else if(listq[k].TrangThai != 1){
                            btn.BackColor = Color.Green;
                        }
                        btn.Click += Btn_Click;

                        panelBan.Controls.Add(btn);
                        //cap nhat X
                        X = X + cons.table_wight + 20 ;

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

            ma_ban = btn.Name;
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Controls.Clear();

            ImageList imlist = new ImageList();

            if(btn.BackColor == Color.Red)
            {
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
                            imlist.Images.Add("pic " + j, Image.FromStream(GetImage(hoadon[j].HinhAnh)));
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
                

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    string s = listView1.Items[i].SubItems[2].Text;
                    tong_tien += Convert.ToDouble(s);
                }
                ListViewItem g = new ListViewItem("Tổng Tiền");
                g.SubItems.Add(" ");
                g.SubItems.Add(tong_tien.ToString());
                listView1.Items.Add(g);
            }
            else
            {
                MessageBox.Show("Ban này chưa có khách");
            }
   
           
           
        }


        public class cons
        {
            public static int table_wight = 60;
            public static int table_heigh = 60;
            public static int usecontrol_height = 60;
            public static int usecontrol_wightt = 150;
        }


        private void ThanhToan(Hoadon hoadon)
        {
            Hoadon hoadon1 = new Hoadon();

        }

        private async void btnthanhtoan_Click(object sender, EventArgs e)
        {
            //lấy ra mã bàn


            //truy vấn lấy ra mã hoá đơn
            var ma_hoa_don = await hd.Get_Ma_Hoa_Don(ma_ban);
            
            //tiến hành gọi api để thanh toán
          
            hd.ThanhToan(ma_hoa_don, Convert.ToInt32(tong_tien));

            MessageBox.Show("Thanh toán thành công","Thông báo",  MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadban();
            listView1.Controls.Clear();
            listView1.Items.Clear();
            listView1.Columns.Clear();

        }



    }
}


