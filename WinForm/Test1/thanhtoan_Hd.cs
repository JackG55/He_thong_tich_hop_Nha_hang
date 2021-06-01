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
                for (int j = 0; j <= 3; j++)
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
                k++;
                oldbtn.Location = new Point(0, oldbtn.Location.Y + cons.table_heigh + 10);
                oldbtn.Width = 0;
                //oldbtn.Height = 0;

            }
        }

        public async void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var hoadon = await hd.GetHD(btn.Name);
            for(int i=0;i<hoadon.Count;i++)
            {
                label2.Text = hoadon[i].TenMonAn.ToString()  + hoadon[i].GiaMon.ToString() ;
              
               
            }    

        }
    }


    public class cons
    {
        public static int table_wight = 60;
        public static int table_heigh = 60;
    }
}

