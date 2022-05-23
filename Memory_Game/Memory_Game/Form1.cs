using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game
{
    public partial class Form1 : Form
    {
        Image[] resimler = {
            Properties.Resources.Agent,
            Properties.Resources.Dinoco,
            Properties.Resources.Ramirez,
            Properties.Resources.F1,
            Properties.Resources.IDK_his_name,
            Properties.Resources.Lightning,
            Properties.Resources.Sally,
            Properties.Resources.Matter,


        };
        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        PictureBox firstbox;
        int ilkIndex, bulunan, deneme;
        public Form1()
        {
            InitializeComponent();
        }
        private void resimlerikaristir()
        {
            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                int sayi = rnd.Next(16);
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;
                
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuNo = int.Parse(kutu.Name.Substring(10));
            int indeksNo = indeksler[kutuNo-1];
            kutu.Image = resimler[indeksNo];
            kutu.Refresh();

            if (firstbox == null)
            {
                firstbox = kutu;
                ilkIndex = indeksNo;
                deneme++;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                firstbox.Image = null;
                kutu.Image = null;
                if (ilkIndex == indeksNo)
                {
                    bulunan++;
                    firstbox.Visible = false;
                    kutu.Visible = false;

                    if (bulunan == 8)
                    {
                        MessageBox.Show("Congratulations!!" + deneme + " times you try.");
                        bulunan = 0;
                        deneme = 0;
                        foreach (Control control in Controls)
                        {
                            control.Visible = true;
                        }
                        resimlerikaristir();
                    }
                }
                firstbox = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resimlerikaristir();
        }
    }
}
