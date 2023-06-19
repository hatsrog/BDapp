using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDapp_API.Models;
using BDapp.classes;
using BDapp_Core.Enums;

namespace BDapp_API.Controllers
{
    [Route("api/cac40")]
    [ApiController]
    public class StockModelsController : ControllerBase
    {
        private readonly StockContext _context;

        public StockModelsController(StockContext context)
        {
            _context = context;
        }

        private async void AddStock(int id, Stock stock)
        {
            var stockModel = new StockModel
            {
                id = id,
                stockName = stock._StockName,
                stockPrice = stock.getPrice()
            };

            _context.Entry(stockModel).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        // GET: api/cac40
        [HttpGet("/api/{indice}")]
        public async Task<ActionResult<IEnumerable<StockModel>>> GetStocksOfIndice(string indice)
        {
            _context.stockModels.RemoveRange(_context.stockModels);
            var getValue = StockIndex.GetIndiceValue(indice);
            if(!string.IsNullOrWhiteSpace(getValue))
            {
                var stockIndex = new StockIndex();
                if (getValue.Contains("||"))
                {
                    stockIndex = new StockIndex(getValue.Split("||"));
                }
                else
                {
                    stockIndex = new StockIndex(getValue);
                }
                var listStock = stockIndex.GetStocksFromBoursier();
                int i = 1;
                listStock.ForEach(stock =>
                {
                    AddStock(i, stock);
                    i++;
                });
            }
            return await _context.stockModels.ToListAsync();
        }

        // GET: api/cac40/AIRLIQUIDE
        [HttpGet("{stockName}")]
        public async Task<ActionResult<StockModel>> GetCAC40Stock(string stockName)
        {
            stockName = stockName.ToUpper();
            _context.stockModels.RemoveRange(_context.stockModels);
            StockIndex stockIndex = new StockIndex("https://www.boursier.com/indices/composition/cac-40-FR0003500008,FR.html");
            List<Stock> listStock = stockIndex.GetStocksFromBoursier();
            int i = 1;
            foreach (Stock stock in listStock)
            {
                AddStock(i, stock);
                i++;
            }

            var stockModel = await _context.stockModels.SingleOrDefaultAsync(StockName => StockName.stockName == stockName);

            if (stockModel == null)
            {
                return NotFound();
            }

            return stockModel;
        }
    }
}
