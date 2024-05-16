using System;
using System.Windows.Forms;

namespace cafeUygulamasi
{
    public partial class SampleAdd : Form
    {
        public SampleAdd()
        {
            InitializeComponent();
        }

        private void SampleAdd_Load(object sender, EventArgs e)
        {
            // Yüklenme olayı için gereken kodları buraya ekleyin (opsiyonel)
        }

        // btnSave_Click metodu virtual olarak işaretlendi
        public virtual void btnSave_Click(object sender, EventArgs e)
        {
            // btnSave_Click olayı için gereken kodları buraya ekleyin (alt sınıflarda ezilecek)
        }

        // btnClose_Click metodu virtual olarak işaretlendi
        public virtual void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
