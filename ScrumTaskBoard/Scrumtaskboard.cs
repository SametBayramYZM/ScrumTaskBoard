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
    public partial class Scrumtaskboard : Form
    {
        public Scrumtaskboard()
        {
            InitializeComponent();
        }
        private void Takipguncelle()
        {
            //Databasedeki kayıtlı teknik kartları gösteren kısım
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-CGCP4D7;Initial Catalog=teknikkart;Integrated Security=True");
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT kartno,teknikuzman,projeno FROM teknik", baglanti);
            DataTable tablo = new DataTable();
            adapter.Fill(tablo);
            dataGridView.DataSource = tablo;
            baglanti.Close();
        }
        private void Scrumtaskboard_Load(object sender, EventArgs e)
        {
            Takipguncelle();
        }
        private void btn_kayit_Click(object sender, EventArgs e)
        {
            Teknik_kart teknikkart = new Teknik_kart();
            teknikkart.Show();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            int kartno = 0;
            if (tbx_kartno.Text.ToString() == "")
            {
                MessageBox.Show("Kart Numarası Boş alamaz");
            }
            else
            {
                kartno = Convert.ToInt32(tbx_kartno.Text);
                Teknikkartguncelleme teknikguncelle = new Teknikkartguncelleme();
                teknikguncelle.kartno = kartno;
                teknikguncelle.ShowDialog();
            }
        }
        private void btn_taskboard_Click(object sender, EventArgs e)
        {
            int kartno = 0;
            try
            {
                kartno = Convert.ToInt32(tbx_kartno.Text);
                TaskBoard yeni = new TaskBoard();
                yeni.kartno = kartno;
                yeni.Show();
            }
            catch
            {
                MessageBox.Show("Kart No Boş Kalamaz");
            }
            
        }
        private void btn_sil_Click(object sender, EventArgs e)
        {
            Dataislem sil = new Dataislem();
            int kartno;
            kartno = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
            sil.Kartsil(kartno);
            Takipguncelle();
        }
    }
}
