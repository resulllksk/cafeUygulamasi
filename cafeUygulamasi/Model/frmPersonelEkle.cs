using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeUygulamasi.Model
{
    public partial class frmPersonelEkle : SampleAdd
    {
        public frmPersonelEkle()
        {
            InitializeComponent();
        }
        public int id = 0;

        private void frmPersonelEkle_Load(object sender, EventArgs e)
        {

        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)

            {
                qry = "Insert into Staff Values(@Name, @phone, @role)";
            }
            else
            {
                qry = "Update Staff Set sName = @Name , sPhone = @phone , sRole = @role where staffID = @id ";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@phone", txtPhone.Text);
            ht.Add("@role", cbRole.Text);

            if (MainClass.SQL(qry, ht) > 0)
            {
                if (guna2MessageDialog1 != null)
                    guna2MessageDialog1.Show("Kayıt Başarılı..");
                id = 0;
                txtName.Text = "";
                txtPhone.Text = "";
                cbRole.SelectedIndex = -1;
                txtName.Focus();
            }
        }
    }
}
