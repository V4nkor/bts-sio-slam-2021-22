using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sicily.DAL;

namespace Sicily.Controleur
{
    class Mgr
    {

        CompteDao cd = new CompteDao();
        ClientDao cld = new ClientDao();

    
      

        public List<Client> chargementClBD()
        {

            return(cld.getClients());

        }

        public List<Compte> chargementCBD( Client cl)
        {

            return (cd.getComptes(cl));

        }

        public void updateClient(Client c)
        {

            cld.updateClient(c);

        }

        public void updateSolde(Compte c)
        {

            cd.updateSolde(c);

        }

        public void updateDecouvert(Compte c)
        {

            cd.updateDecouvert(c);

        }


    }
}
