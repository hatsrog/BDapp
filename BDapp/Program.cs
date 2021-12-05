// See https://aka.ms/new-console-template for more information
using BDapp.classes;

Console.WriteLine("Prix en temps réel de quelques actions...");

StockIndex cac40 = new StockIndex("CAC40", "https://www.boursier.com/indices/composition/cac-40-FR0003500008,FR.html");
List<Stock> cac = cac40.getPricesFromBoursier();

StockIndex sbf120 = new StockIndex("SBF120", new string[]{"https://www.boursier.com/indices/composition/sbf-120-FR0003999481,FR.html", "https://www.boursier.com/indices/composition/sbf-120-FR0003999481,FR-2.html", "https://www.boursier.com/indices/composition/sbf-120-FR0003999481,FR-3.html"});
List<Stock> sbf = sbf120.getPricesFromBoursier();

StockOwnership stock_alstom = new StockOwnership("ALSTOM", cac.FirstOrDefault(Name => Name._StockName == "ALSTOM")._StockPrice, 10);
StockOwnership stock_orange = new StockOwnership("ORANGE", cac.FirstOrDefault(Name => Name._StockName == "ORANGE")._StockPrice, 10);
StockOwnership stock_hrs = new StockOwnership("HRS", 0, "https://investir.lesechos.fr/cours/action-hydrogen-refueling,xpar,alhrs,fr0014001pm5,isin.html");
StockOwnership stock_vinci = new StockOwnership("Vinci", cac.FirstOrDefault(Name => Name._StockName == "VINCI")._StockPrice, 10);
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
    Console.WriteLine("{0} = {1} EUR", stock._StockName, stockPrice);
    if(stock is StockOwnership)
    {
        StockOwnership sohip = (StockOwnership)stock;
        valeurPortefeuille += sohip.GetQuantity * stockPrice;
    }
}
Console.WriteLine("******\n{0} EUR", valeurPortefeuille);

Console.ReadLine();