namespace WFRestaurant
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNourriture = new System.Windows.Forms.Button();
            this.btnBoissons = new System.Windows.Forms.Button();
            this.btnDessert = new System.Windows.Forms.Button();
            this.btnTout = new System.Windows.Forms.Button();
            this.DisplayArticles = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPanier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNourriture
            // 
            this.btnNourriture.Location = new System.Drawing.Point(18, 268);
            this.btnNourriture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNourriture.Name = "btnNourriture";
            this.btnNourriture.Size = new System.Drawing.Size(196, 45);
            this.btnNourriture.TabIndex = 0;
            this.btnNourriture.Text = "Nourriture";
            this.btnNourriture.UseVisualStyleBackColor = true;
            this.btnNourriture.Click += new System.EventHandler(this.btnNourriture_Click);
            // 
            // btnBoissons
            // 
            this.btnBoissons.Location = new System.Drawing.Point(18, 358);
            this.btnBoissons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBoissons.Name = "btnBoissons";
            this.btnBoissons.Size = new System.Drawing.Size(196, 45);
            this.btnBoissons.TabIndex = 1;
            this.btnBoissons.Text = "Boissons";
            this.btnBoissons.UseVisualStyleBackColor = true;
            this.btnBoissons.Click += new System.EventHandler(this.btnBoissons_Click);
            // 
            // btnDessert
            // 
            this.btnDessert.Location = new System.Drawing.Point(18, 445);
            this.btnDessert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDessert.Name = "btnDessert";
            this.btnDessert.Size = new System.Drawing.Size(196, 45);
            this.btnDessert.TabIndex = 2;
            this.btnDessert.Text = "Dessert";
            this.btnDessert.UseVisualStyleBackColor = true;
            this.btnDessert.Click += new System.EventHandler(this.btnDessert_Click);
            // 
            // btnTout
            // 
            this.btnTout.Location = new System.Drawing.Point(18, 180);
            this.btnTout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTout.Name = "btnTout";
            this.btnTout.Size = new System.Drawing.Size(196, 45);
            this.btnTout.TabIndex = 3;
            this.btnTout.Text = "Tout";
            this.btnTout.UseVisualStyleBackColor = true;
            this.btnTout.Click += new System.EventHandler(this.btnTout_Click);
            // 
            // DisplayArticles
            // 
            this.DisplayArticles.AutoScroll = true;
            this.DisplayArticles.Location = new System.Drawing.Point(328, 180);
            this.DisplayArticles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DisplayArticles.Name = "DisplayArticles";
            this.DisplayArticles.Size = new System.Drawing.Size(1118, 649);
            this.DisplayArticles.TabIndex = 4;
            // 
            // btnPanier
            // 
            this.btnPanier.Location = new System.Drawing.Point(18, 535);
            this.btnPanier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPanier.Name = "btnPanier";
            this.btnPanier.Size = new System.Drawing.Size(196, 45);
            this.btnPanier.TabIndex = 5;
            this.btnPanier.Text = "Panier";
            this.btnPanier.UseVisualStyleBackColor = true;
            this.btnPanier.Click += new System.EventHandler(this.btnPanier_Click);
            // 
            // lblTotal
            // 
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotal.Location = new System.Drawing.Point(18, 620);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(196, 30);
            this.lblTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Text = "Total : 0.-";
            this.Controls.Add(this.lblTotal);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 874);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnPanier);
            this.Controls.Add(this.DisplayArticles);
            this.Controls.Add(this.btnTout);
            this.Controls.Add(this.btnDessert);
            this.Controls.Add(this.btnBoissons);
            this.Controls.Add(this.btnNourriture);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNourriture;
        private System.Windows.Forms.Button btnBoissons;
        private System.Windows.Forms.Button btnDessert;
        private System.Windows.Forms.Button btnTout;
        private System.Windows.Forms.FlowLayoutPanel DisplayArticles;
        private System.Windows.Forms.Button btnPanier;
        private System.Windows.Forms.Label lblTotal;
    }
}

