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
            }
        }
    }
}
