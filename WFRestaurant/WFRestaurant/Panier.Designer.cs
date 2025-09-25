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
            this.btnResto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DisplayArticles
            // 
            this.DisplayArticles.AutoScroll = true;
            this.DisplayArticles.Location = new System.Drawing.Point(195, 114);
            this.DisplayArticles.Name = "DisplayArticles";
            this.DisplayArticles.Size = new System.Drawing.Size(746, 389);
            this.DisplayArticles.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(24, 459);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(131, 20);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total : 0.-";
            // 
            // btnResto
            // 
            this.btnResto.Location = new System.Drawing.Point(24, 524);
            this.btnResto.Name = "btnResto";
            this.btnResto.Size = new System.Drawing.Size(131, 29);
            this.btnResto.TabIndex = 7;
            this.btnResto.Text = "Restaurant";
            this.btnResto.UseVisualStyleBackColor = true;
            this.btnResto.Click += new System.EventHandler(this.btnResto_Click);
            // 
            // Panier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 581);
            this.Controls.Add(this.btnResto);
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
        private System.Windows.Forms.Button btnResto;
    }
}