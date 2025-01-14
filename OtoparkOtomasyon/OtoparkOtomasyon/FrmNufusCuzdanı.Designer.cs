namespace OtoparkOtomasyon
{
    partial class FrmNufusCuzdanı
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNufusCuzdanı));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.LblTC = new DevExpress.XtraEditors.LabelControl();
            this.LblSoyad = new DevExpress.XtraEditors.LabelControl();
            this.LblAd = new DevExpress.XtraEditors.LabelControl();
            this.LblDogumTarıhı = new DevExpress.XtraEditors.LabelControl();
            this.LblCınsıyet = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(68, 253);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(215, 261);
            this.pictureEdit1.TabIndex = 0;
            // 
            // LblTC
            // 
            this.LblTC.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTC.Appearance.Options.UseFont = true;
            this.LblTC.Location = new System.Drawing.Point(39, 180);
            this.LblTC.Name = "LblTC";
            this.LblTC.Size = new System.Drawing.Size(189, 34);
            this.LblTC.TabIndex = 1;
            this.LblTC.Text = "labelControl1";
            // 
            // LblSoyad
            // 
            this.LblSoyad.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblSoyad.Appearance.Options.UseFont = true;
            this.LblSoyad.Location = new System.Drawing.Point(349, 180);
            this.LblSoyad.Name = "LblSoyad";
            this.LblSoyad.Size = new System.Drawing.Size(189, 34);
            this.LblSoyad.TabIndex = 2;
            this.LblSoyad.Text = "labelControl2";
            // 
            // LblAd
            // 
            this.LblAd.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAd.Appearance.Options.UseFont = true;
            this.LblAd.Location = new System.Drawing.Point(349, 270);
            this.LblAd.Name = "LblAd";
            this.LblAd.Size = new System.Drawing.Size(189, 34);
            this.LblAd.TabIndex = 3;
            this.LblAd.Text = "labelControl3";
            // 
            // LblDogumTarıhı
            // 
            this.LblDogumTarıhı.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDogumTarıhı.Appearance.Options.UseFont = true;
            this.LblDogumTarıhı.Location = new System.Drawing.Point(349, 368);
            this.LblDogumTarıhı.Name = "LblDogumTarıhı";
            this.LblDogumTarıhı.Size = new System.Drawing.Size(189, 34);
            this.LblDogumTarıhı.TabIndex = 4;
            this.LblDogumTarıhı.Text = "labelControl4";
            // 
            // LblCınsıyet
            // 
            this.LblCınsıyet.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCınsıyet.Appearance.Options.UseFont = true;
            this.LblCınsıyet.Location = new System.Drawing.Point(583, 401);
            this.LblCınsıyet.Name = "LblCınsıyet";
            this.LblCınsıyet.Size = new System.Drawing.Size(189, 34);
            this.LblCınsıyet.TabIndex = 5;
            this.LblCınsıyet.Text = "labelControl5";
            // 
            // FrmNufusCuzdanı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(986, 607);
            this.Controls.Add(this.LblCınsıyet);
            this.Controls.Add(this.LblDogumTarıhı);
            this.Controls.Add(this.LblAd);
            this.Controls.Add(this.LblSoyad);
            this.Controls.Add(this.LblTC);
            this.Controls.Add(this.pictureEdit1);
            this.DoubleBuffered = true;
            this.Name = "FrmNufusCuzdanı";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNufusCuzdanı";
            this.Load += new System.EventHandler(this.FrmNufusCuzdanı_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl LblTC;
        private DevExpress.XtraEditors.LabelControl LblSoyad;
        private DevExpress.XtraEditors.LabelControl LblAd;
        private DevExpress.XtraEditors.LabelControl LblDogumTarıhı;
        private DevExpress.XtraEditors.LabelControl LblCınsıyet;
    }
}