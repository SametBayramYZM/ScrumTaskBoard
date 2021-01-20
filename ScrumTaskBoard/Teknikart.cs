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
using System.Data.Odbc;
using System.Data.OleDb;

namespace ScrumTaskBoard
{
    public partial class Teknik_kart : Form
    {
        public Teknik_kart()
        {
            InitializeComponent();
        }

        private void teknik_kart_Load(object sender, EventArgs e)
        {
            dtp_date.Format = DateTimePickerFormat.Custom;
        }

        //Yeniş iş kayıdı eklendiğinde tabloya işler
        public void dataguncelle()
        {
            int kartno = Convert.ToInt32(txb_kartno.Text);
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-CGCP4D7;Initial Catalog=teknikkart;Integrated Security=True");
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Tarih,Durum,Yapilacak_is,Aciklama FROM istakibi Where kartno=" + kartno, baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            dgv_yapilacakis.DataSource = tablo;
            baglanti.Close();
        }

        //İş takibi ekle butonuna basıldığında yeni iş tabiki ekler
        private void btn_istakipekle_Click(object sender, EventArgs e)
        {
            Dataislem istakip = new Dataislem();
            int kartno = Convert.ToInt32(txb_kartno.Text);
            string tarih, durum, yapilacak_is, aciklama;
            tarih = dtp_ypisdate.Text.ToString();
            durum = cmb_ypisdurum.Text.ToString();
            yapilacak_is = tbx_ypis.Text.ToString();
            aciklama = tbx_ypisaciklama.Text.ToString();
            istakip.Istakibiekle(kartno, tarih, durum, yapilacak_is, aciklama);
            dataguncelle();


        }
        //Tüm verileri sql dosyasına kaydeder
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            int kartno, tahminisure, gerceklesensure, projeno;
            string tarih, teknikuzman, isinaciklamasi, notlar;
            try
            {
                kartno = Convert.ToInt32(txb_kartno.Text);
                projeno = Convert.ToInt32(txb_projeno.Text);
                teknikuzman = tbx_teknikuzman.Text.ToString();
                tarih = dtp_date.Text.ToString();
                tahminisure = Convert.ToInt32(txb_tahminisure.Text);
                gerceklesensure = Convert.ToInt32(txb_gerceksure.Text);
                isinaciklamasi = txb_isinaciklamasi.Text.ToString();
                notlar = txb_isnotu.Text.ToString();
                Dataislem kaydet = new Dataislem();
                kaydet.Sqlkaydet(kartno, projeno, teknikuzman, tarih, tahminisure, gerceklesensure, isinaciklamasi, notlar);
                MessageBox.Show("Kayıt Başarılı");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Hatalı değer girdiniz Lütfen değerleri kontrol ediniz");
            }

        }
    }
}
