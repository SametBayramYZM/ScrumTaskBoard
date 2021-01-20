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
    public partial class Teknikkartguncelleme : Form
    {
        public Teknikkartguncelleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-CGCP4D7;Initial Catalog=teknikkart;Integrated Security=True");
        public int kartno;

        private void dataguncelle()
        {
            baglanti.Open();
            SqlDataAdapter datayaz = new SqlDataAdapter("SELECT id,tarih,durum,yapilacak_is,aciklama FROM istakibi WHERE kartno=" + kartno, baglanti);
            DataTable istakip = new DataTable();
            datayaz.Fill(istakip);
            dataGridView.DataSource = istakip;
            baglanti.Close();
        }

        private void Teknikkartguncelleme_Load(object sender, EventArgs e)
        {
            txb_kartno.Text = kartno.ToString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT kartno,tarih,projeno,teknikuzman,tahminisure,gerceklesensure,isinaciklamasi,notlar FROM teknik WHERE kartno=" + kartno;
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader oku;
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txb_tarih.Text = oku["tarih"].ToString();
                txb_projeno.Text = oku["projeno"].ToString();
                tbx_teknikuzman.Text = oku["teknikuzman"].ToString();
                txb_tahminisure.Text = oku["tahminisure"].ToString();
                txb_gerceksure.Text = oku["gerceklesensure"].ToString();
                txb_isinaciklamasi.Text = oku["isinaciklamasi"].ToString();
                txb_isnotu.Text = oku["notlar"].ToString();
            }
            baglanti.Close();
            dataguncelle();
        }
        private void btn_istakipekle_Click(object sender, EventArgs e)
        {
            Dataislem ekle = new Dataislem();
            string tarih, durum, yapilacak_is, aciklama;
            tarih = dtp_ypisdate.Text.ToString();
            durum = cmb_ypisdurum.Text.ToString();
            yapilacak_is = tbx_ypis.Text.ToString();
            aciklama = tbx_ypisaciklama.Text.ToString();
            ekle.Istakibiekle(kartno, tarih, durum, yapilacak_is, aciklama);
            dataguncelle();
        }

        private void btn_degkaydet_Click(object sender, EventArgs e)
        {
            Dataislem islem = new Dataislem();
            string tarih = "", teknikuzman = "", isinaciklamasi = "", notlar = "";
            int projeno = 0, tahminisure = 0, gerceklesensure = 0;
            try
            {
                projeno = Convert.ToInt32(txb_projeno.Text);
                tahminisure = Convert.ToInt32(txb_tahminisure.Text);
                gerceklesensure = Convert.ToInt32(txb_gerceksure.Text);
                tarih = txb_tarih.Text.ToString();
                teknikuzman = tbx_teknikuzman.Text.ToString();
                isinaciklamasi = txb_isinaciklamasi.Text.ToString();
                notlar = txb_isnotu.Text.ToString();
                try
                {
                    islem.Guncelle(kartno, projeno, tahminisure, gerceklesensure, tarih, teknikuzman, isinaciklamasi, notlar);
                    MessageBox.Show("Güncelleme Tamamlandı");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("İşlem Başarısız");
                }
            }
            catch
            {
                MessageBox.Show("Lütfen Girdiğiniz Değerleri Kontrol ediniz");
            }
            


        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Dataislem sil = new Dataislem();
            int id;
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
            sil.Islemsil(id);
            dataguncelle();
        }
    }
}
