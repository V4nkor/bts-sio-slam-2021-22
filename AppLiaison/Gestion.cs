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
            Liaison test = new Liaison("jj", "dd", "10h");
            ll.Add(test);
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
            TextReader reader;
            string fileName = "liaisons.txt";
            reader = new StreamReader(fileName, System.Text.Encoding.Default);

            string line = reader.ReadLine();

            while (line != null)
            {
                
                line = reader.ReadLine();
                //Liaison test = new Liaison(line[0], line[1], line[2]);
                //ll.Add(test);

            }


            reader.Close();
        }
        public static void modification(Liaison liaison)
        {
            string line = liaison.Depart + " - " + liaison.Arrivee + " " + liaison.Heure;
        }
        public static void suppression(Liaison liaison)
        {

        }
        public static void ajout(Liaison liaison)
        {
            string fileName = "liaisons.txt";
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(fileName).ToList();

            string ajout_liaison = liaison.Depart + " - " + liaison.Arrivee + " " + liaison.Heure;
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