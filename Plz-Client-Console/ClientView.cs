using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plz_Client_Console
{
    class ClientView
    {
        // Hierin wird alles Notwendige für
        // das Anzeigen der Daten gekapselt
        // die View soll nach außen festgelegte
        // Methoden enthalten und austauschbar sein
        // z.B. durch ein Formular


        public void zeigeMenue()
        {
            // Ausgabe Menue
            Console.WriteLine("1 - Hole Anzahl Datensätze");
            Console.WriteLine("2 - Hole Name durch PLZ");
            Console.WriteLine("3 - Hole PLZ durch Name");
            Console.WriteLine("9 - Programmende");
            Console.Write("Ihre Auswahl> ");
        }

        public void zeigeAnzahlDatensaetze(int anzahl)
        {
            Console.WriteLine("Anzahl Datensätze: {0}", anzahl);
        }

        public void zeigeName(string plz , string name)
        {
            Console.WriteLine("Die Stadt " + name + " hat die PLZ " + plz);
        }
        public void zeigePLZ(string plz, string name)
        {
            Console.WriteLine("Die PLZ " + plz + " gehört zur Stadt " + name);
        }
    }
}
