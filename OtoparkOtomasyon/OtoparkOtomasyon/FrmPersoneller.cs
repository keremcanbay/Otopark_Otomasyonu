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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_PERSONEL", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void ilekle()
        {
            SqlCommand komut = new SqlCommand("Select * from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTC.Text = "";
            MskTelefon.Text = "";
            TxtMail.Text = "";
            cmbil.Text = "";
            RchAdres.Text = "";
            MskMaas.Text = "";
            MskCalısmaSaatlerı.Text = "";
            PcrResim.ImageLocation = "";
        }


        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            listele();
            ilekle();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONEL (PRSNLAD,PRSNLSOYAD,PRSNLTC,PRSNLTEL,PRSNLMAIL,PRSNLIL,PRSNLADRES,PRSNLMAAS,PRSNLCALISMASAATI,PRSNLFOTO) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@P10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTC.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbil.Text);
            komut.Parameters.AddWithValue("@p7", RchAdres.Text);
            komut.Parameters.AddWithValue("@p8", MskMaas.Text);
            komut.Parameters.AddWithValue("@p9", MskCalısmaSaatlerı.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("PERSONEL BAŞARIYLA EKLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                TxtId.Text = dr["PRSNLID"].ToString();
                TxtAd.Text = dr["PRSNLAD"].ToString();
                TxtSoyad.Text = dr["PRSNLSOYAD"].ToString();
                MskTC.Text = dr["PRSNLTC"].ToString();
                MskTelefon.Text = dr["PRSNLTEL"].ToString();
                TxtMail.Text = dr["PRSNLMAIL"].ToString();
                cmbil.Text = dr["PRSNLIL"].ToString();
                RchAdres.Text = dr["PRSNLADRES"].ToString();
                MskMaas.Text = dr["PRSNLMAAS"].ToString();
                MskCalısmaSaatlerı.Text = dr["PRSNLCALISMASAATI"].ToString();
                yeniyol = "C:\\Users\\yigit\\source\\repos\\OtoparkOtomasyon\\OtoparkOtomasyon" + "\\resimler\\" + dr["PRSNLFOTO"].ToString();
                PcrResim.ImageLocation = yeniyol;
            }
        }

        public string yeniyol;
        private void BtnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg; *png; *nef | Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            yeniyol = "C:\\Users\\yigit\\source\\repos\\OtoparkOtomasyon\\OtoparkOtomasyon" + "\\resimler\\" + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(dosyayolu, yeniyol);
            PcrResim.ImageLocation = yeniyol;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_PERSONEL set PRSNLAD=@p1,PRSNLSOYAD=@p2,PRSNLTC=@p3,PRSNLTEL=@p4,PRSNLMAIL=@p5,PRSNLIL=@p6,PRSNLADRES=@p7,PRSNLMAAS=@p8,PRSNLCALISMASAATI=@p9,PRSNLFOTO=@p10 where PRSNLID=@p11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTC.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", TxtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbil.Text);
            komut.Parameters.AddWithValue("@p7", RchAdres.Text);
            komut.Parameters.AddWithValue("@p8", MskMaas.Text);
            komut.Parameters.AddWithValue("@p9", MskCalısmaSaatlerı.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p11", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("PERSONEL BAŞARIYLA GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_PERSONEL where PRSNLID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("PERSONEL BAŞARIYLA SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
