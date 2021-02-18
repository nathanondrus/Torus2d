using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AllFiles.DB.dataAccess;
using AllFiles.Library.Models;

namespace AllFiles.DB {
    class dbTestFile { 
        static void Main() {
            playerModel p = new Library.Models.playerModel();
            p.x = 38;
            p.y = 21;
            p.Id = 0;

            try {
                p.saveStateToDB();
                var j = p.getStates();
                Console.WriteLine(j);
                Console.WriteLine("Success!");
                Console.ReadKey();

            } catch(Exception) {
                Console.WriteLine("Fail");
            }
        }
    }
}
