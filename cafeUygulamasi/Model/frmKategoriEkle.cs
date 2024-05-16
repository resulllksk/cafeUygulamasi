using System;
using System.Collections;
using System.Windows.Forms;

namespace cafeUygulamasi.Model
{
    public partial class frmKategoriEkle : SampleAdd
    {
        public frmKategoriEkle()
        {
            InitializeComponent();
        }

        public  int id = 0;

        // btnSave_Click metodu, SampleAdd sınıfında tanımlanan metodun üzerine yazıldı
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            
            if (id == 0)

            {
                qry = "Insert into category Values(@Name)";
            }
            else
            {
                qry = "Update category Set catName = @Name where catID = @id ";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);

            if (MainClass.SQL(qry, ht) > 0)
            {
                if (guna2MessageDialog1 != null)
                    guna2MessageDialog1.Show("Kayıt Başarılı..");
                id = 0;
                txtName.Text = "";
                txtName.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
