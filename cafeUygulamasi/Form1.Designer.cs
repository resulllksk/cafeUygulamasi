namespace cafeUygulamasi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.girisTxt = new Guna.UI.WinForms.GunaTextBox();
            this.sifreTxt = new Guna.UI.WinForms.GunaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.girisBtn = new Guna.UI.WinForms.GunaButton();
            this.cikisBtn = new Guna.UI.WinForms.GunaButton();
            this.gunaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.gunaPanel1.Controls.Add(this.gunaPictureBox1);
            this.gunaPanel1.Controls.Add(this.label3);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(371, 202);
            this.gunaPanel1.TabIndex = 0;
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = global::cafeUygulamasi.Properties.Resources.user3;
            this.gunaPictureBox1.Location = new System.Drawing.Point(121, 12);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(111, 125);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox1.TabIndex = 1;
            this.gunaPictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Lütfen Kullanıcı Bilgilerini Girin";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(15, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // girisTxt
            // 
            this.girisTxt.BaseColor = System.Drawing.Color.White;
            this.girisTxt.BorderColor = System.Drawing.Color.Silver;
            this.girisTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.girisTxt.FocusedBaseColor = System.Drawing.Color.White;
            this.girisTxt.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.girisTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.girisTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.girisTxt.Location = new System.Drawing.Point(12, 261);
            this.girisTxt.Name = "girisTxt";
            this.girisTxt.PasswordChar = '\0';
            this.girisTxt.SelectedText = "";
            this.girisTxt.Size = new System.Drawing.Size(217, 39);
            this.girisTxt.TabIndex = 2;
            // 
            // sifreTxt
            // 
            this.sifreTxt.BaseColor = System.Drawing.Color.White;
            this.sifreTxt.BorderColor = System.Drawing.Color.Silver;
            this.sifreTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.sifreTxt.FocusedBaseColor = System.Drawing.Color.White;
            this.sifreTxt.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.sifreTxt.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.sifreTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sifreTxt.Location = new System.Drawing.Point(12, 359);
            this.sifreTxt.Name = "sifreTxt";
            this.sifreTxt.PasswordChar = '●';
            this.sifreTxt.SelectedText = "";
            this.sifreTxt.Size = new System.Drawing.Size(217, 41);
            this.sifreTxt.TabIndex = 4;
            this.sifreTxt.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(15, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre:";
            // 
            // girisBtn
            // 
            this.girisBtn.AnimationHoverSpeed = 0.07F;
            this.girisBtn.AnimationSpeed = 0.03F;
            this.girisBtn.BaseColor = System.Drawing.Color.Green;
            this.girisBtn.BorderColor = System.Drawing.Color.Black;
            this.girisBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.girisBtn.FocusedColor = System.Drawing.Color.Empty;
            this.girisBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.girisBtn.ForeColor = System.Drawing.Color.White;
            this.girisBtn.Image = null;
            this.girisBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.girisBtn.Location = new System.Drawing.Point(41, 495);
            this.girisBtn.Name = "girisBtn";
            this.girisBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.girisBtn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.girisBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.girisBtn.OnHoverImage = null;
            this.girisBtn.OnPressedColor = System.Drawing.Color.Black;
            this.girisBtn.Size = new System.Drawing.Size(111, 62);
            this.girisBtn.TabIndex = 5;
            this.girisBtn.Text = "Giriş";
            this.girisBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.girisBtn.Click += new System.EventHandler(this.girisBtn_Click);
            // 
            // cikisBtn
            // 
            this.cikisBtn.AnimationHoverSpeed = 0.07F;
            this.cikisBtn.AnimationSpeed = 0.03F;
            this.cikisBtn.BaseColor = System.Drawing.Color.Maroon;
            this.cikisBtn.BorderColor = System.Drawing.Color.Black;
            this.cikisBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cikisBtn.FocusedColor = System.Drawing.Color.Empty;
            this.cikisBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cikisBtn.ForeColor = System.Drawing.Color.White;
            this.cikisBtn.Image = null;
            this.cikisBtn.ImageSize = new System.Drawing.Size(20, 20);
            this.cikisBtn.Location = new System.Drawing.Point(219, 495);
            this.cikisBtn.Name = "cikisBtn";
            this.cikisBtn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cikisBtn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.cikisBtn.OnHoverForeColor = System.Drawing.Color.White;
            this.cikisBtn.OnHoverImage = null;
            this.cikisBtn.OnPressedColor = System.Drawing.Color.Black;
            this.cikisBtn.Size = new System.Drawing.Size(111, 62);
            this.cikisBtn.TabIndex = 6;
            this.cikisBtn.Text = "Çıkış";
            this.cikisBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cikisBtn.Click += new System.EventHandler(this.cikisBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 586);
            this.Controls.Add(this.cikisBtn);
            this.Controls.Add(this.girisBtn);
            this.Controls.Add(this.sifreTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.girisTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gunaPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTextBox girisTxt;
        private Guna.UI.WinForms.GunaTextBox sifreTxt;
        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaButton girisBtn;
        private Guna.UI.WinForms.GunaButton cikisBtn;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
    }
}

