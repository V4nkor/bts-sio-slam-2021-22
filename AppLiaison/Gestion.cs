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
        public void modification()
        {

        }
        public static void suppression(Liaison liaison)
        {

        }
        private void btn_Click(object sender, EventArgs e)
        {
            if(btn.Text == "Modifier")
            {
                Liaison l = (Liaison)lb.SelectedItem;
            }
            else if(btn.Text == "Supprimer")
            {
                Liaison l = (Liaison)lb.SelectedItem;
            }
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
            SetL = (Liaison)lb.SelectedItem;
            Cas = 2;
        }

        private void suprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn.Enabled = true;
            btn.Text = "Supprimer";
            SetL = (Liaison)lb.SelectedItem;
            Verif verif = new Verif();
            verif.ShowDialog();
            lecture();
            refresh();
        }
    }
}