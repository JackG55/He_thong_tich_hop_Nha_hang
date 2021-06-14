using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test1;
using Nha_Bep.Models;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace Nha_Bep
{
    public partial class Form1 : Form
    {
        banan ban = new banan();
        // Hoadon hd = new Hoadon();
        NhaBep nb = new NhaBep();
        public static string rootFolder = "http://192.168.8.100:44444/Images/";

        string maban = "";

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            loadban();
            Connect();
        }

        public static Stream GetImage(string imageName)
        {
            WebRequest request = WebRequest.Create(rootFolder + imageName);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            return stream;
        }


        private async void loadban()
        {
            panelBan.Controls.Clear();
            listView1.Items.Clear();
            listView1.Controls.Clear();
            listView1.Columns.Clear();

            var listq = await nb.Getlist();
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

            maban = btn.Name;

            listView1.Items.Clear();
            listView1.Controls.Clear();
            listView1.Columns.Clear();

            ImageList imlist = new ImageList();
            if(btn.BackColor == Color.Yellow)
            {
                
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
                            imlist.Images.Add("pic " + j, Image.FromStream(GetImage(monan[j].HinhAnh)));
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
            else
            {
                
                MessageBox.Show("Ban này không đặt gì");
            }
           

        }

        

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(listView1.SelectedItems[0].Tag.ToString());
            int ma_dat_mon = Convert.ToInt32(listView1.SelectedItems[0].Tag);
            nb.HoanThanhMon(ma_dat_mon);

            foreach(Socket item in clientList)
            {
                Send(item, maban);
            }    
           

            listView1.Items.Remove(listView1.SelectedItems[0]);
            
        
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLMonAn frmmonan = new QLMonAn();
            frmmonan.Show();
        }



        //socket
        /*
        * cần IP 
        * cần socket
        */
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;

        public void Connect()
        {
            clientList = new List<Socket>();

            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);


            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);


                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Parse("192.168.8.100"), 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }


            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        /// <summary>
        /// phân mảnh
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }


        /// <summary>
        /// ghép mảnh
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        public void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                    //string message = (string)Deserialize(data);
                    string maban = message.Substring(0, 1);
                    maban = maban + "         ";
                    Button btn = panelBan.Controls[maban] as Button;
                    btn.PerformClick();

                }

            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }


        }

        public void Send(Socket client, string ma_ban)
        {
            client.Send(Serialize(ma_ban));
            

        }

        public void Close()
        {
            server.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadban();
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





