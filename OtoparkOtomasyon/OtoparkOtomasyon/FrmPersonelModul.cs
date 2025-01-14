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
    public partial class FrmPersonelModul : DevExpress.XtraEditors.XtraForm
    {
        public FrmPersonelModul()
        {
            InitializeComponent();
        }
        FrmOtoparkDurum frm4;
        FrmMusteri frm5;
        FrmAyarlarPrsnl frm6;
        FrmGiris frm7;
        private void BtnOtoparkDurum2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new FrmOtoparkDurum();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }

        private void BtnMusterıler2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new FrmMusteri();
                frm5.MdiParent = this;
                frm5.Show();
            }
        }

        private void BtnAyarlar2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm6 == null || frm6.IsDisposed)
            {
                frm6 = new FrmAyarlarPrsnl();
                frm6.MdiParent = this;
                frm6.Show();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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