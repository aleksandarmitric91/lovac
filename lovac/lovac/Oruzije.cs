using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lovac
{
    class Oruzije
    {
        public String tipOruzija;
        public String nazivOruzija;
        public String kalibar;
        public String seriskiBroj;
        public String slika;
        public String dodatniOpis;

        public Oruzije() { }

        public Oruzije(String tipOruzija, String nazivOruzija, String kalibar, String seriskiBroj, String slika, String dodatniOpis)
        {
            this.tipOruzija = tipOruzija;
            this.nazivOruzija = nazivOruzija;
            this.kalibar = kalibar;
            this.seriskiBroj = seriskiBroj;
            this.slika = slika;
            this.dodatniOpis = dodatniOpis;
        }
    }
}
