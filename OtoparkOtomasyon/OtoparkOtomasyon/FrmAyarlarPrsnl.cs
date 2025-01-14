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
    public partial class FrmAyarlarPrsnl : Form
    {
        public FrmAyarlarPrsnl()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        public string yeniyol;
        void listele2()
        {
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Execute AyarlarMusteriler", bgl.baglanti());
            da3.Fill(dt3);
            gridControl2.DataSource = dt3;
        }

        void temizle2()
        {
            TxtMstrId.Text = "";
            TxtMstrSifre.Text = "";
            MskMstrTc.Text = "";
            pictureEdit2.Text = "";
            lookUpEdit2.Properties.NullText = "Müşteri Seçiniz";
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
        private void BtnMstrTemizle_Click(object sender, EventArgs e)
        {
            temizle2();
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
                yeniyol = "C:\\Users\\yigit\\source\\repos\\OtoparkOtomasyon\\OtoparkOtomasyon" + "\\resimler\\" + dr7["MSTRFOTO"].ToString();
                pictureEdit2.Image = Image.FromFile(yeniyol);


            }
            bgl.baglanti().Close();
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
                yeniyol = "C:\\Users\\yigit\\source\\repos\\OtoparkOtomasyon\\OtoparkOtomasyon" + "\\resimler\\" + dr6["MSTRFOTO"].ToString();
                pictureEdit2.Image = Image.FromFile(yeniyol);


            }


        }

        private void FrmAyarlarPrsnl_Load(object sender, EventArgs e)
        {
            listele2();
            müşterillistesi();
            temizle2();
        }
    }
}
