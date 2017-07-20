using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace lovac
{
    class DBconection
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBconection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "lovac";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database + ";";

            connection = new MySqlConnection(connectionString);
        }

        //Open connection
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Konekcija na bazu podataka nije uspjela. Provjeriti status WAMP Servera!", "Greska pri konekciji!");
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //insert za novog lovca zavrsen totalno
        //Insert statement
        public void Insert(String tabela, Lovac noviLovac)
        {
            string query = "INSERT INTO " + tabela + " (ime, prezime, ocevoIme, pol, adresaPrebivalista, JMBG,"
                + " brojLicneKarte, datumRodjenja, mjestoRodjenja, opstinaRodjenja, kontaktTelefon, emailAdresa,"
                + " statusClana, brojOdradjenihDnevnica, adresaSlike, polozioIspit, brojUvjerenja, datumPolaganja,"
                + " mjestoPolaganja, zanimanje, zaposlen, firmaUKojojRadi, dodatniOpis)"
                + " VALUES('" + noviLovac.ime + "', '" + noviLovac.prezime + "','" + noviLovac.ocevoIme + "','" + noviLovac.pol
                + "','" + noviLovac.adresaPrebivalista + "','" + noviLovac.JMBG + "','" + noviLovac.brojLicneKarte
                + "','" + noviLovac.datumRodjenja + "','" + noviLovac.mjestoRodjenja + "','" + noviLovac.opstinaRodjenja
                + "','" + noviLovac.kontaktTelefon + "','" + noviLovac.emailAdresa + "','" + noviLovac.statusClana
                + "','" + noviLovac.brojOdradjenihDnevnica + "','" + noviLovac.adresaSlike + "','" + noviLovac.polozioLovackiIspit
                + "','" + noviLovac.brojUvjerenja + "','" + noviLovac.datumPolaganja + "','" + noviLovac.mjestoPolaganja
                + "','" + noviLovac.zanimanje + "','" + noviLovac.zaposlen + "','" + noviLovac.firmaUKojojRadi + "','" + noviLovac.dodatniOpis + "')";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            MessageBox.Show("Novi lovac je uspjesno dodat.", "Informacija");
        }

        //insert za novo oruzije i njegove reference zavrseno totalno
        //Insert statement
        public void Insert(String tabela, Oruzije novoOruzije, String VlasnikJMBG)
        {
            string query = "INSERT INTO " + tabela + " (tipOruzija, nazivOruzija, kalibar, SeriskiBroj, adresaSlike,"
                + "dodatniOpis)" + " VALUES('" + novoOruzije.tipOruzija + "', '" + novoOruzije.nazivOruzija
                + "','" + novoOruzije.kalibar + "','" + novoOruzije.seriskiBroj + "','" + novoOruzije.slika
                + "','" + novoOruzije.dodatniOpis + "')";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            query = "INSERT INTO lovac_has_oruzije (lovac_JMBG, oruzije_seriskiBroj) VALUES('" + VlasnikJMBG + "', '" + novoOruzije.seriskiBroj + "')";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            MessageBox.Show("Novo oruzije je uspjesno dodato.", "Informacija");
        }

        //radi za oruzije
        //Update statement
        public void Update(String tabela, Oruzije updateData, String seriskiBroj)
        {
            string query = "UPDATE " + tabela + " SET tipOruzija='" + updateData.tipOruzija + "', nazivOruzija='" + updateData.nazivOruzija +
                "', kalibar='" + updateData.kalibar + "', adresaSlike='" + updateData.slika + "', dodatniOpis='" + updateData.dodatniOpis +
                "'WHERE seriskiBroj='" + seriskiBroj + "'";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            MessageBox.Show("Oruzije je uspjesno izmjenjeno.", "Informacija");
        }

        //radi za lovce
        //Delete statement
        public void Delete(String maticniAktivnogLovca)
        {
            List<String> seriskiBrojevi = new List<String>();
            string query = "SELECT * FROM Lovac_has_oruzije WHERE lovac_JMBG='" + maticniAktivnogLovca + "'";
            String pom;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    pom = dataReader["oruzije_seriskiBroj"].ToString();
                    seriskiBrojevi.Add(pom);
                }
                dataReader.Close();
                this.CloseConnection();
            }
            query = "DELETE FROM lovac_has_oruzije WHERE lovac_JMBG='" + maticniAktivnogLovca + "'";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            query = "DELETE FROM lovac WHERE JMBG='" + maticniAktivnogLovca + "'";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            for (int i = 0; i < seriskiBrojevi.Count(); i++)
            {
                query = "DELETE FROM oruzije WHERE seriskiBroj='" + seriskiBrojevi[i].ToString() + "'";
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            MessageBox.Show("Lovac je uspjesno obrisan.","Informacija");
        }

        //radi za oruzije
        //Delete statement
        public void Delete(String tabela, String seriskiBroj)
        {
            string query = "DELETE FROM lovac_has_oruzije WHERE oruzije_seriskiBroj='" + seriskiBroj + "'";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            query = "DELETE FROM " + tabela + " WHERE seriskiBroj='" + seriskiBroj + "'";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            MessageBox.Show("Oruzije je uspjesno obrisano.", "Informacija");
        }

        //za lovce radi sve
        //Select statement
        public List<Lovac> Select(String tabela)
        {
            string query = "SELECT * FROM " + tabela;
            Lovac pom;
            List<Lovac> list = new List<Lovac>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    pom = new Lovac();
                    pom.ime = dataReader["ime"].ToString();
                    pom.prezime = dataReader["prezime"].ToString();
                    pom.ocevoIme = dataReader["ocevoIme"].ToString();
                    pom.pol = dataReader["pol"].ToString();
                    pom.adresaPrebivalista = dataReader["adresaPrebivalista"].ToString();
                    pom.JMBG = dataReader["JMBG"].ToString();
                    pom.brojLicneKarte = dataReader["brojLicneKarte"].ToString();
                    pom.datumRodjenja = dataReader["datumRodjenja"].ToString();
                    pom.mjestoRodjenja = dataReader["mjestoRodjenja"].ToString();
                    pom.opstinaRodjenja = dataReader["opstinaRodjenja"].ToString();
                    pom.kontaktTelefon = dataReader["kontaktTelefon"].ToString();
                    pom.emailAdresa = dataReader["emailAdresa"].ToString();
                    pom.statusClana = dataReader["statusClana"].ToString();
                    pom.brojOdradjenihDnevnica = dataReader["brojOdradjenihDnevnica"].ToString();
                    pom.adresaSlike = dataReader["adresaSlike"].ToString();
                    if (dataReader["polozioIspit"].ToString() == "Da")
                    {
                        pom.polozioLovackiIspit = "Da";
                    }
                    if (dataReader["polozioIspit"].ToString() == "Ne")
                    {
                        pom.polozioLovackiIspit = "Ne";
                    }
                    if (dataReader["polozioIspit"].ToString() == "Nepoznato")
                    {
                        pom.polozioLovackiIspit = "Nepoznato";
                    }
                    pom.brojUvjerenja = dataReader["brojUvjerenja"].ToString();
                    pom.datumPolaganja = dataReader["datumPolaganja"].ToString();
                    pom.mjestoPolaganja = dataReader["mjestoPolaganja"].ToString();
                    pom.zanimanje = dataReader["zanimanje"].ToString();
                    if (dataReader["zaposlen"].ToString() == "Da")
                    {
                        pom.zaposlen = "Da";
                    }
                    if (dataReader["zaposlen"].ToString() == "Ne")
                    {
                        pom.zaposlen = "Ne";
                    }
                    if (dataReader["zaposlen"].ToString() == "Nepoznato")
                    {
                        pom.zaposlen = "Nepoznato";
                    }
                    pom.firmaUKojojRadi = dataReader["firmaUKojojRadi"].ToString();
                    pom.dodatniOpis = dataReader["dodatniOpis"].ToString();

                    list.Add(pom);
                }
                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }

        public List<Lovac_has_oruzije> Select_ref(String tabela_ref)
        {
            string query = "SELECT * FROM " + tabela_ref;
            Lovac_has_oruzije pom;
            List<Lovac_has_oruzije> list = new List<Lovac_has_oruzije>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    pom = new Lovac_has_oruzije();
                    pom.lovacJMBG = dataReader["lovac_JMBG"].ToString();
                    pom.oruzijeSeriskiBroj = dataReader["oruzije_seriskiBroj"].ToString();
                    list.Add(pom);
                }
                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }

        public List<Oruzije> Select_oruzije(String tabela_Oruzije)
        {
            string query = "SELECT * FROM " + tabela_Oruzije;
            Oruzije pom;
            List<Oruzije> list = new List<Oruzije>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                List<String> seriskiBrojevi = new List<String>();

                while (dataReader.Read())
                {
                    pom = new Oruzije();
                    pom.tipOruzija = dataReader["tipOruzija"].ToString();
                    pom.nazivOruzija = dataReader["nazivOruzija"].ToString();
                    pom.kalibar = dataReader["kalibar"].ToString();
                    pom.seriskiBroj = dataReader["seriskiBroj"].ToString();
                    pom.slika = dataReader["adresaSlike"].ToString();
                    pom.dodatniOpis = dataReader["dodatniOpis"].ToString();
                    list.Add(pom);
                }
                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }
    }
}
