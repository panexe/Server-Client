using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using __ClientSocket__;

namespace Plz_Client_Console
{
    enum ServerCommand
    {
        NONE,
        GETCOUNT,
        GETNAME,
        GETPLZ
    }

    class ControllerClient
    {
        private ClientSocket client;
        private ClientView view;
        private string host;
        private int port;

        public ControllerClient(string _host, int _port)
        {
            host = _host;
            port = _port;
            // Zugriff auf die View
            view = new ClientView();
        }

        // Hiermit wird der Client gestartet
        public int start()
        {
            // Hier erfolgt die Interaktion mit dem Benutzer
            // Die Ausgaben können in einem View-Objekt erfolgen

            int eingabe = 0;

            // Menü ausgeben und Auswahl treffen
            eingabe = menue();

            switch (eingabe)
            {
                // Suche Personen
                case 1:
                    holeAnzahlDatensaetze();
                    break;

                case 2:
                    Console.WriteLine("Nennen sie eine PLZ:");
                    getName(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Nennen sie eine Stadt:");
                    getPLZ(Console.ReadLine());
                    break;

                // Programmende
                case 9:
                    break;

                default:
                    break;
            } // Ende switch

            return eingabe;
        }

        private int menue()
        {
            int auswahl = 0;

            view.zeigeMenue();

            // Auswahl lesen
            string read = Console.ReadLine();
            Console.Clear();
            int a;
            if(int.TryParse(read,out a))
            do
            {
                auswahl = Convert.ToInt32(read);
            } while (auswahl < 1 || auswahl > 9);

            // Auswahl zurückliefern
            return auswahl;
        }


        private void holeAnzahlDatensaetze()
        {
            try
            {
                //ClientSocket-Objekt erstellen
                client = new ClientSocket(host, port);

                // Verbindung mit Server herstellen
                client.connect();

                // Kommando senden
                client.write((int)ServerCommand.GETCOUNT);

                // Anzahl Datensätze empfangen
                String anzahldatensaetze = client.readLine();
                view.zeigeAnzahlDatensaetze(Convert.ToInt32(anzahldatensaetze));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void getName(string name)
        {
            try
            {
                client = new ClientSocket(host, port);
                client.connect();
                client.write((int)ServerCommand.GETNAME);
                client.write(name);
                string plz = client.readLine();
                view.zeigeName(name, plz);

            }catch(Exception ex)
            {
                throw ex;
            }
        }
        private void getPLZ(string plz)
        {
            try
            {
                client = new ClientSocket(host, port);
                client.connect();
                client.write((int)ServerCommand.GETPLZ);
                client.write(plz);
                string name = client.readLine();
                view.zeigeName(name, plz);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
