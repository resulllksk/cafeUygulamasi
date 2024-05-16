using cafeUygulamasi.Model;
using System;
using System.Collections;
using System.Windows.Forms;

namespace cafeUygulamasi.View
{
    public partial class frmKategorilerView : SampleView
    {
        public frmKategorilerView()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            string qry = "Select * From category where catName like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, gunaDataGridView1, lb);
        }

        private void frmKategorilerView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmKategoriEkle frm = new frmKategoriEkle();

            // Açık bir form varsa, o formu sahip olarak belirtin
            //if (Application.OpenForms.Count > 0)
            //{
            //    frm.ShowDialog(Application.OpenForms[0]);
            //}
            //else
            //{
            //    // Eğer açık bir form yoksa, null geçirin
            //    frm.ShowDialog(null);
            //}
            MainClass.BlurBackGround(new frmKategoriEkle());

            GetData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gunaDataGridView1.Rows.Count)
            {
                if (guna2MessageDialog1 == null)
                {
                    guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
                }

                if (gunaDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
                {
                    

                    frmKategoriEkle frm = new frmKategoriEkle();
                    frm.id = Convert.ToInt32(gunaDataGridView1.CurrentRow.Cells["dgvid"].Value);
                    frm.txtName.Text = Convert.ToString(gunaDataGridView1.CurrentRow.Cells["dgvName"].Value);
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
                        string qry = "Delete from category where catID= " + id + "";
                        Hashtable ht = new Hashtable();
                        MainClass.SQL(qry, ht);

                        MessageBox.Show("silme başarılı");
                        GetData();
                    }
                    
                }
            }
        }

    }
}
