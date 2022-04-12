using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sicily.DAL
{
    class CompteDao
    {



        private Client cl;

        private ConnexionSql maConnexionSql;




        private MySqlCommand Ocom;

        private ClientDao cld;




        public List<Compte> getComptes()
        {

            List<Compte> lc = new List<Compte>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);




                maConnexionSql.openConnection();



                Ocom = maConnexionSql.reqExec("Select * from compte");

                MySqlDataReader reader = Ocom.ExecuteReader();

                cld = new ClientDao();


                while (reader.Read())
                {

                    int numCompte = (int)reader.GetValue(0);
                    int solde = (int)reader.GetValue(1);
                    int decouvert = (int)reader.GetValue(2);
                    int numClient = (int)reader.GetValue(3);



                    cl = cld.getClient(numClient);


                    Compte c = new Compte(numCompte, cl);
                    c.crediter(solde);
                    c.DecouvertAutorisé = decouvert;


                    lc.Add(c);



                }

                reader.Close();

                maConnexionSql.closeConnection();


                return (lc);

            }

            catch (Exception emp)
            {

                MessageBox.Show(emp.Message);

            }
            return (lc);
        }


        public List<Compte> getComptes(Client cl)
        {

            // A compléter
            List<Compte> lc = new List<Compte>();

            try
            {

                maConnexionSql = ConnexionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);

                maConnexionSql.openConnection();



                Ocom = maConnexionSql.reqExec("Select * from compte INNER JOIN client ON compte.numClient = client.numero where client.numero = " + cl.Numero);

                MySqlDataReader reader = Ocom.ExecuteReader();

               


                while (reader.Read())
                {

                    int numCompte = (int)reader.GetValue(0);
                    double solde = (double)reader.GetValue(1);
                    double decouvert = (double)reader.GetValue(2);
                    int numClient = (int)reader.GetValue(3);



                    Compte c = new Compte(numCompte, cl);
                    c.crediter(solde);
                    c.DecouvertAutorisé = decouvert;


                    lc.Add(c);



                }

                reader.Close();

                maConnexionSql.closeConnection();


                return (lc);

            }

            catch (Exception emp)
            {

                MessageBox.Show(emp.Message);

            }
            return (lc);

        }

       

        public void updateSolde(Compte c)
        {

            try
            {


                maConnexionSql = ConnexionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("update compte set solde = '" + c.Solde + "' where numCompte = " + c.Numéro);


                int i = Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();



            }

            catch (Exception emp)
            {

                throw (emp);
            }

        }

        

        public void updateDecouvert(Compte c)
        {


            try
            {


                maConnexionSql = ConnexionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("update compte set decouvert = '" + c.DecouvertAutorisé + "' where numCompte = " + c.Numéro);


                int i = Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();



            }

            catch (Exception emp)
            {

                throw (emp);
            }

        }

        
    }
}
