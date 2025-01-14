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
    public partial class FrmMusteriModul : DevExpress.XtraEditors.XtraForm
    {
        public FrmMusteriModul()
        {
            InitializeComponent();
        }

        FrmOtoparkDurumMstr frm3;
        FrmGiris frm7;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new FrmOtoparkDurumMstr();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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