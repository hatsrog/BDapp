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
            this.labelTimeUpdate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPortfolio = new System.Windows.Forms.Label();
            this.dataGridViewPortfolio = new System.Windows.Forms.DataGridView();
            this.comboBoxIndexes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPortfolio)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStock
            // 
            this.buttonStock.Location = new System.Drawing.Point(362, 38);
            this.buttonStock.Name = "buttonStock";
            this.buttonStock.Size = new System.Drawing.Size(171, 49);
            this.buttonStock.TabIndex = 0;
            this.buttonStock.Text = "Rafraichir";
            this.buttonStock.UseVisualStyleBackColor = true;
            this.buttonStock.Click += new System.EventHandler(this.buttonStock_Click);
            // 
            // dataGridViewStocks
            // 
            this.dataGridViewStocks.AllowUserToAddRows = false;
            this.dataGridViewStocks.AllowUserToDeleteRows = false;
            this.dataGridViewStocks.AllowUserToOrderColumns = true;
            this.dataGridViewStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStocks.Location = new System.Drawing.Point(23, 38);
            this.dataGridViewStocks.Name = "dataGridViewStocks";
            this.dataGridViewStocks.ReadOnly = true;
            this.dataGridViewStocks.RowTemplate.Height = 25;
            this.dataGridViewStocks.Size = new System.Drawing.Size(333, 400);
            this.dataGridViewStocks.TabIndex = 1;
            // 
            // labelTimeUpdate
            // 
            this.labelTimeUpdate.AutoSize = true;
            this.labelTimeUpdate.Location = new System.Drawing.Point(362, 93);
            this.labelTimeUpdate.Name = "labelTimeUpdate";
            this.labelTimeUpdate.Size = new System.Drawing.Size(0, 15);
            this.labelTimeUpdate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(362, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mon Portefeuille";
            // 
            // labelPortfolio
            // 
            this.labelPortfolio.AutoSize = true;
            this.labelPortfolio.Location = new System.Drawing.Point(362, 146);
            this.labelPortfolio.Name = "labelPortfolio";
            this.labelPortfolio.Size = new System.Drawing.Size(0, 15);
            this.labelPortfolio.TabIndex = 4;
            // 
            // dataGridViewPortfolio
            // 
            this.dataGridViewPortfolio.AllowUserToAddRows = false;
            this.dataGridViewPortfolio.AllowUserToDeleteRows = false;
            this.dataGridViewPortfolio.AllowUserToOrderColumns = true;
            this.dataGridViewPortfolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPortfolio.Location = new System.Drawing.Point(362, 178);
            this.dataGridViewPortfolio.Name = "dataGridViewPortfolio";
            this.dataGridViewPortfolio.ReadOnly = true;
            this.dataGridViewPortfolio.RowTemplate.Height = 25;
            this.dataGridViewPortfolio.Size = new System.Drawing.Size(275, 260);
            this.dataGridViewPortfolio.TabIndex = 5;
            // 
            // comboBoxIndexes
            // 
            this.comboBoxIndexes.FormattingEnabled = true;
            this.comboBoxIndexes.Items.AddRange(new object[] {
            "CAC40",
            "SBF120"});
            this.comboBoxIndexes.Location = new System.Drawing.Point(23, 9);
            this.comboBoxIndexes.Name = "comboBoxIndexes";
            this.comboBoxIndexes.Size = new System.Drawing.Size(333, 23);
            this.comboBoxIndexes.TabIndex = 6;
            this.comboBoxIndexes.SelectedValueChanged += new System.EventHandler(this.comboBoxIndexes_SelectedValueChanged);
            // 
            // StocksMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxIndexes);
            this.Controls.Add(this.dataGridViewPortfolio);
            this.Controls.Add(this.labelPortfolio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTimeUpdate);
            this.Controls.Add(this.dataGridViewStocks);
            this.Controls.Add(this.buttonStock);
            this.Name = "StocksMainPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.StocksMainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPortfolio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonStock;
        private DataGridView dataGridViewStocks;
        private Label labelTimeUpdate;
        private Label label1;
        private Label labelPortfolio;
        private DataGridView dataGridViewPortfolio;
        private ComboBox comboBoxIndexes;
    }
}