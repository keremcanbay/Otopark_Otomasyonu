using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;

namespace OtoparkOtomasyon
{
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_MUSTERI", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void şehirekle()
        {
            SqlCommand komut = new SqlCommand("Select * from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbıl.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTC.Text = "";
            MskTel.Text = "";
            dateEdit1.Text = "";
            TxtMaıl.Text = "";
            cmbıl.Text = "";
            TxtPlaka.Text = "";
            RdBtnErkek.Checked = false;
            RdnBtnKadın.Checked = false;
            RchAdres.Text = "";
            pictureEdit1.Text = "";
        }

       
        public string cinsiyet;
        public string yeniyol;
        
        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            listele();
            şehirekle();
            temizle();
        }

        private void gridView1_FocusedRowObjectChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr["MSTRID"].ToString();
                TxtAd.Text = dr["MSTRAD"].ToString();
                TxtSoyad.Text = dr["MSTRSOYAD"].ToString();
                MskTC.Text = dr["MSTRTC"].ToString();
                MskTel.Text = dr["MSTRTEL"].ToString();
                dateEdit1.Text = dr["MSTRDGMTRH"].ToString();
                TxtMaıl.Text = dr["MSTRMAIL"].ToString();
                cmbıl.Text = dr["MSTRIL"].ToString();
                TxtPlaka.Text = dr["MSTRARACPLAKA"].ToString();
                if (dr["MSTRCINSIYET"].ToString() == "E")
                {
                    RdBtnErkek.Checked = true;
                }
                else
                {
                    RdnBtnKadın.Checked = true;
                }
                RchAdres.Text = dr["MSTRADRES"].ToString();
                yeniyol = "C:\\Users\\yigit\\source\\repos\\OtoparkOtomasyon\\OtoparkOtomasyon" + "\\resimler\\" + dr["MSTRFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);



            }
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERI (MSTRAD,MSTRSOYAD,MSTRTC,MSTRTEL,MSTRDGMTRH,MSTRMAIL,MSTRIL,MSTRARACPLAKA,MSTRCINSIYET,MSTRADRES,MSTRFOTO) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@P10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTC.Text);
            komut.Parameters.AddWithValue("@p4", MskTel.Text);
            komut.Parameters.AddWithValue("@p5", dateEdit1.Text);
            komut.Parameters.AddWithValue("@p6", TxtMaıl.Text);
            komut.Parameters.AddWithValue("@p7", cmbıl.Text);
            komut.Parameters.AddWithValue("@p8", TxtPlaka.Text);
            if (RdBtnErkek.Checked == true)
            {
                komut.Parameters.AddWithValue("@p9", cinsiyet = "E");
            }
            else
            {
                komut.Parameters.AddWithValue("@p9", cinsiyet = "K");
            }
            komut.Parameters.AddWithValue("@p10", RchAdres.Text);
            komut.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("MÜŞTERİ BAŞARIYLA EKLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnResimEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg; *png; *nef | Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            yeniyol = "C:\\Users\\yigit\\source\\repos\\OtoparkOtomasyon\\OtoparkOtomasyon" + "\\resimler\\" + Guid.NewGuid().ToString() + ".jpg";
            File.Copy(dosyayolu, yeniyol);
            pictureEdit1.Image = Image.FromFile(yeniyol);
        }

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_MUSTERI set MSTRAD=@p1,MSTRSOYAD=@p2,MSTRTC=@p3,MSTRTEL=@p4,MSTRDGMTRH=@p5,MSTRMAIL=@p6,MSTRIL=@p7,MSTRARACPLAKA=@p8,MSTRCINSIYET=@p9,MSTRADRES=@p10,MSTRFOTO=@p11 where MSTRID=@p12", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTC.Text);
            komut.Parameters.AddWithValue("@p4", MskTel.Text);
            komut.Parameters.AddWithValue("@p5", dateEdit1.EditValue);
            komut.Parameters.AddWithValue("@p6", TxtMaıl.Text);
            komut.Parameters.AddWithValue("@p7", cmbıl.Text);
            komut.Parameters.AddWithValue("@p8", TxtPlaka.Text);
            komut.Parameters.AddWithValue("@p9", RdBtnErkek.Checked ? "E" : "K");
            komut.Parameters.AddWithValue("@p10", RchAdres.Text);
            komut.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p12", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("MÜŞTERİ BİLGİLERİ BAŞARIYLA GÜNCELLENDİ ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_MUSTERI where MSTRID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("MÜŞTERİ BAŞARIYLA SİLİNDİ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnTemizle_Click_1(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            FrmNufusCuzdanı frm = new FrmNufusCuzdanı();

            if (dr != null)
            {
                frm.ad = dr["MSTRAD"].ToString();
                frm.soyad = dr["MSTRSOYAD"].ToString();
                frm.tc = dr["MSTRTC"].ToString();
                frm.cinsiyet = dr["MSTRCINSIYET"].ToString();
                frm.dogtarihi = dr["MSTRDGMTRH"].ToString();
                frm.uzanti = "C:\\Users\\yigit\\source\\repos\\OtoparkOtomasyon\\OtoparkOtomasyon" + "\\resimler\\" + dr["MSTRFOTO"].ToString();
            }
            frm.Show();
        }
    }
}
