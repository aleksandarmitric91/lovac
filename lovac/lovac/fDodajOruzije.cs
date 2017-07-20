using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lovac
{
    public partial class fDodajOruzije : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        Oruzije novoOruzije = new Oruzije();
        internal string pom;

        public fDodajOruzije()
        {
            InitializeComponent();
        }

        private void btnSlika_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbSlika.Image = Image.FromFile(ofd.FileName);
                pbSlika.BackgroundImage = null;
            }
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = false;
                cbPotvrda.Checked = false;
                pokupiPodatkeOLovcuIUpisiUBazu(pom);
                this.Close();
            }
            catch (Exception)
            {
                DBconection konekcija = new DBconection();
                konekcija.connection.Close();
                MessageBox.Show("U bazi podataka vec postoji oruzije sa seriskim brojem koji je unijet!\nMolimo promjenite sadrzaj ovog polja.", "Podaci nisu validni!");
            }
        }

        private void cbPotvrda_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPotvrda.Checked == false)
            {
                btnOK.Enabled = false;
                tbTipOruzija.ReadOnly = false;
                tbNazivOruzija.ReadOnly = false;
                tbKalibar.ReadOnly = false;
                tbSeriskiBroj.ReadOnly = false;
                tbDodatniOpis.ReadOnly = false;
                btnSlika.Enabled = true;
            }
            else
            {
                tbTipOruzija.ReadOnly = true;
                tbNazivOruzija.ReadOnly = true;
                tbKalibar.ReadOnly = true;
                tbSeriskiBroj.ReadOnly = true;
                tbDodatniOpis.ReadOnly = true;
                btnSlika.Enabled = false;
                provjeriPodatke();
            }
        }

        void provjeriPodatke()
        {
            bool greskaOsnovna = false;
            String poruka = "Uocene su sledece nepravilnosti:\n";

            label1.ForeColor = label14.ForeColor;
            tbTipOruzija.BackColor = tbDodatniOpis.BackColor;
            label2.ForeColor = label14.ForeColor;
            tbNazivOruzija.BackColor = tbDodatniOpis.BackColor;
            label3.ForeColor = label14.ForeColor;
            tbKalibar.BackColor = tbDodatniOpis.BackColor;
            label4.ForeColor = label14.ForeColor;
            tbSeriskiBroj.BackColor = tbDodatniOpis.BackColor;
            label6.ForeColor = label14.ForeColor;

            if (tbTipOruzija.Text.Length < 1)
            {
                greskaOsnovna = true;
                poruka += "- Tip oruzija nije unijet.\n";
                label1.ForeColor = Color.Red;
                tbTipOruzija.BackColor = Color.Coral;
            }
            if (tbNazivOruzija.Text.Length < 1)
            {
                greskaOsnovna = true;
                poruka += "- Naziv oruzija nije unijet.\n";
                label2.ForeColor = Color.Red;
                tbNazivOruzija.BackColor = Color.Coral;
            }
            if (tbKalibar.Text.Length < 1)
            {
                greskaOsnovna = true;
                poruka += "- Kalibar oruzija nije unijet.\n";
                label3.ForeColor = Color.Red;
                label6.ForeColor = Color.Red;                                   ///////////////////////////////////////////////
                tbKalibar.BackColor = Color.Coral;
            }
            if (tbSeriskiBroj.Text.Length < 1)
            {
                greskaOsnovna = true;
                poruka += "- Seriski broj oruzija nije unijet.\n";
                label4.ForeColor = Color.Red;
                tbSeriskiBroj.BackColor = Color.Coral;
            }
            poruka += "Molimo ispravite gore navedene greske.";

            if (greskaOsnovna == false)
            {
                btnOK.Enabled = true;
            }
            else
            {
                MessageBox.Show(poruka, "Podaci nisu validni!");
                btnOK.Enabled = false;
                cbPotvrda.Checked = false;
            }
        }

        void pokupiPodatkeOLovcuIUpisiUBazu(String VlasnikJMBG)
        {
            novoOruzije.tipOruzija = tbTipOruzija.Text.ToString();
            novoOruzije.nazivOruzija = tbNazivOruzija.Text;
            novoOruzije.kalibar = tbKalibar.Text;
            novoOruzije.seriskiBroj = tbSeriskiBroj.Text;
            novoOruzije.slika = @"D:\\lovac\\lovac\\resources\\oruzija\\" + tbSeriskiBroj.Text + ".png";
            try
            {
                pbSlika.Image.Save(novoOruzije.slika, ImageFormat.Png);
            }
            catch (Exception)
            {}
            novoOruzije.dodatniOpis = tbDodatniOpis.Text;
            
            DBconection konekcija = new DBconection();
            konekcija.Insert("oruzije", novoOruzije, VlasnikJMBG);
        }
    }
}
