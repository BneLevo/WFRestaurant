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
    public partial class Panier : Form
    {
        public Panier()
        {
            InitializeComponent();
        }

        private void Panier_Load(object sender, EventArgs e)
        {
            DisplayArticles.Controls.Clear();
            // Affiche les articles du panier
            BagManager.DisplayBag(DisplayArticles);
            UpdateBagTotal();
        }

        // Met à jour le label du total du panier
        private void UpdateBagTotal()
        {
            int total = BagManager.Bag.Sum(a => a.Price);
            lblTotal.Text = $"Total : {total}.-";
        }

        private void btnResto_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
