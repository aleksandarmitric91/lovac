using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;

namespace lovac
{
    public partial class fDodajLovca : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        Lovac noviLovac = new Lovac();                                   


        public fDodajLovca()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                btnOK.Enabled = false;
                cbPotvrda.Checked = false;
                pokupiPodatkeOLovcuIUpisiUBazu();
                this.Close();
            }
            catch (Exception)
            {
                DBconection konekcija = new DBconection();
                konekcija.connection.Close();
                MessageBox.Show("U bazi podataka vec postoji lovac sa maticnim brojem ili brojem licne karte koji je unijet!\nMolimo promjenite sadrzaj ovih polja.", "Podaci nisu validni!");
            }

        }

        private void cbPotvrda_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPotvrda.Checked == false)
            {
                btnOK.Enabled = false;
                tbIme.ReadOnly = false;
                tbPrezime.ReadOnly = false;
                tbOcevoIme.ReadOnly = false;
                rbPolMuski.Enabled = true;
                rbPolZenski.Enabled = true;
                tbAdresaPrebivalista.ReadOnly = false;
                tbJMBG.ReadOnly = false;
                tbBrojLicneKarte.ReadOnly = false;
                dtpDatumRodjenja.Enabled = true;
                tbMjestoRodjenja.ReadOnly = false;
                tbOpstinaRodjenja.ReadOnly = false;
                tbKontaktTelefon.ReadOnly = false;
                tbEmailAdresa.ReadOnly = false;
                cbStatusClana.Enabled = true;
                cbBrojOdradjenihDnevnica.Enabled = true;
                btnSlika.Enabled = true;
                cbPolozioLovackiIspitDa.Enabled = true;
                cbPolozioLovackiIspitNe.Enabled = true;
                cbPolozioLovackiIspitNepoznato.Enabled = true;
                tbBrojUvjerenja.ReadOnly = false;
                dtpDatumPolaganja.Enabled = true;
                tbMjestoPolaganja.ReadOnly = false;
                tbZanimanje.ReadOnly = false;
                cbZaposlenDa.Enabled = true;
                cbZaposlenNe.Enabled = true;
                cbZaposlenNepoznato.Enabled = true;
                tbFirmaUKojojRadi.ReadOnly = false;
                tbDodatniOpis.ReadOnly = false;
            }
            else
            {
                tbIme.ReadOnly = true;
                tbPrezime.ReadOnly = true;
                tbOcevoIme.ReadOnly = true;
                rbPolMuski.Enabled = false;
                rbPolZenski.Enabled = false;
                tbAdresaPrebivalista.ReadOnly = true;
                tbJMBG.ReadOnly = true;
                tbBrojLicneKarte.ReadOnly = true;
                dtpDatumRodjenja.Enabled = false;
                tbMjestoRodjenja.ReadOnly = true;
                tbOpstinaRodjenja.ReadOnly = true;
                tbKontaktTelefon.ReadOnly = true;
                tbEmailAdresa.ReadOnly = true;
                cbStatusClana.Enabled = false;
                cbBrojOdradjenihDnevnica.Enabled = false;
                btnSlika.Enabled = false;
                cbPolozioLovackiIspitDa.Enabled = false;
                cbPolozioLovackiIspitNe.Enabled = false;
                cbPolozioLovackiIspitNepoznato.Enabled = false;
                tbBrojUvjerenja.ReadOnly = true;
                dtpDatumPolaganja.Enabled = false;
                tbMjestoPolaganja.ReadOnly = true;
                tbZanimanje.ReadOnly = true;
                cbZaposlenDa.Enabled = false;
                cbZaposlenNe.Enabled = false;
                cbZaposlenNepoznato.Enabled = false;
                tbFirmaUKojojRadi.ReadOnly = true;
                tbDodatniOpis.ReadOnly = true;
                provjeriPodatke();
            }
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

        void provjeriPodatke()
        {
            bool greskaOsnovna = false;
            String poruka = "Uocene su sledece nepravilnosti:\n";

            label1.ForeColor = label5.ForeColor;
            tbIme.BackColor = tbAdresaPrebivalista.BackColor;
            label2.ForeColor = label5.ForeColor;
            tbPrezime.BackColor = tbAdresaPrebivalista.BackColor;
            label3.ForeColor = label5.ForeColor;
            tbOcevoIme.BackColor = tbAdresaPrebivalista.BackColor;
            label4.ForeColor = label5.ForeColor;
            tbJMBG.BackColor = tbAdresaPrebivalista.BackColor;
            label13.ForeColor = label5.ForeColor;
            tbKontaktTelefon.BackColor = tbAdresaPrebivalista.BackColor;
            label20.ForeColor = label5.ForeColor;
            cbStatusClana.BackColor = tbAdresaPrebivalista.BackColor;
            label19.ForeColor = label5.ForeColor;
            cbBrojOdradjenihDnevnica.BackColor = tbAdresaPrebivalista.BackColor;
            label15.ForeColor = label5.ForeColor;
            cbPolozioLovackiIspitNepoznato.BackColor = tbAdresaPrebivalista.BackColor;
            cbPolozioLovackiIspitNe.BackColor = tbAdresaPrebivalista.BackColor;
            cbPolozioLovackiIspitDa.BackColor = tbAdresaPrebivalista.BackColor;
            label22.ForeColor = label5.ForeColor;
            cbZaposlenDa.BackColor = tbAdresaPrebivalista.BackColor;
            cbZaposlenNepoznato.BackColor = tbAdresaPrebivalista.BackColor;
            cbZaposlenNe.BackColor = tbAdresaPrebivalista.BackColor;

            if (tbIme.Text.Length < 1)
            {
                greskaOsnovna = true;
                poruka += "- Ime lovca nije unijeto.\n";
                label1.ForeColor = Color.Red;
                tbIme.BackColor = Color.Coral;
            }
            if (tbPrezime.Text.Length < 1)
            {
                greskaOsnovna = true;
                poruka += "- Prezime lovca nije unijeto.\n";
                label2.ForeColor = Color.Red;
                tbPrezime.BackColor = Color.Coral;
            }
            if (tbOcevoIme.Text.Length < 1)
            {
                greskaOsnovna = true;
                poruka += "- Ocevo ime lovca nije unijeto.\n";
                label3.ForeColor = Color.Red;
                tbOcevoIme.BackColor = Color.Coral;
            }
            try
            {
                long provjeraJMBG = Convert.ToInt64(tbJMBG.Text.ToString());
            }
            catch (Exception)
            {
                greskaOsnovna = true;
                label4.ForeColor = Color.Red;
                tbJMBG.BackColor = Color.Coral;
                if (tbJMBG.Text.Length < 1)
                {
                    poruka += "- Maticni broj nije unijet.\n";
                }
                else
                {
                    poruka += "- Maticni broj nije ispravnog formata.\n";
                }
            }
            if (tbKontaktTelefon.Text.Length < 1)
            {
                greskaOsnovna = true;
                poruka += "- Kontakt telefon lovca nije unijet.\n";
                label13.ForeColor = Color.Red;
                tbKontaktTelefon.BackColor = Color.Coral;
            }
            if (cbStatusClana.Text != "Aktivan" && cbStatusClana.Text != "Maticni" && cbStatusClana.Text != "Pomazuci" &&
                cbStatusClana.Text != "Dvojni" && cbStatusClana.Text != "Pripravnik" && cbStatusClana.Text != "Pocasni")
            {
                greskaOsnovna = true;
                poruka += "- Status clana lovca nije ispravno odabran.\n";
                label20.ForeColor = Color.Red;
                cbStatusClana.BackColor = Color.Coral;
            }
            if (cbBrojOdradjenihDnevnica.Text != "Ni jedna" && cbBrojOdradjenihDnevnica.Text != "Jedna" &&
                cbBrojOdradjenihDnevnica.Text != "Dvije" && cbBrojOdradjenihDnevnica.Text != "Tri")
            {
                greskaOsnovna = true;
                poruka += "- Broj odradjenih dnevnica lovca nije ispravno odabran.\n";
                label19.ForeColor = Color.Red;
                cbBrojOdradjenihDnevnica.BackColor = Color.Coral;
            }
            if (cbPolozioLovackiIspitNepoznato.Checked != true && cbPolozioLovackiIspitDa.Checked != true &&
                cbPolozioLovackiIspitNe.Checked != true)
            {
                greskaOsnovna = true;
                poruka += "- Nije oznacen status lovackog ispita.\n";
                label15.ForeColor = Color.Red;
                cbPolozioLovackiIspitNepoznato.BackColor = Color.Coral;
                cbPolozioLovackiIspitNe.BackColor = Color.Coral;
                cbPolozioLovackiIspitDa.BackColor = Color.Coral;
            }
            if (cbZaposlenDa.Checked != true && cbZaposlenNepoznato.Checked != true &&
                cbZaposlenNe.Checked != true)
            {
                greskaOsnovna = true;
                poruka += "- Nije oznacen status zaposlenog lica.\n";
                label22.ForeColor = Color.Red;
                cbZaposlenDa.BackColor = Color.Coral;
                cbZaposlenNepoznato.BackColor = Color.Coral;
                cbZaposlenNe.BackColor = Color.Coral;
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

        private void cbPolozioLovackiIspitDa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPolozioLovackiIspitDa.Checked == true)
            {
                cbPolozioLovackiIspitNe.Enabled = false;
                cbPolozioLovackiIspitNepoznato.Enabled = false;
                tbBrojUvjerenja.Enabled = true;
                dtpDatumPolaganja.Enabled = true;
                tbMjestoPolaganja.Enabled = true;
            }
            else
            {
                cbPolozioLovackiIspitNe.Enabled = true;
                cbPolozioLovackiIspitNepoznato.Enabled = true;
                tbBrojUvjerenja.Enabled = false;
                dtpDatumPolaganja.Enabled = false;
                tbMjestoPolaganja.Enabled = false;
            }
        }

        private void cbPolozioLovackiIspitNe_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPolozioLovackiIspitNe.Checked == true)
            {
                cbPolozioLovackiIspitDa.Enabled = false;
                cbPolozioLovackiIspitNepoznato.Enabled = false;
            }
            else
            {
                cbPolozioLovackiIspitDa.Enabled = true;
                cbPolozioLovackiIspitNepoznato.Enabled = true;
            }
        }

        private void cbPolozioLovackiIspitNepoznato_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPolozioLovackiIspitNepoznato.Checked == true)
            {
                cbPolozioLovackiIspitNe.Enabled = false;
                cbPolozioLovackiIspitDa.Enabled = false;
            }
            else
            {
                cbPolozioLovackiIspitNe.Enabled = true;
                cbPolozioLovackiIspitDa.Enabled = true;
            }
        }

        private void cbZaposlenNepoznato_CheckedChanged(object sender, EventArgs e)
        {
            if (cbZaposlenNepoznato.Checked == true)
            {
                cbZaposlenNe.Enabled = false;
                cbZaposlenDa.Enabled = false;
            }
            else
            {
                cbZaposlenNe.Enabled = true;
                cbZaposlenDa.Enabled = true;
            }
        }

        private void cbZaposlenNe_CheckedChanged(object sender, EventArgs e)
        {
            if (cbZaposlenNe.Checked == true)
            {
                cbZaposlenNepoznato.Enabled = false;
                cbZaposlenDa.Enabled = false;
            }
            else
            {
                cbZaposlenNepoznato.Enabled = true;
                cbZaposlenDa.Enabled = true;
            }
        }

        private void cbZaposlenDa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbZaposlenDa.Checked == true)
            {
                cbZaposlenNe.Enabled = false;
                cbZaposlenNepoznato.Enabled = false;
                tbFirmaUKojojRadi.Enabled = true;
            }
            else
            {
                cbZaposlenNe.Enabled = true;
                cbZaposlenNepoznato.Enabled = true;
                tbFirmaUKojojRadi.Enabled = false;
            }
        }

        //mozda bude potrebno mjenjati direktorijum slike
        void pokupiPodatkeOLovcuIUpisiUBazu()
        {
            noviLovac.ime = tbIme.Text.ToString();
            noviLovac.prezime = tbPrezime.Text;
            noviLovac.ocevoIme = tbOcevoIme.Text;
            if (rbPolMuski.Checked == true)
            {
                noviLovac.pol = "Muski";
            }
            else
            {
                noviLovac.pol = "Zenski";
            }
            noviLovac.adresaPrebivalista = tbAdresaPrebivalista.Text;
            noviLovac.JMBG = tbJMBG.Text;
            noviLovac.brojLicneKarte = tbBrojLicneKarte.Text;
            noviLovac.datumRodjenja = dtpDatumRodjenja.Text;
            noviLovac.mjestoRodjenja = tbMjestoRodjenja.Text;
            noviLovac.opstinaRodjenja = tbOpstinaRodjenja.Text;
            noviLovac.kontaktTelefon = tbKontaktTelefon.Text;
            noviLovac.emailAdresa = tbEmailAdresa.Text;
            noviLovac.statusClana = cbStatusClana.Text;
            noviLovac.brojOdradjenihDnevnica = cbBrojOdradjenihDnevnica.Text;
            noviLovac.adresaSlike = @"D:\\lovac\\lovac\\resources\\lovci\\" + tbJMBG.Text + ".png";
            pbSlika.Image.Save(noviLovac.adresaSlike,ImageFormat.Png);
            if (cbPolozioLovackiIspitDa.Checked == true)
            {
                noviLovac.polozioLovackiIspit = "Da";
                noviLovac.brojUvjerenja = tbBrojUvjerenja.Text;
                noviLovac.datumPolaganja = dtpDatumPolaganja.Text;
                noviLovac.mjestoPolaganja = tbMjestoPolaganja.Text;
            }
            if (cbPolozioLovackiIspitNe.Checked == true)
            {
                noviLovac.polozioLovackiIspit = "Ne";
                noviLovac.brojUvjerenja = "";
                noviLovac.datumPolaganja = dtpDatumPolaganja.Text;
                noviLovac.mjestoPolaganja = "";
            }
            if (cbPolozioLovackiIspitNepoznato.Checked == true)
            {
                noviLovac.polozioLovackiIspit = "Nepoznato";
                noviLovac.brojUvjerenja = "";
                noviLovac.datumPolaganja = dtpDatumPolaganja.Text;
                noviLovac.mjestoPolaganja = "";
            }
            noviLovac.zanimanje = tbZanimanje.Text;
            if (cbZaposlenDa.Checked == true)
            {
                noviLovac.zaposlen = "Da";
                noviLovac.firmaUKojojRadi = tbFirmaUKojojRadi.Text;
            }
            if (cbZaposlenNe.Checked == true)
            {
                noviLovac.zaposlen = "Ne";
                noviLovac.firmaUKojojRadi = "";
            }
            if (cbZaposlenNepoznato.Checked == true)
            {
                noviLovac.zaposlen = "Nepoznato";
                noviLovac.firmaUKojojRadi = "";
            }
            noviLovac.dodatniOpis = tbDodatniOpis.Text;

            DBconection konekcija = new DBconection();
            konekcija.Insert("lovac", noviLovac);
        }
    }
}
