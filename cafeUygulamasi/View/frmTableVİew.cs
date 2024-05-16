using cafeUygulamasi.Model;
using System;
using System.Collections;
using System.Windows.Forms;

namespace cafeUygulamasi.View
{
    public partial class frmTableVİew : SampleView
    {
        // Guna2MessageDialog nesnesini form başında oluşturuyoruz
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();

        public frmTableVİew()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //BURASI BOŞ
        }

        private void frmTableVİew_Load(object sender, EventArgs e)
        {
            //tablo oluştur
            GetData();
        }

        public void GetData()
        {
            string qry = "Select * From tables where tName like '%" + txtSearch.Text + "%' ";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, gunaDataGridView1, lb);
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmTableAdd frm = new frmTableAdd();
            frm.ShowDialog();
            MainClass.BlurBackGround(new frmTableAdd());
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
                if (gunaDataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
                {
                    

                    frmTableAdd frm = new frmTableAdd();
                    frm.id = Convert.ToInt32(gunaDataGridView1.CurrentRow.Cells["dgvid"].Value);
                    frm.txtName.Text = Convert.ToString(gunaDataGridView1.CurrentRow.Cells["dgvName"].Value);
                    frm.ShowDialog();
                    GetData();
                }
                else if (gunaDataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
                {
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                    if (guna2MessageDialog1.Show("Silmek istediğine emin misin?") == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(gunaDataGridView1.CurrentRow.Cells["dgvid"].Value);
                        string qry = "Delete from tables where tid= " + id + "";
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
