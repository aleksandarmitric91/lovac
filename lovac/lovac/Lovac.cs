using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lovac
{
    class Lovac
    {
        public String ime;
        public String prezime;
        public String ocevoIme;
        public String pol;
        public String adresaPrebivalista;
        public String JMBG;
        public String brojLicneKarte;
        public String datumRodjenja;
        public String mjestoRodjenja;
        public String opstinaRodjenja;
        public String kontaktTelefon;
        public String emailAdresa;
        public String statusClana;
        public String brojOdradjenihDnevnica;
        public String adresaSlike;
        public String polozioLovackiIspit;
        public String brojUvjerenja;
        public String datumPolaganja;
        public String mjestoPolaganja;
        public String zanimanje;
        public String zaposlen;
        public String firmaUKojojRadi;
        public String dodatniOpis;

        public Lovac()
        {}

        public Lovac(String ime, String prezime, String ocevoIme, String pol, String adresaPrebivalista,
            String JMBG, String brojLicneKarte, String datumRodjenja, String mjestoRodjenja,
            String opstinaRodjenja, String kontaktTelefon, String emailAdresa, String statusClana,
            String brojOdradjenihDnevnica, String adresaSlike, String polozioLovackiIspit,
            String brojUvjerenja, String datumPolaganja, String mjestoPolaganja, String zanimanje, 
            String zaposlen, String firmaUKojojRadi, String dodatniOpis)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.ocevoIme = ocevoIme;
            this.pol = pol;
            this.adresaPrebivalista = adresaPrebivalista;
            this.JMBG = JMBG;
            this.brojLicneKarte = brojLicneKarte;
            this.datumRodjenja = datumRodjenja;
            this.mjestoRodjenja = mjestoRodjenja;
            this.opstinaRodjenja = opstinaRodjenja;
            this.kontaktTelefon = kontaktTelefon;
            this.emailAdresa = emailAdresa;
            this.statusClana = statusClana;
            this.brojOdradjenihDnevnica = brojOdradjenihDnevnica;
            this.adresaSlike = adresaSlike;
            this.polozioLovackiIspit = polozioLovackiIspit;
            this.brojUvjerenja = brojUvjerenja;
            this.datumPolaganja = datumPolaganja;
            this.mjestoPolaganja = mjestoPolaganja;
            this.zanimanje = zanimanje;
            this.zaposlen = zaposlen;
            this.firmaUKojojRadi = firmaUKojojRadi;
            this.dodatniOpis = dodatniOpis;
        }
    }
}
