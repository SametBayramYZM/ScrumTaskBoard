using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ScrumTaskBoard
{
    public partial class TaskBoard : Form
    {
        public TaskBoard()
        {
            InitializeComponent();
        }
        public int kartno;
        private void TaskBoard_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f5");
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-CGCP4D7;Initial Catalog=teknikkart;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT kartno,tarih,durum,yapilacak_is,aciklama FROM istakibi WHERE kartno=" + kartno;
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader oku;
            oku = komut.ExecuteReader();
            int durumno = 0;
            int[] sayac = { 0, 0, 0, 0, 0 };
            while (oku.Read())
            {
                this.WindowState = FormWindowState.Maximized;
                string tarih = oku["tarih"].ToString();
                string durum = oku["durum"].ToString();
                string yapilacak_is = oku["yapilacak_is"].ToString();
                string aciklama = oku["aciklama"].ToString();

                switch (durum)
                {
                    case "Yapılacak":
                        durumno = 0;
                        break;
                    case "Beklemede":
                        durumno = 1;
                        break;
                    case "Gözden Geçirme":
                        durumno = 2;
                        break;
                    case "Kontrol":
                        durumno = 3;
                        break;
                    case "Bitmiş":
                        durumno = 4;
                        break;
                    default:
                        MessageBox.Show("Bir hata oluştu");
                        break;
                }
                Label lbl = new Label();
                lbl.AutoSize = false;
                lbl.Text = "Tarih:\n  " + "\n\t" + tarih +
                    "\n\nYapılacak iş:\n" + "\n\t" + yapilacak_is +
                    "\n\nAçıklama:\n" + "\n\t" + aciklama;
                lbl.Name = "sayac" + sayac;
                lbl.Size = new Size(270, 220);
                lbl.Location = new Point(275 * durumno, (sayac[durumno] * 230) + 100);
                lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                lbl.BackColor = System.Drawing.ColorTranslator.FromHtml("#e0e0eb");
                Controls.Add(lbl);
                sayac[durumno]++;
            }
            baglanti.Close();
            string[] baslik = { "Yapılacaklar", "Beklemedekiler", "Gözden Geçirilecekler", "Kontrol Aşamasındakiler", "Bitenler" };

            for (int i = 0; i < 5; i++)
            {
                Label baslk = new Label();
                baslk.AutoSize = false;
                baslk.Text = baslik[i];
                baslk.Name = "baslk" + i.ToString();
                baslk.Size = new Size(150, 70);
                baslk.Location = new Point(85 + (270 * i), 45);
                Controls.Add(baslk);
            }



        }
    }
}
