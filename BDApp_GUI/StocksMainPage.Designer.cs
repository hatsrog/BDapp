namespace BDApp_GUI
{
    partial class StocksMainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStock = new System.Windows.Forms.Button();
            this.dataGridViewStocks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStocks)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStock
            // 
            this.buttonStock.Location = new System.Drawing.Point(439, 12);
            this.buttonStock.Name = "buttonStock";
            this.buttonStock.Size = new System.Drawing.Size(171, 49);
            this.buttonStock.TabIndex = 0;
            this.buttonStock.Text = "button1";
            this.buttonStock.UseVisualStyleBackColor = true;
            this.buttonStock.Click += new System.EventHandler(this.buttonStock_Click);
            // 
            // dataGridViewStocks
            // 
            this.dataGridViewStocks.AllowUserToAddRows = false;
            this.dataGridViewStocks.AllowUserToDeleteRows = false;
            this.dataGridViewStocks.AllowUserToOrderColumns = true;
            this.dataGridViewStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStocks.Location = new System.Drawing.Point(45, 12);
            this.dataGridViewStocks.Name = "dataGridViewStocks";
            this.dataGridViewStocks.ReadOnly = true;
            this.dataGridViewStocks.RowTemplate.Height = 25;
            this.dataGridViewStocks.Size = new System.Drawing.Size(388, 400);
            this.dataGridViewStocks.TabIndex = 1;
            // 
            // StocksMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewStocks);
            this.Controls.Add(this.buttonStock);
            this.Name = "StocksMainPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.StocksMainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStocks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonStock;
        private DataGridView dataGridViewStocks;
    }
}