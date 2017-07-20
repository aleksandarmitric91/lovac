namespace lovac
{
    partial class fDodajOruzije
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDodajOruzije));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTipOruzija = new System.Windows.Forms.TextBox();
            this.tbSeriskiBroj = new System.Windows.Forms.TextBox();
            this.tbKalibar = new System.Windows.Forms.TextBox();
            this.tbNazivOruzija = new System.Windows.Forms.TextBox();
            this.cbPotvrda = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSlika = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDodatniOpis = new System.Windows.Forms.TextBox();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tip oruzija: *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Naziv oruzija: *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kalibar: *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Seriski broj: *";
            // 
            // tbTipOruzija
            // 
            this.tbTipOruzija.Location = new System.Drawing.Point(121, 12);
            this.tbTipOruzija.MaxLength = 25;
            this.tbTipOruzija.Name = "tbTipOruzija";
            this.tbTipOruzija.Size = new System.Drawing.Size(225, 20);
            this.tbTipOruzija.TabIndex = 4;
            // 
            // tbSeriskiBroj
            // 
            this.tbSeriskiBroj.Location = new System.Drawing.Point(121, 90);
            this.tbSeriskiBroj.MaxLength = 20;
            this.tbSeriskiBroj.Name = "tbSeriskiBroj";
            this.tbSeriskiBroj.Size = new System.Drawing.Size(225, 20);
            this.tbSeriskiBroj.TabIndex = 7;
            // 
            // tbKalibar
            // 
            this.tbKalibar.Location = new System.Drawing.Point(121, 64);
            this.tbKalibar.MaxLength = 10;
            this.tbKalibar.Name = "tbKalibar";
            this.tbKalibar.Size = new System.Drawing.Size(195, 20);
            this.tbKalibar.TabIndex = 6;
            // 
            // tbNazivOruzija
            // 
            this.tbNazivOruzija.Location = new System.Drawing.Point(121, 38);
            this.tbNazivOruzija.MaxLength = 40;
            this.tbNazivOruzija.Name = "tbNazivOruzija";
            this.tbNazivOruzija.Size = new System.Drawing.Size(225, 20);
            this.tbNazivOruzija.TabIndex = 5;
            // 
            // cbPotvrda
            // 
            this.cbPotvrda.AutoSize = true;
            this.cbPotvrda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPotvrda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPotvrda.ForeColor = System.Drawing.Color.Red;
            this.cbPotvrda.Location = new System.Drawing.Point(265, 350);
            this.cbPotvrda.Name = "cbPotvrda";
            this.cbPotvrda.Size = new System.Drawing.Size(267, 19);
            this.cbPotvrda.TabIndex = 10;
            this.cbPotvrda.Text = "Potvrdjujem da su uneti podaci validni";
            this.cbPotvrda.UseVisualStyleBackColor = true;
            this.cbPotvrda.CheckedChanged += new System.EventHandler(this.cbPotvrda_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(347, 375);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Dodaj novo oruzije";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSlika
            // 
            this.btnSlika.Location = new System.Drawing.Point(369, 36);
            this.btnSlika.Name = "btnSlika";
            this.btnSlika.Size = new System.Drawing.Size(75, 23);
            this.btnSlika.TabIndex = 8;
            this.btnSlika.Text = "Dodaj sliku";
            this.btnSlika.UseVisualStyleBackColor = true;
            this.btnSlika.Click += new System.EventHandler(this.btnSlika_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 185);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Dodatni opis:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(366, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Slika:";
            // 
            // tbDodatniOpis
            // 
            this.tbDodatniOpis.Location = new System.Drawing.Point(121, 182);
            this.tbDodatniOpis.MaxLength = 800;
            this.tbDodatniOpis.Multiline = true;
            this.tbDodatniOpis.Name = "tbDodatniOpis";
            this.tbDodatniOpis.Size = new System.Drawing.Size(620, 162);
            this.tbDodatniOpis.TabIndex = 9;
            // 
            // pbSlika
            // 
            this.pbSlika.BackgroundImage = global::lovac.Properties.Resources.default_hunter;
            this.pbSlika.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSlika.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSlika.Image = global::lovac.Properties.Resources.default_hunter;
            this.pbSlika.Location = new System.Drawing.Point(450, 5);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(291, 171);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSlika.TabIndex = 33;
            this.pbSlika.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(323, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "mm";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fDodajOruzije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::lovac.Properties.Resources.logo1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(753, 410);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSlika);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDodatniOpis);
            this.Controls.Add(this.pbSlika);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbPotvrda);
            this.Controls.Add(this.tbNazivOruzija);
            this.Controls.Add(this.tbKalibar);
            this.Controls.Add(this.tbSeriskiBroj);
            this.Controls.Add(this.tbTipOruzija);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fDodajOruzije";
            this.Text = "Podaci o novom oruziju";
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTipOruzija;
        private System.Windows.Forms.TextBox tbSeriskiBroj;
        private System.Windows.Forms.TextBox tbKalibar;
        private System.Windows.Forms.TextBox tbNazivOruzija;
        private System.Windows.Forms.CheckBox cbPotvrda;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSlika;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDodatniOpis;
        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}