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
    public partial class FrmOtoparkDurum : Form
    {
        public FrmOtoparkDurum()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            // -1.Kat için
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from TBL_PARKYER where PARKYERKAT=-1", bgl.baglanti());
            da1.Fill(dt1);
            gridControl1.DataSource = dt1;

            // -2.Kat için
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from TBL_PARKYER WHERE PARKYERKAT=-2", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;

            // -3.Kat için
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from TBL_PARKYER where PARKYERKAT=-3", bgl.baglanti());
            da3.Fill(dt3);
            gridControl3.DataSource = dt3;


        }

        private void FrmOtoparkDurum_Load(object sender, EventArgs e)
        {

            listele();
            RenkGuncelle();
            timer1.Interval = 5000;
            timer1.Stop();
        }

        private void TxtPlaka_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPlaka.EditValue.ToString()))
            {
                timer1.Stop();  // Timer'ı durdur
                TxtAd.EditValue = "";   // Ad kutusunu temizle
                TxtSoyad.EditValue = ""; // Soyad kutusunu temizle
                TxtTelefon.EditValue = "";   // Telefon kutusunu temizle
            }
            else
            {
                timer1.Start();  // Timer'ı başlat
            }

            if (TxtPlaka.Text.Length == 0)
            {
                timer1.Stop();  // Timer'ı durdur
            }
            else
            {
                timer1.Start();  // Timer'ı başlat
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();  // Timer'ı durdur (çalıştıktan sonra durdurulmalı)

            string plaka = TxtPlaka.Text;
            if (plaka.Length > 0)
            {
                SqlCommand komut = new SqlCommand("SELECT MSTRAD, MSTRSOYAD, MSTRTEL FROM TBL_MUSTERI WHERE MSTRARACPLAKA = @plaka", bgl.baglanti());
                komut.Parameters.AddWithValue("@plaka", plaka);

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read()) // Veritabanında plaka varsa
                {
                    TxtAd.Text = dr["MSTRAD"].ToString();
                    TxtSoyad.Text = dr["MSTRSOYAD"].ToString();
                    TxtTelefon.Text = dr["MSTRTEL"].ToString();
                }
                else
                {

                    TxtAd.EditValue = "";   // Ad kutusunu temizle
                    TxtSoyad.EditValue = ""; // Soyad kutusunu temizle
                    TxtTelefon.EditValue = "";   // Telefon kutusunu temizle                    // Eğer plaka bulunmazsa uyarı ver
                    MessageBox.Show("BU PLAKA SAHİBİ BURAYA ÜYE DEĞİLDİR", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                bgl.baglanti().Close();
            }
        }

      

        private void BtnCıkıs_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. TxtParkYeriId'deki değeri int türüne çeviriyoruz.
                int parkYeriId;
                if (!int.TryParse(TxtParkYeriId.Text, out parkYeriId))
                {
                    MessageBox.Show("Lütfen geçerli bir Park Yeri ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. PARKYERID'ye göre ilgili satırı sorguluyoruz.
                SqlCommand komut = new SqlCommand("SELECT * FROM TBL_PARKYER WHERE PARKYERID = @parkYeriId", bgl.baglanti());
                komut.Parameters.AddWithValue("@parkYeriId", parkYeriId);

                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read()) // Veritabanından veri bulunduktan sonra işlemleri yapıyoruz.
                {
                    string parkYeriDurum = dr["PARKYERDURUM"].ToString();

                    if (parkYeriDurum == "Dolu")
                    {
                        // 3. PARKYERDURUM değerini "Boş" yapıyoruz ve diğer bilgileri silip boş bırakıyoruz.
                        dr.Close(); // Veriyi okuduktan sonra bağlantıyı kapatıyoruz.

                        SqlCommand guncelleKomut = new SqlCommand("UPDATE TBL_PARKYER SET PARKYERDURUM = 'Boş', " +
                                                                  "PARKYERMSTRAD = NULL, " +
                                                                  "PARKYERMSTRSOYAD = NULL, " +
                                                                  "PARKYERMSTRPLAKA = NULL, " +
                                                                  "PARKYERMSTRTEL = NULL " +
                                                                  "WHERE PARKYERID = @parkYeriId", bgl.baglanti());
                        guncelleKomut.Parameters.AddWithValue("@parkYeriId", parkYeriId);

                        guncelleKomut.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        MessageBox.Show("Park Yeri Başarıyla Boşaltıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 4. Eğer PARKYERDURUM "Boş" ise kullanıcıya uyarı veriyoruz.
                        MessageBox.Show("PARK YERİ ZATEN BOŞ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Veritabanında böyle bir park yeri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Girisss_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. TxtParkYeriId'deki değeri int türüne çeviriyoruz.
                int parkYeriId;
                if (!int.TryParse(TxtParkYeriId.Text, out parkYeriId))
                {
                    MessageBox.Show("Lütfen geçerli bir Park Yeri ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Plakaya göre Ad, Soyad ve Telefon bilgilerini alıyoruz.
                string plaka = TxtPlaka.Text;
                SqlCommand plakaSorgu = new SqlCommand("SELECT MSTRAD, MSTRSOYAD, MSTRTEL FROM TBL_MUSTERI WHERE MSTRARACPLAKA = @plaka", bgl.baglanti());
                plakaSorgu.Parameters.AddWithValue("@plaka", plaka);

                SqlDataReader plakaDr = plakaSorgu.ExecuteReader();
                if (plakaDr.Read())
                {
                    // Plaka sahibinin Ad, Soyad ve Telefon bilgilerini TextBox'lara yazdırıyoruz.
                    TxtAd.Text = plakaDr["MSTRAD"].ToString();
                    TxtSoyad.Text = plakaDr["MSTRSOYAD"].ToString();
                    TxtTelefon.Text = plakaDr["MSTRTEL"].ToString();
                }
                else
                {
                    MessageBox.Show("Bu plakaya ait kullanıcı bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Park yerini sorguluyoruz.
                SqlCommand komut = new SqlCommand("SELECT * FROM TBL_PARKYER WHERE PARKYERID = @parkYeriId", bgl.baglanti());
                komut.Parameters.AddWithValue("@parkYeriId", parkYeriId);

                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read()) // Veritabanından veri bulunduktan sonra işlemleri yapıyoruz.
                {
                    string parkYeriDurum = dr["PARKYERDURUM"].ToString();

                    if (parkYeriDurum == "Boş")
                    {
                        // 4. PARKYERDURUM değerini "Dolu" yapıyoruz ve diğer bilgileri ekliyoruz.
                        dr.Close(); // Veriyi okuduktan sonra bağlantıyı kapatıyoruz.

                        SqlCommand guncelleKomut = new SqlCommand("UPDATE TBL_PARKYER SET PARKYERDURUM = 'Dolu', " +
                                                                  "PARKYERMSTRAD = @ad, " +
                                                                  "PARKYERMSTRSOYAD = @soyad, " +
                                                                  "PARKYERMSTRPLAKA = @plaka, " +
                                                                  "PARKYERMSTRTEL = @telefon " +
                                                                  "WHERE PARKYERID = @parkYeriId", bgl.baglanti());
                        guncelleKomut.Parameters.AddWithValue("@ad", TxtAd.Text);
                        guncelleKomut.Parameters.AddWithValue("@soyad", TxtSoyad.Text);
                        guncelleKomut.Parameters.AddWithValue("@plaka", TxtPlaka.Text);
                        guncelleKomut.Parameters.AddWithValue("@telefon", TxtTelefon.Text);
                        guncelleKomut.Parameters.AddWithValue("@parkYeriId", parkYeriId);

                        guncelleKomut.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        MessageBox.Show("Park Yeri Başarıyla Dolduruldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // 5. Eğer PARKYERDURUM "Dolu" ise kullanıcıya uyarı veriyoruz.
                        MessageBox.Show("PARK YERİ ZATEN DOLU", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Veritabanında böyle bir park yeri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


    }

}
