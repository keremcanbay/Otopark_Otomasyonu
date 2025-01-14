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
using System.IO;

namespace OtoparkOtomasyon
{
    public partial class FrmOtoparkDurumMstr : Form
    {
        public FrmOtoparkDurumMstr()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            // -1.Kat için
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT PARKYERID, PARKYERAD, PARKYERKAT, PARKYERDURUM FROM TBL_PARKYER WHERE PARKYERKAT=-1", bgl.baglanti());
            da1.Fill(dt1);
            gridControl1.DataSource = dt1;


            // -2.Kat için
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT PARKYERID, PARKYERAD, PARKYERKAT, PARKYERDURUM FROM TBL_PARKYER WHERE PARKYERKAT=-2", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;


            // -3.Kat için
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("SELECT PARKYERID, PARKYERAD, PARKYERKAT, PARKYERDURUM FROM TBL_PARKYER WHERE PARKYERKAT=-3", bgl.baglanti());
            da3.Fill(dt3);
            gridControl3.DataSource = dt3;


        }

        private void RenkGuncelle()
        {
            try
            {
                for (int i = 1; i <= 84; i++) // PARKYERID 1'den 84'e kadar kontrol ediyoruz
                {
                    // Komut oluştur
                    SqlCommand komut = new SqlCommand("SELECT PARKYERDURUM FROM TBL_PARKYER WHERE PARKYERID = @id", bgl.baglanti());
                    komut.Parameters.AddWithValue("@id", i);



                    // Veriyi oku
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read()) // Veri varsa
                    {
                        string durum = dr["PARKYERDURUM"].ToString();

                        // İlgili butonu bul
                        Button btn = this.Controls.Find("button" + i, true).FirstOrDefault() as Button;
                        if (btn != null)
                        {
                            // Duruma göre renk ayarla
                            if (durum == "Boş")
                                btn.BackColor = Color.Lime; // Boş ise yeşil
                            else
                                btn.BackColor = Color.Red; // Dolu ise kırmızı
                        }
                    }

                    // Reader ve bağlantıyı kapat
                    dr.Close();
                    bgl.baglanti().Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bgl.baglanti().Close(); // Hata durumunda bağlantıyı kapat
            }
        }

        private void FrmOtoparkDurumMstr_Load(object sender, EventArgs e)
        {
            listele();
            RenkGuncelle();
        }
    }
}
