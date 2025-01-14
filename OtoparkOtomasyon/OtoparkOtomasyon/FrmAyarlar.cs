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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Execute AyarlarPersoneller", bgl.baglanti());
            da1.Fill(dt1);
            gridControl1.DataSource = dt1; 
        }

        void listele2()
        {
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Execute AyarlarMusteriler", bgl.baglanti());
            da3.Fill(dt3);
            gridControl2.DataSource = dt3;
        }

        void temizle()
        {
            TxtPrsnlId.Text = "";
            TxtPrsnlSifre.Text = "";
            MskPrsnlTc.Text = "";
            lookUpEdit1.Properties.NullText = "Personel Seçiniz";
        }

        void temizle2()
        {
            TxtMstrId.Text = "";
            TxtMstrSifre.Text = "";
            MskMstrTc.Text = "";
            pictureEdit2.Text = "";
            lookUpEdit2.Properties.NullText = "Müşteri Seçiniz";
        }
        void personellistesi()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select PRSNLID,(PRSNLAD+' '+PRSNLSOYAD) as 'PRSNLADSOYAD' from TBL_PERSONEL", bgl.baglanti());
            da2.Fill(dt2);
            lookUpEdit1.Properties.ValueMember = "PRSNLID";
            lookUpEdit1.Properties.DisplayMember = "PRSNLADSOYAD";
            lookUpEdit1.Properties.NullText = "Personel Seçiniz";
            lookUpEdit1.Properties.DataSource = dt2;
        }

        void müşterillistesi()
        {
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Select MSTRID,(MSTRAD+' '+MSTRSOYAD) as 'MSTRADSOYAD' from TBL_MUSTERI", bgl.baglanti());
            da4.Fill(dt4);
            lookUpEdit2.Properties.ValueMember = "MSTRID";
            lookUpEdit2.Properties.DisplayMember = "MSTRADSOYAD";
            lookUpEdit2.Properties.NullText = "Müşteri Seçiniz";
            lookUpEdit2.Properties.DataSource = dt4;
        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            personellistesi();
            temizle();
            listele2();
            müşterillistesi();
            temizle2();
        }

        public string yeniyol;
        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtPrsnlId.Text = dr["AYARLARPRSNLID"].ToString();
                lookUpEdit1.Text = dr["PRSNLADSOYAD"].ToString();
                MskPrsnlTc.Text = dr["PRSNLTC"].ToString();
                TxtPrsnlSifre.Text = dr["PRSNLSIFRE"].ToString();
               
            }
        }

        private void lookUpEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            TxtPrsnlSifre.Text = "";
            SqlCommand komut = new SqlCommand("Select * from TBL_PERSONEL where PRSNLID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lookUpEdit1.ItemIndex + 1);
            SqlDataReader dr3 = komut.ExecuteReader(); 
            while (dr3.Read())
            {
                TxtPrsnlId.Text = dr3["PRSNLID"].ToString();
                MskPrsnlTc.Text = dr3["PRSNLTC"].ToString();
               

            }
            bgl.baglanti().Close();
        }

        private void BtnPrsnlKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBL_PRSNLAYARLAR (AYARLARPRSNLID,PRSNLSIFRE) values(@p1,@p2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", TxtPrsnlId.Text);
            komut2.Parameters.AddWithValue("@p2", TxtPrsnlSifre.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnPrsnlGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("Update TBL_PRSNLAYARLAR set PRSNLSIFRE=@p1 where AYARLARPRSNLID=@p2", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", TxtPrsnlSifre.Text);
            komut3.Parameters.AddWithValue("@p2", TxtPrsnlId.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void BtnPrsnlTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr6 = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr6 != null)
            {
                TxtMstrId.Text = dr6["AYARLARMSTRID"].ToString();
                lookUpEdit2.Text = dr6["MSTRADSOYAD"].ToString();
                MskMstrTc.Text = dr6["MSTRTC"].ToString();
                TxtMstrSifre.Text = dr6["MSTRSIFRE"].ToString();
                yeniyol= "C:\\Users\\yigit\\source\\repos\\OtoparkOtomasyon\\OtoparkOtomasyon" + "\\resimler\\" + dr6["MSTRFOTO"].ToString();
                pictureEdit2.Image = Image.FromFile(yeniyol);


            }
        }

        private void lookUpEdit2_Properties_EditValueChanged(object sender, EventArgs e)
        {
            TxtMstrSifre.Text = "";
            SqlCommand komut4 = new SqlCommand("Select * from TBL_MUSTERI where MSTRID=@p1", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", lookUpEdit2.ItemIndex + 1);
            SqlDataReader dr7 = komut4.ExecuteReader();
            while (dr7.Read())
            {
                TxtMstrId.Text = dr7["MSTRID"].ToString();
                MskMstrTc.Text = dr7["MSTRTC"].ToString();
                yeniyol= "C:\\Users\\yigit\\source\\repos\\OtoparkOtomasyon\\OtoparkOtomasyon" + "\\resimler\\" + dr7["MSTRFOTO"].ToString();
                pictureEdit2.Image = Image.FromFile(yeniyol);


            }
            bgl.baglanti().Close();
        }

        private void BtnMstrKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut5 = new SqlCommand("insert into TBL_MSTRAYARLAR (AYARLARMSTRID,MSTRSIFRE) values(@p1,@p2)", bgl.baglanti());
            komut5.Parameters.AddWithValue("@p1", TxtMstrId.Text);
            komut5.Parameters.AddWithValue("@p2", TxtMstrSifre.Text);
            komut5.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele2();
        }

        private void BtnMstrGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut6 = new SqlCommand("Update TBL_MSTRAYARLAR set MSTRSIFRE=@p1 where AYARLARMSTRID=@p2", bgl.baglanti());
            komut6.Parameters.AddWithValue("@p1", TxtMstrSifre.Text);
            komut6.Parameters.AddWithValue("@p2", TxtMstrId.Text);
            komut6.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele2();
        }

        private void BtnMstrTemizle_Click(object sender, EventArgs e)
        {
            temizle2();
        }
    }
}
