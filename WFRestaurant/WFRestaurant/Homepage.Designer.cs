namespace WFRestaurant
{
    partial class Homepage
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.header1 = new WFRestaurant.Header();
            this.SuspendLayout();
            // 
            // btnNourriture
            // 
            this.btnNourriture.Location = new System.Drawing.Point(33, 321);
            this.btnNourriture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNourriture.Name = "btnNourriture";
            this.btnNourriture.Size = new System.Drawing.Size(175, 36);
            this.btnNourriture.TabIndex = 0;
            this.btnNourriture.Text = "Nourriture";
            this.btnNourriture.UseVisualStyleBackColor = true;
            this.btnNourriture.Click += new System.EventHandler(this.btnNourriture_Click);
            // 
            // btnBoissons
            // 
            this.btnBoissons.Location = new System.Drawing.Point(33, 394);
            this.btnBoissons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBoissons.Name = "btnBoissons";
            this.btnBoissons.Size = new System.Drawing.Size(175, 36);
            this.btnBoissons.TabIndex = 1;
            this.btnBoissons.Text = "Boissons";
            this.btnBoissons.UseVisualStyleBackColor = true;
            this.btnBoissons.Click += new System.EventHandler(this.btnBoissons_Click);
            // 
            // btnDessert
            // 
            this.btnDessert.Location = new System.Drawing.Point(33, 463);
            this.btnDessert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDessert.Name = "btnDessert";
            this.btnDessert.Size = new System.Drawing.Size(175, 36);
            this.btnDessert.TabIndex = 2;
            this.btnDessert.Text = "Dessert";
            this.btnDessert.UseVisualStyleBackColor = true;
            this.btnDessert.Click += new System.EventHandler(this.btnDessert_Click);
            // 
            // btnTout
            // 
            this.btnTout.Location = new System.Drawing.Point(33, 251);
            this.btnTout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTout.Name = "btnTout";
            this.btnTout.Size = new System.Drawing.Size(175, 36);
            this.btnTout.TabIndex = 3;
            this.btnTout.Text = "Tout";
            this.btnTout.UseVisualStyleBackColor = true;
            this.btnTout.Click += new System.EventHandler(this.btnTout_Click);
            // 
            // DisplayArticles
            // 
            this.DisplayArticles.AutoScroll = true;
            this.DisplayArticles.Location = new System.Drawing.Point(292, 144);
            this.DisplayArticles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DisplayArticles.Name = "DisplayArticles";
            this.DisplayArticles.Size = new System.Drawing.Size(993, 519);
            this.DisplayArticles.TabIndex = 4;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(28, 623);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(175, 25);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total : 0.-";
            // 
            // header1
            // 
            this.header1.Location = new System.Drawing.Point(33, 14);
            this.header1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(1211, 123);
            this.header1.TabIndex = 6;
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 699);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.DisplayArticles);
            this.Controls.Add(this.btnTout);
            this.Controls.Add(this.btnDessert);
            this.Controls.Add(this.btnBoissons);
            this.Controls.Add(this.btnNourriture);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Homepage";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNourriture;
        private System.Windows.Forms.Button btnBoissons;
        private System.Windows.Forms.Button btnDessert;
        private System.Windows.Forms.Button btnTout;
        private System.Windows.Forms.FlowLayoutPanel DisplayArticles;
        private System.Windows.Forms.Label lblTotal;
        private Header header1;
    }
}

