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
    public class Dataislem
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-CGCP4D7;Initial Catalog=teknikkart;Integrated Security=True");
        public void Sqlbaglan()
        {
            baglanti.Open();
        }
        public void Sqlkapat()
        {
            baglanti.Close();
        }
        public void Sqlkaydet(int kartno, int projeno, string teknikuzman, string tarih,
            int tahminisure, int gerceklesensure, string isinaciklamasi, string notlar)
        {
            string sorgu = "INSERT INTO teknik(kartno,projeno,teknikuzman,tarih,tahminisure,gerceklesensure,isinaciklamasi,notlar)" +
             " VALUES (@kartno,@projeno,@teknikuzman,@tarih,@tahminisure,@gerceklesensure,@isinaciklamasi,@notlar) ";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kartno", kartno);
            komut.Parameters.AddWithValue("@projeno", projeno);
            komut.Parameters.AddWithValue("@teknikuzman", teknikuzman);
            komut.Parameters.AddWithValue("@tarih", tarih);
            komut.Parameters.AddWithValue("@tahminisure", tahminisure);
            komut.Parameters.AddWithValue("@gerceklesensure", gerceklesensure);
            komut.Parameters.AddWithValue("@isinaciklamasi", isinaciklamasi);
            komut.Parameters.AddWithValue("@notlar", notlar);

            baglanti.Open();
            try
            {
                komut.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Aynı kart numarasına sahip bir kart mevcut");
                throw;
            }
            baglanti.Close();
        }
        public void Istakibiekle(int kartno, string tarih, string durum, string yapilacak_is, string aciklama)
        {
            string sorgu = "INSERT INTO istakibi(kartno,tarih,durum,yapilacak_is,aciklama)" +
             " VALUES (@kartno,@tarih,@durum,@yapilacak_is,@aciklama) ";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kartno", kartno);
            komut.Parameters.AddWithValue("@tarih", tarih);
            komut.Parameters.AddWithValue("@durum", durum);
            komut.Parameters.AddWithValue("@yapilacak_is", yapilacak_is);
            komut.Parameters.AddWithValue("@aciklama", aciklama);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public void Guncelle(int kartno, int projeno, int tahminisure, int gerceklesensure,
            string tarih, string teknikuzman, string isinaciklamasi, string notlar)
        {
            string sorgu = "UPDATE teknik SET " +
                        "projeno=@projeno,tahminisure=@tahminisure,gerceklesensure=@gerceklesensure" +
                        ",tarih=@tarih,teknikuzman=@teknikuzman,isinaciklamasi=@isinaciklamasi,notlar=@notlar " +
                    "WHERE kartno=" + kartno;
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@projeno", projeno);
            komut.Parameters.AddWithValue("@tahminisure", tahminisure);
            komut.Parameters.AddWithValue("@gerceklesensure", gerceklesensure);
            komut.Parameters.AddWithValue("@tarih", tarih);
            komut.Parameters.AddWithValue("@teknikuzman", teknikuzman);
            komut.Parameters.AddWithValue("@isinaciklamasi", isinaciklamasi);
            komut.Parameters.AddWithValue("@notlar", notlar);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public void Islemsil(int id)
        {
            string sorgu = "DELETE FROM istakibi WHERE " +
                "id=@id";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", id);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void Kartsil(int kartno)
        {
            string sorgu = "DELETE FROM teknik WHERE " +
                "kartno=@kartno";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kartno", kartno);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            normalizasyon(kartno);
        }
        public void normalizasyon(int kartno)
        {
            string sorgu = "DELETE FROM istakibi WHERE " +
                "kartno=@kartno";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kartno", kartno);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıtlı kart ve kart numarasına bağlı işler silindi");
        }
    }
}
