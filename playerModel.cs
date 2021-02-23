using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllFiles.DB;

namespace AllFiles.Library.Models {
    public class playerModel {

        public int Id { get; set; }
        public int x { get; set; }
        public int y { get; set; } 

        public List<int> position = new List<int>();

        public List<int> fullPosition {
            get {   
                
                position.Add(x);
                position.Add(y);
                return position;

            }
        }

        public void saveStateToDB() {
            dataAccess a = new dataAccess();
            a.saveCurrentPlayerState(this);
        }

        public List<(int, int)> getStates() {
            dataAccess a = new dataAccess();
            return a.loadAllPlayerStates();
        }
    }
}
