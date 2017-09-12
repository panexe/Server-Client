using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using __ServerSocket__;
using __ClientSocket__;


namespace Plz_Server
{
    enum ServerCommand
    {
        NONE,
        GETCOUNT,
        GETNAME,
        GETPLZ
    }
    class ControllerServer
    {
        // Objektvariable für das Datenmodell
        private Model model;

        // Objektvariable für ServerSocket
        private ServerSocket s;

        // Objektvariable für ServerSocket
        private ClientSocket cs = null;

        public ControllerServer()
        {
            // ServerSocket an Port binden
            // hier wäre eine Ausnahmebehandlung sinnvoll!
            s = new ServerSocket(55555);

            // Datenmodell erstellen
            // hier wäre eine Ausnahmebehandlung sinnvoll!
            model = new Model();
        }

        // Mit dieser Methode wird der Controller gestartet
        public void start()
        {
            Console.WriteLine("Anzahl Datensätze: {0}", model.Count);

            Console.WriteLine("Server wird gestartet!");

            // Server läuft in einer Endlosschleife
            do
            {
                // Auf Verbindungswunsch mit Client warten
                cs = s.accept();

                Console.WriteLine("Verbindung zu Client geöffnet!");

                // Der folgende Teil würde in einen separaten Thread ausgelagert,
                // um den Server wieder für neue Verbindungen zu öffnen
                // Dieser Thread würde den Client-Socket als Parameter
                // für die weitere Kommnikation erhalten

                // Client-Socket liest Kommando vom Client
                ServerCommand command = (ServerCommand)cs.read();

                // Kommando wird ausgewertet
                // Es werden entsprechende Methoden aufgerufen
                switch (command)
                {
                    case ServerCommand.NONE:
                        break;

                    case ServerCommand.GETCOUNT:
                        // kein Methodenaufruf
                        // es wird direkt die Anzahl der Datensätze gesendet
                        // Leider muss die Anzahl als String gesendet werden, da
                        // der int-Wert intern auf ein Byte redutiert wird!
                        cs.write(model.Count.ToString() +"\n");
                        Console.WriteLine("Anzahl der Datensätze erfragt");
                        break;

                    case ServerCommand.GETNAME:

                        string a = cs.readLine();
                        string name = model.getName(a);
                        Console.WriteLine(name + "TEST" + a);
                        cs.write(name + "\n");
                        break;

                    case ServerCommand.GETPLZ:
                        string b = cs.readLine();
                        string plz = model.getPLZ(b);
                        cs.write(plz + "\n");
                        break;

                    default:
                        break;
                } // Ende switch

                // ClientSocket schließen
                cs.close();
                // und auf null setzen
                cs = null;

                Console.WriteLine("Verbindung zu Client geschlossen!");

            } while (true);

        }


    }
}
