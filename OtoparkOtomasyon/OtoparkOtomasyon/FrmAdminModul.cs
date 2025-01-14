using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OtoparkOtomasyon
{
    public partial class FrmAdminModul : DevExpress.XtraEditors.XtraForm
    {
        public FrmAdminModul()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        FrmPersoneller frm1;
        FrmMusteri frm2;
        FrmOtoparkDurum frm3;
        FrmAyarlar frm6;
        FrmGiris frm7;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm1 == null || frm1.IsDisposed)
            {
                frm1 = new FrmPersoneller();
                frm1.MdiParent = this;
                frm1.Show();
            }


        }

      

        private void BtnMusteriler_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new FrmMusteri();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }

        private void BtnOtoparkDurumu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new FrmOtoparkDurum();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }

        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm6 == null || frm6.IsDisposed)
            {
                frm6 = new FrmAyarlar();
                frm6.MdiParent = this;
                frm6.Show();
            }
        }

        private void BtnCıkıs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm7 == null || frm7.IsDisposed)
            {
                this.Close();
                frm7 = new FrmGiris();
                frm7.MdiParent = null;
                frm7.Show();
                
                
            }
            
        }
    }
}
 