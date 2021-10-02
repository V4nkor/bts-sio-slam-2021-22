using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLiaison
{
    public partial class Operation : Form
    {
        public Operation()
        {
            InitializeComponent();
            if (Gestion.Cas == 1)
            {
                this.Text = "Ajout";
            }
            else if (Gestion.Cas == 2)
            {
                this.Text = "Modification";
                tb1.Text = Gestion.SetL.Depart;
                tb2.Text = Gestion.SetL.Arrivee;
                tb3.Text = Gestion.SetL.Heure;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Gestion.Cas == 1)
            {
                Liaison nouvLiaison = new Liaison(tb1.Text, tb2.Text, tb3.Text);
                Gestion.ajout(nouvLiaison);
                Close();
            }
            else if (Gestion.Cas == 2)
            {
                Gestion.SetL.Depart = tb1.Text;
                Gestion.SetL.Arrivee = tb2.Text;
                Gestion.SetL.Heure = tb3.Text;

                Gestion.modification(Gestion.SetL);
                Close();
                tb2.Text = Gestion.SetL.Arrivee;
                tb3.Text = Gestion.SetL.Heure;
            }
        }
    }
}
