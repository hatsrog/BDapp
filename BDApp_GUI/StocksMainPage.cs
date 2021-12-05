using BDapp.classes;

namespace BDApp_GUI
{
    public partial class StocksMainPage : Form
    {
        public StocksMainPage()
        {
            InitializeComponent();
        }

        private void buttonStock_Click(object sender, EventArgs e)
        {
            StockIndex cac40 = new StockIndex("CAC40", "https://www.boursier.com/indices/composition/cac-40-FR0003500008,FR.html");
            List<float> liste = cac40.getPricesFromBoursier();

            StockOwnership stock_alstom = new StockOwnership("Alstom", liste[(int)StockName.ENUM_NAME.ALSTOM], 13);
            MessageBox.Show(stock_alstom.GetStockName + " = " + stock_alstom.GetStockPrice);
        }

        private void StocksMainPage_Load(object sender, EventArgs e)
        {
            StockIndex cac40 = new StockIndex("CAC40", "https://www.boursier.com/indices/composition/cac-40-FR0003500008,FR.html");
            List<float> liste = cac40.getPricesFromBoursier();
            dataGridViewStocks.Columns.Add("Nom", "Nom");
            dataGridViewStocks.Columns.Add("Prix", "Prix");
            int index = 0;

            foreach(float price in liste)
            {
                string[] row = { StockName.name[index], price.ToString()};
                dataGridViewStocks.Rows.Add(row);
                index++;
            }
        }
    }
}