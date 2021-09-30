using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLiaison
{
    public class Liaison
    {
        private string depart;
        private string arrivee;
        private string heure;

        /// 

        /// Liaison
        public Liaison(string unDepart, string unArrivee, string unHeure) {
            this.depart = unDepart;
            this.arrivee = unArrivee;
            this.heure = unHeure;
        }

        /// Description
        public string Description {
			get{return "Départ: "+ depart + " , Arrivée: "+ arrivee + " Heure " + heure;}
		}

    }
}
