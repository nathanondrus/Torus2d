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
        public List<playerModel> loadAllPlayerStates() {
            using(IDbConnection cnn = new SQLiteConnection(loadConnectionString())) {

                var output = cnn.Query<playerModel>("select * from playerPosition", new DynamicParameters());
                return output.ToList();
            }
        }

        public void saveCurrentPlayerState(playerModel player) {
            
            using(IDbConnection cnn = new SQLiteConnection(loadConnectionString())) {

                cnn.Execute("insert into playerPosition(x, y) values(@x, @y)", player);
                Console.WriteLine($"{player.x}, {player.y}, {player}");
            }
                
        }

        private string loadConnectionString(string id = "playerPosition") {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
