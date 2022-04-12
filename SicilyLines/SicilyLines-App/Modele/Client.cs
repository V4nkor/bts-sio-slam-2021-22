using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sicily
{
        [Serializable]
        public class Client
        {
            private int num;
            private string nom;
            private string prenom;
            private string adresse;
            private List<Compte> comptes = new List<Compte>();
           
            public Client(int num, string nom, string prenom, string ad)
            {
                this.num = num;
                this.nom = nom;
                this.prenom = prenom;
                this.adresse = ad;
            }
        public Client()
        {
            
        }
        public int Numero
            {
                get { return num; }
                set { num = value; }
        }
            public string Nom
            {
                get { return nom; }
            }
            public string Prénom
            {
                get { return prenom; }
            }
            public string Adresse
            {
                get { return adresse; }
                set { adresse = value; }
            }

            public override string ToString()

            {
               
                return (  this.num + "   " + this.nom + " " + this.prenom  + " " + this.adresse);
            }

        }


    }

