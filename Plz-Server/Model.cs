using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plz_Server
{
    class Model
    {
        // Die Klasse Model übernimmt den Zugriff auf die
        // zugrunde liegenden Daten. Alle Lese- und Schreib-
        // operationen werden durch die Klasse Model abgewickelt.

        // Objektvariable für Zugriff auf Liste mit allen Datensätzen
        private List<PlzOrt> plzort;

        public Model()
        {
            // Leere Liste erzeugen
            plzort = new List<PlzOrt>();

            // Datendatei lesen und PlzOrt-Objekte erzeugen
            // und in der Liste ablegen
            lesePlzOrtDatei();
        }

        // Hiermit kann im Datenbestand nach der Plz für
        // einen Ort gesucht werden.
        // Es wird für jede gefundene Plz für diesen Ort
        // ein PlzOrt-Objekt erzeugt, in einer Liste gespeichert
        // und die Liste zurück geliefert; ggfs. eine leere Liste.
        public List<PlzOrt> suchePlz(string ort)
        {
            // leere Ergebnisliste erstellen
            List<PlzOrt> ergebnis = new List<PlzOrt>();

            // Jedes Element in der Liste überprüfen
            // Hier wäre eine Lambda-Funktion hilfreicher, kürzer und
            // wahrscheinlich schneller ;)
            foreach (PlzOrt po in plzort)
            {
                if (po.Ort.Contains(ort) )
                {
                    PlzOrt plzort = new PlzOrt(po.Osm_id,
                                                  po.Plz,
                                                  po.Ort,
                                                  po.Bundesland
                                                 );
                    ergebnis.Add(plzort);
                }
            }
            return ergebnis;
        }

        // Liefert die Anzahl der Datensätze in der Liste
        public int Count
        {
            get { return plzort.Count; }
        }

        // Hilfsmethode, nur innerhalb der Klasse notwendig
        // Liest die Datei zuordnung_plz_ort.csv und erstellt PlzOrt-Objekte
        private bool lesePlzOrtDatei()
        {
            // Hiermit könnte Erfolg oder Misserfolg der
            // Methode zurückgemeldet werden
            // Besser wäre, bei Misserfolg eine Ausnahme zu werfen
            bool rc = true;

            // automatische Freigabe der Ressourcen mittels using
            using (StreamReader sr = new StreamReader(@"zuordnung_plz_ort.csv"))
            {
                // Nimmt gelesene Zeile auf
                string zeile;

                // Lesen bis Dateiende, Zeile für Zeile
                while ((zeile = sr.ReadLine()) != null)
                {
                    // Person-Objekt erstellen anhand gelesener Zeile
                    PlzOrt po = convertString2PlzOrt(zeile);

                    // Person-Objekt in die Liste einfügen
                    plzort.Add(po);
                }
            }

            return rc;
        }

        // Hilfsmethode, nur innerhalb der Klasse notwendig
        // Umwandeln eines einzelnen Datensatzes ds in
        // ein Objekt vom Typ PlzOrt anhand des Trennzeichens ","
        private PlzOrt convertString2PlzOrt(string ds)
        {
            char[] separator = { ',' };
            // Der String ds wird aufgetrennt und in einem String-Array abgelegt
            string[] daten = ds.Split(separator);

            // PlzOrt-Objekt erstellen und der Liste hinzufügen
            PlzOrt po = new PlzOrt(daten[0], daten[1], daten[2], daten[3]);

            return po;
        }

        public string getName(string PLZ)
        {
            foreach( var a in plzort)
            {
                if(a.Ort == PLZ )
                {
                    return a.Plz;
                }
                else {  }
            }
            return "NOT FOUND";
            
        }
        public string getPLZ(string name)
        {
            foreach (var a in plzort)
            {
                if (a.Plz.ToUpper() == name.ToUpper())
                {
                    return a.Ort;
                }
                
                else { }
            }
            return "NOT FOUND";

        }
    }
}
