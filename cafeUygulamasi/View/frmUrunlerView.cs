using cafeUygulamasi.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeUygulamasi.View
{
    public partial class frmUrunlerView : SampleView
    {
        public frmUrunlerView()
        {
            InitializeComponent();
        }

        private void frmUrunlerView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            string qry = "select pID,pName,pPrice,CategoryID,c.catName from urunler p inner join category c on c.catID = p.CategoryID where pName like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPrice);
            lb.Items.Add(dgvcatID);
            lb.Items.Add(dgvcat);

            MainClass.LoadData(qry, gunaDataGridView1, lb);
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackGround(new frmUrunEkle());

            GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gunaDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {


                frmUrunEkle frm = new frmUrunEkle();
                frm.id = Convert.ToInt32(gunaDataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.cID = Convert.ToInt32(gunaDataGridView1.CurrentRow.Cells["dgvcatID"].Value);
                
                
                //frm..Text = Convert.ToString(gunaDataGridView1.CurrentRow.Cells["dgvRole"].Value);
                MainClass.BlurBackGround(frm);
                GetData();
            }
            else if (gunaDataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                if (guna2MessageDialog1.Show("Silmek istediğine emin misin?") == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(gunaDataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "Delete from urunler where pID= " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);

                    MessageBox.Show("silme başarılı");
                    GetData();
                }

            }

        }
    }
}
