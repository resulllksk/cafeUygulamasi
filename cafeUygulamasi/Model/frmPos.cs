using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace cafeUygulamasi.Model
{
    public partial class frmPos : Form
    {
        public frmPos()
        {
            InitializeComponent();
            //birden çok ürün eklendiğinde çalışan fonksiyon
            gunaDataGridView1.CellValueChanged += new DataGridViewCellEventHandler(gunaDataGridView1_CellValueChanged);

        }

        public int MainID = 0;
        public string OrderType;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPos_Load(object sender, EventArgs e)
        {
            gunaDataGridView1.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();

            productPanel.Controls.Clear();
            LoadProducts();
            gunaDataGridView1.RowsAdded += new DataGridViewRowsAddedEventHandler(gunaDataGridView1_RowsAdded);

        }

        private void AddCategory()
        {
            string qry = "Select * from Category";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            categoryPanle.Controls.Clear();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(50, 55, 89);
                    b.Size = new Size(194, 48);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();

                    //event clik'ği
                    b.Click += new EventHandler(b_Clik);

                    categoryPanle.Controls.Add(b);
                }

            }

        }

        //ayrılan kategoriler
        private void b_Clik(object sender, EventArgs e)
        {
            foreach (var item in productPanel.Controls)
            {
                Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender; ;

                var pro = (usUrun)item;
                pro.Visible = pro.PCategory.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }

        private void AddItems(int id, string proID, string name, string cat, string price, Image pimage)
        {
            var w = new usUrun()
            {
                PName = name,
                PPrice = price,
                PCategory = cat,
                PImage = pimage,
                id = Convert.ToInt32(id)
            };

            productPanel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (usUrun)ss;

                foreach (DataGridViewRow item in gunaDataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvproID"].Value) == wdg.id)
                    {
                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) *
                                                        double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        return;
                    }

                }

                gunaDataGridView1.Rows.Add(new object[] {0, 0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                
            };
        }

        private void LoadProducts()
        {
            string qry = "Select * from urunler inner join category on catID = CategoryID";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                Byte[] imagearray = (byte[])item["pImage"];
                byte[] immagebytearray = imagearray;
                int productId = Convert.ToInt32(item["pID"]);

                AddItems(productId, "0", item["pName"].ToString(), item["catName"].ToString(),
                    item["pPrice"].ToString(), Image.FromStream(new MemoryStream(imagearray)));



            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in productPanel.Controls)
            {
                var pro = (usUrun)item;
                pro.Visible = pro.Name.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }

        private void gunaDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;

            foreach (DataGridViewRow row in gunaDataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void gunaDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Miktar sütunu güncellendiğinde çalışan foksiyon
            if (e.ColumnIndex == gunaDataGridView1.Columns["dgvAmount"].Index)
            {
                GetTotal();
            }
        }

        private void GetTotal()
        {
            double tot = 0;
            lblTop.Text = "";
            foreach (DataGridViewRow item in gunaDataGridView1.Rows)
            {
                tot += double.Parse(item.Cells["dgvAmount"].Value.ToString());


            }
            lblTop.Text= tot.ToString("N2");
        }

        //ürün'ü 1 adet eklediğinde çalışan foksiyon
        private void gunaDataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GetTotal();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            gunaDataGridView1.Rows.Clear();
            MainID = 0;
            lblTop.Text = "00";

        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Teslimat";
        }

        private void btnAlGotur_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Al Götür";
        }

        private void btnDinIn_Click(object sender, EventArgs e)
        {
            frmTableSelect frm = new frmTableSelect();
            MainClass.BlurBackGround(frm);
            if (frm.TableName != "")
            {
                lblTable.Text = frm.TableName;
                lblTable.Visible=true;
            }
            else
            {
                lblTable.Text = "";
                lblTable.Visible = false;

            }

            frmWaiterSelect frm2 = new frmWaiterSelect();
            MainClass.BlurBackGround(frm2);
            if (frm2.waiterName != "")
            {
                lblWaiter.Text = frm2.waiterName;
                lblWaiter.Visible = true;

            }
            else
            {
                lblWaiter.Text = "";
                lblWaiter.Visible = false;

            }
        }

        private void btnKot_Click(object sender, EventArgs e)
        {
            string qry1 = ""; //main tablo
            string qry2 = ""; //detail tablo

            int detailID = 0;
            if (MainID == 0) //insert kısmı
            {
                qry1 = @"Insert into tblMain valuse(@aDate, @aTime, @TableName, @WaiterName, 
                            @status, @orderType, @total, @received, @change);
                                    Select SCOPE_ODENTİTY()";
                //bu satır son eklenen kimlik değerini alacaktır
            }
            else //update
            {
                qry2 = @"Update tblMain set status = @status, total =  @total, 
                    received = @received, change = @change where MainID = @ID)";
            }

            Hashtable ht = new Hashtable();

            SqlCommand cmd = new SqlCommand(qry1,MainClass.con);
            cmd.Parameters.AddWithValue("@ID",MainID);
            cmd.Parameters.AddWithValue("@aDate",DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToLongTimeString());
            cmd.Parameters.AddWithValue("@TableName", lblTable.Text);
            cmd.Parameters.AddWithValue("@WaiterName", lblWaiter.Text);
            cmd.Parameters.AddWithValue("@status", "Pending");
            cmd.Parameters.AddWithValue("@orderType", OrderType);
            cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTop.Text)); //sadece mutfak için veri kaydettiğimizden ödeme alındığında değer güncellenecektir
            cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));

            if (MainClass.con.State == ConnectionState.Closed)
            {
                MainClass.con.Open();
            }
            if (MainID ==0)
            {
                MainID =Convert.ToInt32(cmd.ExecuteScalar());
            }
            else
            {
                cmd.ExecuteNonQuery();
            }
            if (MainClass.con.State == ConnectionState.Open)
            {
                MainClass.con.Close();
            }

            foreach (DataGridViewRow row in gunaDataGridView1.Rows)
            {
                detailID = Convert.ToInt32(row.Cells["dgvid"].Value);

                if (detailID ==0) //insert
                {
                    qry2 = @" Insert into tblDetails values(@MainId,@proID, @qty, @price, @amount";
                }
                else //update
                {
                    qry2 = @"update tblDetails set proID=@proID,qty =@qty, price = @price, amount = @amount
                                where DetailID = @ID";
                }
                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                cmd.Parameters.AddWithValue("@ID", detailID);
                cmd.Parameters.AddWithValue("@MainId", MainID);
                cmd.Parameters.AddWithValue("@proID", row.Cells["dgvproID"]);
                cmd.Parameters.AddWithValue("@qty", row.Cells["dgvQty"]);
                cmd.Parameters.AddWithValue("@price", row.Cells["dgvPrice"]);
                cmd.Parameters.AddWithValue("@amount", row.Cells["dgvAmount"]);


                if (MainClass.con.State == ConnectionState.Closed)
                {
                    MainClass.con.Open();
                }
                cmd2.ExecuteNonQuery();
                if (MainClass.con.State == ConnectionState.Open)
                {
                    MainClass.con.Close();
                }

                guna2MessageDialog1.Show("Kayıt Başaralı");
                MainID = 0;
                detailID = 0;
                gunaDataGridView1.Rows.Clear();
                lblTable.Text = "";
                lblWaiter.Text = "";
                lblTable.Visible = false;
                lblWaiter.Visible = false;
                lblTop.Text = "00";
            }

        }
    }
}
