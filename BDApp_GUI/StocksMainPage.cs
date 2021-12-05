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
            refreshDataGrid();
        }

        private void StocksMainPage_Load(object sender, EventArgs e)
        {
            refreshDataGrid();
        }

        private void refreshDataGrid()
        {
            StockIndex cac40 = new StockIndex("CAC40", "https://www.boursier.com/indices/composition/cac-40-FR0003500008,FR.html");
            List<float> liste = cac40.getPricesFromBoursier();
            dataGridViewStocks.Columns.Clear();
            dataGridViewPortfolio.Columns.Clear();
            dataGridViewStocks.Columns.Add("Nom", "Nom");
            dataGridViewStocks.Columns.Add("Prix", "Prix");
            dataGridViewPortfolio.Columns.Add("Nom", "Nom");
            dataGridViewPortfolio.Columns.Add("Nombre", "Nombre");
            int index = 0;

            foreach (float price in liste)
            {
                string[] row = { StockName.name[index], price.ToString() };
                dataGridViewStocks.Rows.Add(row);
                index++;
            }
            labelTimeUpdate.Text = "Mis à jour : " + DateTime.Now.ToString();

            StockOwnership stock_alstom = new StockOwnership("Alstom", liste[(int)StockName.ENUM_NAME.ALSTOM], 10);
            StockOwnership stock_orange = new StockOwnership("Orange", liste[(int)StockName.ENUM_NAME.ORANGE], 10);
            StockOwnership stock_hrs = new StockOwnership("HRS", 10, "https://investir.lesechos.fr/cours/action-hydrogen-refueling,xpar,alhrs,fr0014001pm5,isin.html");
            StockOwnership stock_vinci = new StockOwnership("Vinci", liste[(int)StockName.ENUM_NAME.VINCI], 10);
            StockOwnership stock_bayer = new StockOwnership("Bayer", 10, "https://investir.lesechos.fr/cours/action-bayer-ag,xetr,de000bay0017,bay001,wkn.html");
            StockOwnership etf_sp500 = new StockOwnership("ETF S&P 500", 1000, "https://investir.lesechos.fr/cours/tracker-amundi-etf-pea-s&p-500-ucits-etf-eur,xpar,pe500,fr0013412285,isin.html");
            StockOwnership etf_world = new StockOwnership("ETF MSCI World", 10, "https://investir.lesechos.fr/cours/tracker-amundi-msci-world-ucits-etf-eur,xpar,cw8,lu1681043599,isin.html");
            StockOwnership etf_eau = new StockOwnership("ETF Lyxor Eau", 11, "https://investir.lesechos.fr/cours/tracker-lyxor-pea-eau-msci-water-ucits-etf-capi,xpar,awat,fr0011882364,isin.html");

            Stock[] arrayStocks = new Stock[] { stock_alstom, stock_orange, stock_hrs, stock_vinci, etf_sp500, etf_world, etf_eau, stock_bayer };

            float valeurPortefeuille = 0f;

            foreach (Stock stock in arrayStocks)
            {
                float stockPrice = 0f;
                stockPrice = stock.getPrice();
                if (stock is StockOwnership)
                {
                    StockOwnership sohip = (StockOwnership)stock;
                    string[] row = { stock.GetStockName, sohip.GetQuantity.ToString() };
                    valeurPortefeuille += sohip.GetQuantity * stockPrice;
                    dataGridViewPortfolio.Rows.Add(row);
                }
            }
            labelPortfolio.Text = valeurPortefeuille.ToString()+" EUR";
        }
    }
}