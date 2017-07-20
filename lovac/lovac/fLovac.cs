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
using System.IO;

namespace lovac
{
    public partial class fLovac : Form
    {
        fDodajLovca noviLovac = new fDodajLovca();
        fDodajOruzije novoOruzije = new fDodajOruzije();
        List<Lovac> sviLovci = new List<Lovac>();
        List<Lovac_has_oruzije> sviLovac_has_oruzije = new List<Lovac_has_oruzije>();
        List<Oruzije> svoOruzije = new List<Oruzije>();
        OpenFileDialog ofd = new OpenFileDialog();
        int indeksSelektovanogLovca = 0;
        public String maticni = "";

        public fLovac()
        {
            InitializeComponent();
        }

        private void btnDodajLovca_Click(object sender, EventArgs e)
        {
            noviLovac.ShowDialog();
        }

        private void btnDodajOruzije_Click(object sender, EventArgs e)
        {
            novoOruzije.pom = maticni;
            novoOruzije.ShowDialog();
            DBconection konekcija = new DBconection();
            sviLovac_has_oruzije = konekcija.Select_ref("lovac_has_oruzije");
            lbSeriskiBrojevi.Items.Clear();
            Boolean imaIhVise = false;

            for (int i = 0; i < sviLovac_has_oruzije.Count(); i++)
            {
                if (sviLovac_has_oruzije[i].lovacJMBG == maticni)
                {
                    lbSeriskiBrojevi.Items.Add(sviLovac_has_oruzije[i].oruzijeSeriskiBroj);
                    imaIhVise = true;
                }
            }

            if (imaIhVise == true)
            {
                lbSeriskiBrojevi.SelectedIndex = 0;
            }

            if (lbSeriskiBrojevi.Items.Count == 0)
            {
                tbTipOruzija1.Text = "";
                tbNazivOruzija1.Text = "";
                tbKalibar1.Text = "";
                tbSeriskiBroj1.Text = "";
                tbDodatniOpis1.Text = "";
                pbOruzije1.Image = Properties.Resources.default_hunter;
                btnIzmjeniOruzije.Enabled = false;
                btnObrisiOruzije.Enabled = false;
            }
            else
            {
                btnIzmjeniOruzije.Enabled = true;
                btnObrisiOruzije.Enabled = true;
            }
        }

        //ovde se popunjavaju oruzija
        private void cbSelektijLovca_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selekcija = cbSelektijLovca.SelectedItem.ToString();
            int indeks = selekcija.IndexOf('-') + 2;
            maticni=selekcija.Substring(indeks);
            for (int i = 0; i < sviLovci.Count(); i++)
            {
                if (sviLovci[i].JMBG.ToString() == maticni)
                {
                    indeksSelektovanogLovca = i;
                    tbIme.Text = sviLovci[i].ime;
                    tbPrezime.Text = sviLovci[i].prezime;
                    tbOcevoIme.Text = sviLovci[i].ocevoIme;
                    tbPol.Text = sviLovci[i].pol;
                    tbAdresaPrebivalista.Text = sviLovci[i].adresaPrebivalista;
                    tbJMBG.Text = sviLovci[i].JMBG;
                    tbBrojLicneKarte.Text = sviLovci[i].brojLicneKarte;
                    tbDatumRodjenja.Text = sviLovci[i].datumRodjenja;
                    tbMjestoRodjenja.Text = sviLovci[i].mjestoRodjenja;
                    tbOpstinaRodjenja.Text = sviLovci[i].opstinaRodjenja;
                    tbKontaktTelefon.Text = sviLovci[i].kontaktTelefon;
                    tbEmailAdresa.Text = sviLovci[i].emailAdresa;
                    tbStatusClana.Text = sviLovci[i].statusClana;
                    tbBrojOdradjenihDnevnica.Text = sviLovci[i].brojOdradjenihDnevnica;
                    try
                    {
                        pbSlika.Image = Image.FromFile(sviLovci[i].adresaSlike);
                    }
                    catch (Exception)
                    {
                        pbSlika.Image = Properties.Resources.default_hunter;
                    }
                    tbPolozioLovackiIspit.Text = sviLovci[i].polozioLovackiIspit;
                    if (sviLovci[i].polozioLovackiIspit == "Da")
                    {
                        tbBrojUvjerenja.Text = sviLovci[i].brojUvjerenja;
                        tbDatumPolaganja.Text = sviLovci[i].datumPolaganja;
                        tbMjestoPolaganja.Text = sviLovci[i].mjestoPolaganja;
                    }
                    else if (sviLovci[i].polozioLovackiIspit == "Ne")
                    {
                        tbBrojUvjerenja.Text = "";
                        tbDatumPolaganja.Text = "Nije polozio";
                        tbMjestoPolaganja.Text = "";
                    }
                    else
                    {
                        tbBrojUvjerenja.Text = "";
                        tbDatumPolaganja.Text = "Nepoznato";
                        tbMjestoPolaganja.Text = "";
                    }
                    tbZanimanje.Text = sviLovci[i].zanimanje;
                    tbZaposlen.Text = sviLovci[i].zaposlen;
                    if (sviLovci[i].zaposlen == "Da")
                    {
                        tbFirmaUKojojRadi.Text = sviLovci[i].firmaUKojojRadi;
                    }
                    else if (sviLovci[i].zaposlen == "Ne")
                    {
                        tbFirmaUKojojRadi.Text = "Nije zaposlen";
                    }
                    else
                    {
                        tbFirmaUKojojRadi.Text = "Nepoznato";
                    }
                    tbDodatniOpis.Text = sviLovci[i].dodatniOpis;
                    btnDodajOruzije.Enabled = true;
                    btnObrisiLovca.Enabled = true;
                    break;
                }
                btnDodajOruzije.Enabled = false;
                btnObrisiLovca.Enabled = false;
            }
            DBconection konekcija = new DBconection();
            sviLovac_has_oruzije = konekcija.Select_ref("lovac_has_oruzije");
            lbSeriskiBrojevi.Items.Clear();
            Boolean imaIhVise = false;

            for (int i = 0; i < sviLovac_has_oruzije.Count(); i++)
            {
                if (sviLovac_has_oruzije[i].lovacJMBG == maticni)
                {
                    lbSeriskiBrojevi.Items.Add(sviLovac_has_oruzije[i].oruzijeSeriskiBroj);
                    imaIhVise = true;
                }
            }

            if (imaIhVise == true)
            {
                lbSeriskiBrojevi.SelectedIndex = 0;
            }

            if (lbSeriskiBrojevi.Items.Count == 0)
            {
                tbTipOruzija1.Text = "";
                tbNazivOruzija1.Text = "";
                tbKalibar1.Text = "";
                tbSeriskiBroj1.Text = "";
                tbDodatniOpis1.Text = "";
                pbOruzije1.Image = Properties.Resources.default_hunter;
                btnIzmjeniOruzije.Enabled = false;
                btnObrisiOruzije.Enabled = false;
            }
            else
            {
                btnIzmjeniOruzije.Enabled = true;
                btnObrisiOruzije.Enabled = true;
            }
        }

        private void cbSelektijLovca_Enter(object sender, EventArgs e)
        {
            String imeOcevoImePrezime = "";
            String maticniVlasnika = "0";
            DBconection konekcija = new DBconection();
            sviLovci = konekcija.Select("lovac");
            cbSelektijLovca.Items.Clear();

            for (int i = 0; i < sviLovci.Count(); i++)
            {
                imeOcevoImePrezime = sviLovci[i].ime + "(" + sviLovci[i].ocevoIme + ")" + sviLovci[i].prezime;
                maticniVlasnika = sviLovci[i].JMBG;
                cbSelektijLovca.Items.Add(imeOcevoImePrezime + " - " + maticniVlasnika.ToString());
            }
        }

        private void lbSeriskiBrojevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBconection konekcija = new DBconection();
            svoOruzije = konekcija.Select_oruzije("Oruzije");

            for (int i = 0; i < svoOruzije.Count(); i++)
            {
                if (lbSeriskiBrojevi.SelectedItem.ToString()==svoOruzije[i].seriskiBroj)
                {
                    tbTipOruzija1.Text = svoOruzije[i].tipOruzija;
                    tbNazivOruzija1.Text = svoOruzije[i].nazivOruzija;
                    tbKalibar1.Text = svoOruzije[i].kalibar;
                    tbSeriskiBroj1.Text = svoOruzije[i].seriskiBroj;
                    tbDodatniOpis1.Text = svoOruzije[i].dodatniOpis;
                    try
                    {
                        pbOruzije1.Image = Image.FromFile(svoOruzije[i].slika);
                    }
                    catch (Exception)
                    {
                        pbOruzije1.Image = Properties.Resources.default_hunter;
                    }
                    break;
                }
            }
        }

        private void btnIzmjeniOruzije_Click(object sender, EventArgs e)
        {
            int zapamcenaSelekcija = lbSeriskiBrojevi.SelectedIndex;
            if (btnIzmjeniOruzije.Text == "Izmeni podatke o oruziju")
            {
                btnIzmjeniOruzije.Text = "Otkazi izmjene";
                groupBox1.Enabled = false;
                cbSelektijLovca.Enabled = false;
                btnDodajLovca.Enabled = false;
                btnDodajOruzije.Enabled = false;
                btnObrisiOruzije.Enabled = false;
                lbSeriskiBrojevi.Enabled = false;
                tbSeriskiBroj1.Enabled = false;
                cbPotvrda.Visible = true;
                cbPotvrda.Checked = false;
                btnOK.Enabled = false;
                btnOK.Visible = true;
                label29.Text = "Kalibar: *";
                label30.Text = "Naziv oruzija: *";
                label31.Text = "Tip oruzija: *";
                tbTipOruzija1.ReadOnly = false;
                tbNazivOruzija1.ReadOnly = false;
                tbKalibar1.ReadOnly = false;
                tbDodatniOpis1.ReadOnly = false;
                btnIzmeniSliku.Visible = true;
            }
            else if (btnIzmjeniOruzije.Text == "Otkazi izmjene")
            {
                btnIzmjeniOruzije.Text = "Izmeni podatke o oruziju";
                groupBox1.Enabled = true;
                cbSelektijLovca.Enabled = true;
                btnDodajLovca.Enabled = true;
                btnDodajOruzije.Enabled = true;
                btnObrisiOruzije.Enabled = true;
                lbSeriskiBrojevi.Enabled = true;
                tbSeriskiBroj1.Enabled = true;
                cbPotvrda.Visible = false;
                btnOK.Visible = false;
                label29.Text = "Kalibar:";
                label30.Text = "Naziv oruzija:";
                label31.Text = "Tip oruzija:";
                tbTipOruzija1.ReadOnly = true;
                tbNazivOruzija1.ReadOnly = true;
                tbKalibar1.ReadOnly = true;
                tbDodatniOpis1.ReadOnly = true;
                btnIzmeniSliku.Visible = false;
                lbSeriskiBrojevi.SelectedIndex = zapamcenaSelekcija;
                lbSeriskiBrojevi_SelectedIndexChanged(sender, e);
                label31.ForeColor = label28.ForeColor;
                tbTipOruzija1.BackColor = tbDodatniOpis1.BackColor;
                label30.ForeColor = label28.ForeColor;
                tbNazivOruzija1.BackColor = tbDodatniOpis1.BackColor;
                label29.ForeColor = label28.ForeColor;
                tbKalibar1.BackColor = tbDodatniOpis1.BackColor;
            }
        }

        private void btnObrisiOruzije_Click(object sender, EventArgs e)
        {
            DBconection konekcija = new DBconection();
            konekcija.Delete("oruzije", lbSeriskiBrojevi.SelectedItem.ToString());
            sviLovac_has_oruzije = konekcija.Select_ref("lovac_has_oruzije");
            lbSeriskiBrojevi.Items.Clear();
            Boolean imaIhVise = false;

            for (int i = 0; i < sviLovac_has_oruzije.Count(); i++)
            {
                if (sviLovac_has_oruzije[i].lovacJMBG == maticni)
                {
                    lbSeriskiBrojevi.Items.Add(sviLovac_has_oruzije[i].oruzijeSeriskiBroj);
                    imaIhVise = true;
                }
            }

            if (imaIhVise == true)
            {
                lbSeriskiBrojevi.SelectedIndex = 0;
            }

            if (lbSeriskiBrojevi.Items.Count == 0)
            {
                tbTipOruzija1.Text = "";
                tbNazivOruzija1.Text = "";
                tbKalibar1.Text = "";
                tbSeriskiBroj1.Text = "";
                tbDodatniOpis1.Text = "";
                pbOruzije1.Image = Properties.Resources.default_hunter;
                btnIzmjeniOruzije.Enabled = false;
                btnObrisiOruzije.Enabled = false;
            }
            else
            {
                btnIzmjeniOruzije.Enabled = true;
                btnObrisiOruzije.Enabled = true;
            }
        }

        private void cbPotvrda_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPotvrda.Checked == false)
            {
                btnOK.Enabled = false;
                tbTipOruzija1.ReadOnly = false;
                tbNazivOruzija1.ReadOnly = false;
                tbKalibar1.ReadOnly = false;
                tbDodatniOpis1.ReadOnly = false;
                btnIzmeniSliku.Enabled = true;
            }
            else
            {
                tbTipOruzija1.ReadOnly = true;
                tbNazivOruzija1.ReadOnly = true;
                tbKalibar1.ReadOnly = true;
                tbDodatniOpis1.ReadOnly = true;
                btnIzmeniSliku.Enabled = false;
                provjeriPodatke();
            }
        }

        void provjeriPodatke()
        {
            bool greskaOsnovna = false;
            String poruka = "Uocene su sledece nepravilnosti:\n";

            label31.ForeColor = label28.ForeColor;
            tbTipOruzija1.BackColor = tbDodatniOpis1.BackColor;
            label30.ForeColor = label28.ForeColor;
            tbNazivOruzija1.BackColor = tbDodatniOpis1.BackColor;
            label29.ForeColor = label28.ForeColor;
            tbKalibar1.BackColor = tbDodatniOpis1.BackColor;
            tbDodatniOpis1.BackColor = tbKalibar1.BackColor;
            label14.ForeColor = label28.ForeColor;

            if (tbTipOruzija1.Text.Length < 1)
            {
                greskaOsnovna = true;
                poruka += "- Tip oruzija nije unijet.\n";
                label31.ForeColor = Color.Red;
                tbTipOruzija1.BackColor = Color.Coral;
            }
            if (tbNazivOruzija1.Text.Length < 1)
            {
                greskaOsnovna = true;
                poruka += "- Naziv oruzija nije unijet.\n";
                label30.ForeColor = Color.Red;
                tbNazivOruzija1.BackColor = Color.Coral;
            }
            if (tbKalibar1.Text.Length < 1)
            {
                greskaOsnovna = true;
                poruka += "- Kalibar oruzija nije unijet.\n";
                label14.ForeColor = Color.Red;
                label29.ForeColor = Color.Red;
                tbKalibar1.BackColor = Color.Coral;
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

        private void btnIzmeniSliku_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbOruzije1.Image = Image.FromFile(ofd.FileName);
                pbOruzije1.BackgroundImage = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Oruzije updateOruzije = new Oruzije();
            updateOruzije.tipOruzija = tbTipOruzija1.Text;
            updateOruzije.nazivOruzija = tbNazivOruzija1.Text;
            updateOruzije.kalibar = tbKalibar1.Text;
            updateOruzije.dodatniOpis = tbDodatniOpis1.Text;
            updateOruzije.slika = @"D:\\lovac\\lovac\\resources\\oruzija\\" + tbSeriskiBroj1.Text + ".png";
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (File.Exists(updateOruzije.slika))
                {
                    File.Delete(updateOruzije.slika);
                }
                pbOruzije1.Image.Save(updateOruzije.slika,ImageFormat.Png);
            }
            catch (Exception)
            {}
            DBconection konekcija = new DBconection();
            konekcija.Update("oruzije", updateOruzije, tbSeriskiBroj1.Text);
            btnIzmjeniOruzije_Click(sender, e);
        }

        private void btnObrisiLovca_Click(object sender, EventArgs e)
        {
            DBconection konekcija = new DBconection();
            konekcija.Delete(maticni);
            isprazniSvaPolja();
        }

        private void isprazniSvaPolja()
        {
            cbSelektijLovca.SelectedIndex = cbSelektijLovca.Items.Count -1;
            cbSelektijLovca.SelectedIndex = 0;
        }

        private void cbSelektijLovca_Leave(object sender, EventArgs e)
        {
            Boolean postoji = false;
            for (int i = 0; i < cbSelektijLovca.Items.Count; i++)
            {
                if (cbSelektijLovca.Text == cbSelektijLovca.Items[i].ToString())
                {
                    postoji = true;
                }
            }
            if (postoji!=true)
            {
                isprazniSvaPolja();
            }
        }
        
    }
}
