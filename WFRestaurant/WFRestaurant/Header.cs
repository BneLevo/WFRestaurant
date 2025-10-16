using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFRestaurant
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            // ça ferme la fenêtre parente (la fenêtre actuelle)
            this.Parent.Hide();
        }

        private void picPanier_Click(object sender, EventArgs e)
        {
            Panier panier = new Panier();
            panier.Show();
            // ça ferme la fenêtre parente (la fenêtre actuelle)
            this.Parent.Hide();
        }
    }
}
