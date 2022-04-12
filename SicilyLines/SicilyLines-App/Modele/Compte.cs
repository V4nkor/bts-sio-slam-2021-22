using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sicily
{
   
   /// <summary>
   /// Classe qui gère les comptes
   /// </summary>
 
    
    [Serializable]
    public class Compte
    {

        private int num;
		private Client proprio;
        private double solde;

        public double Solde
        {
            get { return solde; }
            set { solde = value; }
        }
        private double decouv = 0;

        

       

   
   /// <summary>
   /// méthode qui affecte un certain montant de découvert
   /// </summary>
   /// <param name="value">double représentant le découvert</param>
        
        
        public void setDecouv(double value)
        {


            
                if (this.solde > -value)
                {
                    decouv = value;
                  
                }

                else
                {
                   // throw new Exception("Impossible de modifier le découvert autorisé parce ce que le solde serait incompatible avec sa nouvelle valeur");
                    throw new DecouvertException();

                }

      
        }


      // On peut aussi utiliser celui là....
       // Set utilisé avec l'outil d'encapsultation
        public double DecouvertAutorisé
        {
            get { return decouv; }
            set
            {
                if (solde >= (-value))
                { decouv = value; }
                else
                {
                    throw new Exception("Impossible de modifier le découvert autorisé parce ce que le solde serait incompatible avec sa nouvelle valeur");
                }
            }
        }		
		
		public Compte()
		{
			
		}

		public Compte(int n, Client c)
		{
			num = n;
			solde =0;
			proprio = c;
		}

        public Compte(int n, double unSolde,double unDecouvert,  Client c)
        {
            this.num = n;
            this.solde = unSolde;
            this.DecouvertAutorisé = unDecouvert;
            this.proprio = c;
        }


        public int Numéro
		{
			get
			{return num;}
		}

		

		public virtual string Description
		{
            get { return "Compte n° " + num + " " + " Client :  " + proprio + " " + " solde : " + solde + " €" +" - decouvert : " + decouv + " €"; }
		}

        public Client Proprietaire
        {
            get { return proprio; }
        }

		
     

		public void crediter(double mont)
		{
			solde = solde+mont;
		}

		public bool débiter(double mont)
		{
			if (solde-mont <-decouv)
			{
				return false;
			}
			else
			{
				solde = solde - mont;
                return true;
			}
		}
		
    }
}
public class DecouvertException : Exception
{
    public DecouvertException() : base("Impossible de modifier le découvert autorisé") { }
}