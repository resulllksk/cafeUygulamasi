using cafeUygulamasi.Model;
using cafeUygulamasi.View;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafeUygulamasi
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        static frmMain _obj;

        public static frmMain Instace
        {
            get { if (_obj == null) { _obj = new frmMain(); } return _obj; }
        }


        public void AddContorls(Form f)
        {
            centerPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            centerPanel.Controls.Add(f);
            f.Show();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
            _obj = this;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            AddContorls(new frmHome());
        }

        private void btnKategoriler_Click(object sender, EventArgs e)
        {
            AddContorls(new frmKategorilerView()); 
        }

        private void btnMasalar_Click(object sender, EventArgs e)
        {
            AddContorls(new frmTableVİew());
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            AddContorls(new frmPersonel());
        }

        private void btnUrunler_Click(object sender, EventArgs e)
        {
            AddContorls(new frmUrunlerView());
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            frmPos frm = new frmPos();
            frm.Show();
        }
    }
}
