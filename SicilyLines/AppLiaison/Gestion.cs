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
using System.Diagnostics;

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
        public static void modification(List<Liaison> ll)
        {
            //tout changer utiliser liste existante pour reecrire le fichier en entier
            string fileName = "liaisons.txt";
            
            foreach(Liaison l in ll) {
                List<string> lesLignes = new List<string>();
                string ligne = l.Depart + ";" + l.Arrivee + ";" + l.Heure;
                lesLignes.Add(ligne);
                File.WriteAllLines(fileName, lesLignes);
            }

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
                ll.Clear();
                ll = lecture(ll);
                refresh();
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
        }

        private void ouvrirFichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //AppDomain.CurrentDomain.BaseDirectory amene dans le fichier debug de base
                Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "liaisons.txt"));
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}