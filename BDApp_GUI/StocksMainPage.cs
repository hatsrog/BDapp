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
            switch (comboBoxIndexes.SelectedItem.ToString())
            {
                case "CAC40":
                    StockIndex sIndex = new StockIndex("CAC40", "https://www.boursier.com/indices/composition/cac-40-FR0003500008,FR.html");
                    refreshDataGrid(sIndex);
                    break;
                case "SBF120":
                    StockIndex sbf120 = new StockIndex("SBF120", new string[] { "https://www.boursier.com/indices/composition/sbf-120-FR0003999481,FR.html", "https://www.boursier.com/indices/composition/sbf-120-FR0003999481,FR-2.html", "https://www.boursier.com/indices/composition/sbf-120-FR0003999481,FR-3.html" });
                    refreshDataGrid(sbf120);
                    break;
            }
        }

        private void StocksMainPage_Load(object sender, EventArgs e)
        {
            comboBoxIndexes.SelectedIndex = 0;
        }

        private void refreshDataGrid(StockIndex sIndex)
        {
            List<Stock> liste = sIndex.GetStocksFromBoursier();
            dataGridViewStocks.Columns.Clear();
            dataGridViewPortfolio.Columns.Clear();
            dataGridViewStocks.Columns.Add("Nom", "Nom");
            dataGridViewStocks.Columns.Add("Prix", "Prix");
            dataGridViewPortfolio.Columns.Add("Nom", "Nom");
            dataGridViewPortfolio.Columns.Add("Nombre", "Nombre");
            int index = 0;

            foreach (Stock value in liste)
            {
                string[] row = { value._StockName, value._StockPrice.ToString() };
                dataGridViewStocks.Rows.Add(row);
                index++;
            }
            labelTimeUpdate.Text = "Mis à jour : " + DateTime.Now.ToString();

            StockOwnership stock_alstom;
            StockOwnership stock_orange;
            StockOwnership stock_vinci;
            StockOwnership stock_bayer;

            Stock testExistingPrice = liste.SingleOrDefault(Name => Name._StockName == "ALSTOM");
            if (testExistingPrice != null)
                stock_alstom = new StockOwnership("ALSTOM", liste.SingleOrDefault(Name => Name._StockName == "ALSTOM")._StockPrice, 13);
            else
                stock_alstom = new StockOwnership("ALSTOM", 13, "https://investir.lesechos.fr/cours/action-alstom,xpar,alo,fr0010220475,isin.html");
            testExistingPrice = liste.SingleOrDefault(Name => Name._StockName == "ORANGE");
            if (testExistingPrice != null)
                stock_orange = new StockOwnership("ORANGE", liste.SingleOrDefault(Name => Name._StockName == "ORANGE")._StockPrice, 100);
            else
                stock_orange = new StockOwnership("ORANGE", 100, "https://investir.lesechos.fr/cours/action-orange,xpar,ora,fr0000133308,isin.html");
            StockOwnership stock_hrs = new StockOwnership("HRS", 20, "https://investir.lesechos.fr/cours/action-hydrogen-refueling,xpar,alhrs,fr0014001pm5,isin.html");
            testExistingPrice = liste.SingleOrDefault(Name => Name._StockName == "VINCI");
            if(testExistingPrice != null)
                stock_vinci = new StockOwnership("Vinci", liste.SingleOrDefault(Name => Name._StockName == "VINCI")._StockPrice, 4);
            else
                stock_vinci = new StockOwnership("Vinci", 4, "https://investir.lesechos.fr/cours/action-vinci,xpar,dg,fr0000125486,isin.html");
            testExistingPrice = liste.SingleOrDefault(Name => Name._StockName == "BAYER");
            if(testExistingPrice != null)
                stock_bayer = new StockOwnership("BAYER", liste.SingleOrDefault(Name => Name._StockName == "BAYER")._StockPrice, 14);
            else
                stock_bayer = new StockOwnership("BAYER", 14, "https://investir.lesechos.fr/cours/action-bayer-ag,xetr,de000bay0017,bay001,wkn.html");
            StockOwnership etf_sp500 = new StockOwnership("ETF S&P 500", 31, "https://investir.lesechos.fr/cours/tracker-amundi-etf-pea-s&p-500-ucits-etf-eur,xpar,pe500,fr0013412285,isin.html");
            StockOwnership etf_world = new StockOwnership("ETF MSCI World", 5, "https://investir.lesechos.fr/cours/tracker-amundi-msci-world-ucits-etf-eur,xpar,cw8,lu1681043599,isin.html");
            StockOwnership etf_eau = new StockOwnership("ETF Lyxor Eau", 18, "https://investir.lesechos.fr/cours/tracker-lyxor-pea-eau-msci-water-ucits-etf-capi,xpar,awat,fr0011882364,isin.html");

            Stock[] arrayStocks = new Stock[] { stock_alstom, stock_orange, stock_hrs, stock_vinci, etf_sp500, etf_world, etf_eau, stock_bayer };

            float valeurPortefeuille = 0f;

            foreach (Stock stock in arrayStocks)
            {
                float stockPrice = stock.getPrice();
                if (stock is StockOwnership)
                {
                    StockOwnership sohip = (StockOwnership)stock;
                    string[] row = { stock._StockName, sohip.GetQuantity.ToString() };
                    valeurPortefeuille += sohip.GetQuantity * stockPrice;
                    dataGridViewPortfolio.Rows.Add(row);
                }
            }
            labelPortfolio.Text = valeurPortefeuille.ToString()+" EUR";
        }

        private void comboBoxIndexes_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            switch (cbb.SelectedItem.ToString())
            {
                case "CAC40":
                    StockIndex sIndex = new StockIndex("CAC40", "https://www.boursier.com/indices/composition/cac-40-FR0003500008,FR.html");
                    refreshDataGrid(sIndex);
                    break;
                case "SBF120":
                    StockIndex sbf120 = new StockIndex("SBF120", new string[] { "https://www.boursier.com/indices/composition/sbf-120-FR0003999481,FR.html", "https://www.boursier.com/indices/composition/sbf-120-FR0003999481,FR-2.html", "https://www.boursier.com/indices/composition/sbf-120-FR0003999481,FR-3.html" });
                    refreshDataGrid(sbf120);
                    break;
            }        
        }
    }
}