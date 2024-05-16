using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace cafeUygulamasi.Model
{
    public partial class frmUrunEkle : SampleAdd
    {
        public frmUrunEkle()
        {
            InitializeComponent();
        }

        public int id = 0;
        public int cID = 0;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //cb doldurma

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png)|* .png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtImage.Image = new Bitmap(filePath);
            }

           
        }

        string filePath;
        Byte[] imageByteArray;
        private void frmUrunEkle_Load(object sender, EventArgs e)
        {
            string qry = "Select catID 'id' , catName 'name' from category ";
            MainClass.CBFill(qry, cbCat);
            if (cID > 0)
            {
                cbCat.SelectedValue = cID;
            }

            if (id > 0)
            {
                ForUpdateLoadData();
            }

        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)

            {
                qry = "Insert into urunler Values(@Name, @price, @cat, @img)";
            }
            else
            {
                qry = "Update urunler Set pName = @Name , pPrice = @price , CategoryID = @cat , pImage = @img where pID = @id ";
            }

            //image için
            Image temp = new Bitmap(txtImage.Image);
            MemoryStream ms = new MemoryStream();
            temp.Save(ms,System.Drawing.Imaging.ImageFormat.Png);
            imageByteArray = ms.ToArray();

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@price", txtPrice.Text);
            ht.Add("@cat", Convert.ToInt32(cbCat.SelectedValue));
            ht.Add("@img", imageByteArray);


            if (MainClass.SQL(qry, ht) > 0)
            {
                if (guna2MessageDialog1 != null)
                    guna2MessageDialog1.Show("Kayıt Başarılı..");
                id = 0;
                cID = 0;
                txtName.Text = "";
                txtPrice.Text = "";
                cbCat.SelectedIndex = 0;
                cbCat.SelectedIndex = -1;
                txtImage.Image = cafeUygulamasi.Properties.Resources.kasikCatal1;
                txtName.Focus();
            }
        }
        private void ForUpdateLoadData()
        {
            string qry = @"Select * from urunler where pID = " + id + "";
            SqlCommand cmd = new SqlCommand(qry,MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);    
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count>0)
            {
                txtName.Text = dt.Rows[0]["pName"].ToString();
                txtPrice.Text = dt.Rows[0]["pPrice"].ToString();

                Byte[] imageArray = (byte[])(dt.Rows[0]["pImage"]);
                byte[] imageByteArray = imageArray;
                txtImage.Image = Image.FromStream(new MemoryStream(imageArray));

            }
        }
    }
}
