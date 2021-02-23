using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using AllFiles.Library.Models;

namespace AllFiles.DB {
    public class dataAccess {
        public List<(int, int)> loadAllPlayerStates() {
            using(IDbConnection cnn = new SQLiteConnection(loadConnectionString())) {
                cnn.Open();
                return (List<(int, int)>)cnn.Query<(int, int)>("SELECT ALL x, y FROM playerPosition", new DynamicParameters());
            }
        }

        public void saveCurrentPlayerState(playerModel player) {
            
            using(IDbConnection cnn = new SQLiteConnection(loadConnectionString())) {
                cnn.Open();
                cnn.Execute("INSERT INTO playerPosition (x, y) VALUES (@x, @y)", player);
                Console.WriteLine($"{player.x}, {player.y}, {player}");
            }
                
        }

        private string loadConnectionString(string id = "DB") {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
