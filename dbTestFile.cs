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
            p.x = 34;
            p.y = 545;
            p.Id = 0;

            try {
                p.saveStateToDB();
                List<(int, int)> j = p.getStates();
                foreach((int, int) element in j) {
                    Console.WriteLine($"{element}");
                }
                Console.WriteLine("Success!");


            } finally {
                Console.ReadKey();
            }
        }
    }
}

