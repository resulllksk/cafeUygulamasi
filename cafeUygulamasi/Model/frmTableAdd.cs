﻿using System;
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
    public partial class frmTableAdd : SampleAdd
    {
        public frmTableAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            

            if (id == 0)
            {
                
                qry = "Insert into tables Values(@Name)";
            }
            else

            {
                qry = "Update tables Set tname = @Name where tid = @id ";
                
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
    }
}
