using Guna.UI.WinForms;
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
    public partial class frmTableSelect : Form
    {
        public frmTableSelect()
        {
            InitializeComponent();
        }

        public string TableName;

        private void frmTableSelect_Load(object sender, EventArgs e)
        {
            string qry = "Select * from tables";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            
            foreach (DataRow row in dt.Rows)
            {
                MessageBox.Show(row.ToString());
                //Guna.UI.WinForms.GunaButton b = new Guna.UI.WinForms.GunaButton();
                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.Text = row["tname"].ToString();
                b.Width = 510;
                b.Height = 50;


                b.Click += new EventHandler(b_Clik);
                flowLayoutPanel1.Controls.Add(b);



            }

        }
        private void b_Clik(object sender, EventArgs e)
        {
            TableName= (sender as /*Guna.UI.WinForms.GunaButton*/Guna.UI2.WinForms.Guna2Button).Text.ToString();
            this.Close();
        }
    }
}
