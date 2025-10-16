namespace WFRestaurant
{
    partial class Panier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DisplayArticles = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.header1 = new WFRestaurant.Header();
            this.SuspendLayout();
            // 
            // DisplayArticles
            // 
            this.DisplayArticles.AutoScroll = true;
            this.DisplayArticles.Location = new System.Drawing.Point(139, 121);
            this.DisplayArticles.Name = "DisplayArticles";
            this.DisplayArticles.Size = new System.Drawing.Size(804, 435);
            this.DisplayArticles.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(11, 535);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(88, 20);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total : 0.-";
            // 
            // header1
            // 
            this.header1.Location = new System.Drawing.Point(35, 12);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(908, 100);
            this.header1.TabIndex = 9;
            // 
            // Panier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 568);
            this.Controls.Add(this.header1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.DisplayArticles);
            this.Name = "Panier";
            this.Text = "Panier";
            this.Load += new System.EventHandler(this.Panier_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel DisplayArticles;
        private System.Windows.Forms.Label lblTotal;
        private Header header1;
    }
}