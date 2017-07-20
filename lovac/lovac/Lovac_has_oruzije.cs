using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lovac
{
    class Lovac_has_oruzije
    {
        public String lovacJMBG;
        public String oruzijeSeriskiBroj;

        public Lovac_has_oruzije() {}

        public Lovac_has_oruzije(String lovacJMBG, String oruzijeSeriskiBroj)
        {
            this.lovacJMBG = lovacJMBG;
            this.oruzijeSeriskiBroj = oruzijeSeriskiBroj;
        }
    }
}
