using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plz_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ControllerServer c = new ControllerServer();
            c.start();
        }
    }
}
