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

namespace OtoparkOtomasyon
{
    public partial class FrmNufusCuzdanı : DevExpress.XtraEditors.XtraForm
    {
        public FrmNufusCuzdanı()
        {
            InitializeComponent();
        }

        public string ad, soyad, tc, cinsiyet, dogtarihi, uzanti;

        private void FrmNufusCuzdanı_Load(object sender, EventArgs e)
        {
            LblAd.Text = ad;
            LblSoyad.Text = soyad;
            LblTC.Text = tc;
            LblCınsıyet.Text = cinsiyet;
            LblDogumTarıhı.Text = dogtarihi;
            pictureEdit1.Image = Image.FromFile(uzanti);
        }
    }
}