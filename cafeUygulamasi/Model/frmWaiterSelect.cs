using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeUygulamasi.Model
{
    public partial class frmWaiterSelect : Form
    {
        public frmWaiterSelect()
        {
            InitializeComponent();
        }
        public string waiterName;

        private void frmWaiterSelect_Load(object sender, EventArgs e)
        {
            MessageBox.Show("klsdfjakl");
            string qry = "Select * from staff where sRole  = 'Garson'";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            MessageBox.Show(dt.Rows.Count.ToString());
            foreach (DataRow row in dt.Rows)
            {
                MessageBox.Show(row.ToString());
                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.Text = row["sName"].ToString();
                b.Width = 150;
                b.Height = 50;


                b.Click += new EventHandler(b_Clik);
                flowLayoutPanel1.Controls.Add(b);


            }
        }
        private void b_Clik(object sender, EventArgs e)
        {
            waiterName = (sender as Guna.UI2.WinForms.Guna2Button).Text.ToString();
            this.Close();
        }

    }

}
