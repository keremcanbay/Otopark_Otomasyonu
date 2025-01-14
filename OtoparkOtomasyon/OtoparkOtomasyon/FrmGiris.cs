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

namespace OtoparkOtomasyon
{
    public partial class FrmGiris : DevExpress.XtraEditors.XtraForm
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("SELECT ADMINTC, ADMINSIFRE FROM TBL_ADMIN WHERE ADMINTC = @p1 AND ADMINSIFRE = @p2", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", MskTC.Text);
            komut3.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();

            if (dr3.Read()) // Eğer veri varsa
            {
                FrmAdminModul frmAdminModul = new FrmAdminModul();
                frmAdminModul.Show();
                this.Hide(); // Mevcut formu gizler
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MskTC.Text = "";
                TxtSifre.Text = "";
            }
            bgl.baglanti().Close();
            dr3.Close(); // DataReader'ı kapatıyoruz

        }

        private void BtnPersonel_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select PRSNLTC,PRSNLSIFRE from TBL_PRSNLAYARLAR inner join TBL_PERSONEL on TBL_PRSNLAYARLAR.AYARLARPRSNLID=TBL_PERSONEL.PRSNLID where PRSNLTC=@p1 and PRSNLSIFRE=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmPersonelModul frm1 = new FrmPersonelModul();
                frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MskTC.Text = "";
                TxtSifre.Text = "";
            }
            bgl.baglanti().Close();
        }

        private void BtnMusteri_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Select MSTRTC,MSTRSIFRE from TBL_MSTRAYARLAR inner join TBL_MUSTERI on TBL_MSTRAYARLAR.AYARLARMSTRID=TBL_MUSTERI.MSTRID where MSTRTC=@p1 and MSTRSIFRE=@p2", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", MskTC.Text);
            komut2.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();
            if (dr2.Read())
            {
                FrmMusteriModul frm2 = new FrmMusteriModul();
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı T.C. No veya Şifre");
                MskTC.Text = "";
                TxtSifre.Text = "";
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}