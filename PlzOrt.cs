using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plz_Server
{
    class PlzOrt
    {
        private String osm_id;
        private String plz;
        private String ort;
        private String bundesland;

        public PlzOrt(String osm_id, String plz, String ort, String bundesland)
        {
            this.osm_id = osm_id;
            this.plz = plz;
            this.ort = ort;
            this.bundesland = bundesland;
        }

        // Nur getter, da Datenbestand fest ist
        public String Osm_id
        {
            get { return this.osm_id; }
        }
        public String Plz
        {
            get { return this.plz; }
        }
        public String Ort
        {
            get { return this.ort; }
        }
        public String Bundesland
        {
            get { return this.bundesland; }
        }
    }
}
