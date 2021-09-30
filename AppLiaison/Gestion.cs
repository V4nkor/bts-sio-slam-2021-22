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
    public partial class Gestion : Form
    {
        List<Liaison> ll;
        public static Liaison SetL;
        public static int Cas;
        public Gestion()
        {
            InitializeComponent();
            ll = new List<Liaison>();
            lecture();
            Liaison test = new Liaison("test", "test", "10h30");
            ll.Add(test);
            refresh();
        }
        public void refresh()
        {
            lb.DataSource = null;
            lb.DataSource = ll;
            lb.DisplayMember = "Description";
        }
        public void lecture()
        {

        }
        public static void modification(Liaison laison)
        {

        }
        public static void suppression(Liaison liaison)
        {

        }
        public static void ajout(Liaison liaison)
        {

        }
        private void btn_Click(object sender, EventArgs e)
        {
            if(btn.Text == "Modifier")
            {
                SetL = (Liaison)lb.SelectedItem;
                Operation operation = new Operation();
                operation.ShowDialog();
            }
            else if(btn.Text == "Supprimer")
            {
                SetL = (Liaison)lb.SelectedItem;
                Verif verif = new Verif();
                verif.ShowDialog();
            }
            else if(btn.Text == "Ajout")
            {
                Operation operation = new Operation();
                operation.ShowDialog();
            }
            lecture();
            refresh();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn.Enabled = true;
            btn.Text = "Ajout";
            Cas = 1;
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn.Enabled = true;
            btn.Text = "Modifier";
            Cas = 2;
        }

        private void suprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn.Enabled = true;
            btn.Text = "Supprimer";
        }
    }
}