using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            Liaison test = new Liaison("Jésus", "Oui", "10h");
            ll = lecture(ll);
            refresh();
        }
        public void refresh()
        {
            lb.DataSource = null;
            lb.DataSource = ll;
            lb.DisplayMember = "Description";
        }
        public List<Liaison> lecture(List<Liaison> ll)
        {
            string fileName = "liaisons.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(fileName).ToList();
            
            foreach(string ligne in lines)
            {
                string[] mots = ligne.Split(';');
                Liaison liais = new Liaison(mots[0], mots[1], mots[2]);
                ll.Add(liais);
            }

            return ll;
        }
        public static void suppression(Liaison liaison)
        {
            string fileName = "liaisons.txt";
            string suppr_liaison = liaison.Depart + ";" + liaison.Arrivee + ";" + liaison.Heure;
            var lines = File.ReadAllLines(fileName).Where(line => line.Trim() != suppr_liaison).ToArray();
            File.WriteAllLines(fileName, lines);

        }
        public static void modification(Liaison ancienneLiaison, Liaison nouvelleLiaison)
        {
            string fileName = "liaisons.txt";
            string suppr_liaison = ancienneLiaison.Depart + ";" + ancienneLiaison.Arrivee + ";" + ancienneLiaison.Heure;
            var lines = File.ReadAllLines(fileName).Where(line => line.Trim() != suppr_liaison).ToArray();
            File.WriteAllLines(fileName, lines);

            List<string> newLines = new List<string>();
            newLines = File.ReadAllLines(fileName).ToList();

            string modif_liaison = nouvelleLiaison.Depart + ";" + nouvelleLiaison.Arrivee + ";" + nouvelleLiaison.Heure;
            newLines.Add(modif_liaison);
            File.WriteAllLines(fileName, newLines);

        }
        public static void ajout(Liaison liaison)
        {
            string fileName = "liaisons.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(fileName).ToList();

            string ajout_liaison = liaison.Depart + ";" + liaison.Arrivee + ";" + liaison.Heure;
            lines.Add(ajout_liaison);
            File.WriteAllLines(fileName, lines);
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
            ll.Clear();
            lecture(ll);
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
            SetL = (Liaison)lb.SelectedItem;
            Verif verif = new Verif();
            verif.ShowDialog();
            ll.Clear();
            ll = lecture(ll);
            refresh();
        }
    }
}