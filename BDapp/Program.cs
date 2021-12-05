// See https://aka.ms/new-console-template for more information
using BDapp.classes;

Console.WriteLine("Prix en temps réel de quelques actions...");

StockIndex cac40 = new StockIndex("CAC40", "https://www.boursier.com/indices/composition/cac-40-FR0003500008,FR.html");
List<float> liste = cac40.getPricesFromBoursier();

StockOwnership stock_alstom = new StockOwnership("Alstom", liste[(int)StockName.ENUM_NAME.ALSTOM], 0);
StockOwnership stock_orange = new StockOwnership("Orange", liste[(int)StockName.ENUM_NAME.ORANGE], 0);
StockOwnership stock_hrs = new StockOwnership("HRS", 0, "https://investir.lesechos.fr/cours/action-hydrogen-refueling,xpar,alhrs,fr0014001pm5,isin.html");
StockOwnership stock_vinci = new StockOwnership("Vinci", liste[(int)StockName.ENUM_NAME.VINCI], 0);
StockOwnership stock_bayer = new StockOwnership("Bayer", 0, "https://investir.lesechos.fr/cours/action-bayer-ag,xetr,de000bay0017,bay001,wkn.html");
StockOwnership etf_sp500 = new StockOwnership("ETF S&P 500", 0, "https://investir.lesechos.fr/cours/tracker-amundi-etf-pea-s&p-500-ucits-etf-eur,xpar,pe500,fr0013412285,isin.html");
StockOwnership etf_world = new StockOwnership("ETF MSCI World", 0, "https://investir.lesechos.fr/cours/tracker-amundi-msci-world-ucits-etf-eur,xpar,cw8,lu1681043599,isin.html");
StockOwnership etf_eau = new StockOwnership("ETF Lyxor Eau", 0, "https://investir.lesechos.fr/cours/tracker-lyxor-pea-eau-msci-water-ucits-etf-capi,xpar,awat,fr0011882364,isin.html");

Stock[] arrayStocks = new Stock[] { stock_alstom, stock_orange, stock_hrs, stock_vinci, etf_sp500, etf_world, etf_eau, stock_bayer};

float valeurPortefeuille = 0f;

foreach(Stock stock in arrayStocks)
{
    float stockPrice = 0f;
    stockPrice = stock.getPrice();
    Console.WriteLine("{0} = {1} EUR", stock.GetStockName, stockPrice);
    if(stock is StockOwnership)
    {
        StockOwnership sohip = (StockOwnership)stock;
        valeurPortefeuille += sohip.GetQuantity * stockPrice;
    }
}
Console.WriteLine("******\n{0} EUR", valeurPortefeuille);

float alstom = liste[(int)StockName.ENUM_NAME.ALSTOM];
float worldline = liste[(int)StockName.ENUM_NAME.WORLDLINE];
float lvmh = liste[(int)StockName.ENUM_NAME.LVMH];

Console.ReadLine();