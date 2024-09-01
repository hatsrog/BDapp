using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDapp_API.Models;
using BDapp.classes;
using BDapp_API.DbModels;

namespace BDapp_API.Controllers
{
    [ApiController]
    public class StockModelsController : ControllerBase
    {
        private readonly BdappContext _context;

        public StockModelsController(BdappContext context)
        {
            _context = context;
        }

        private async void AddStock(List<StockInfo>? stocks)
        {
            var id = 0;
            stocks?.ForEach(stock =>
            {
                var stockModel = new StockModel
                {
                    id = ++id,
                    stockName = stock._StockName,
                    stockPrice = stock._StockPrice
                };
                _context.Entry(stockModel).State = EntityState.Added;
            });
            await _context.SaveChangesAsync();
        }

        // GET: api/cac40
        [HttpGet("/api/{indice}")]
        public async Task<ActionResult<IEnumerable<StockModel>>> GetStocksOfIndice(string indice)
        {
            var stocks = _context.Stocks.Where(m => m.Market.Name == indice)
                .Include(i => i.Market)
                .ToList();

            var indiceValue = StockIndex.GetIndiceValue(indice);
            if(!string.IsNullOrWhiteSpace(indiceValue))
            {
                var stockIndex = new StockIndex(indiceValue);
                var listStock = stockIndex.GetStocksFromBoursier();
                AddStock(listStock);
            }
            return await _context.stockModels.ToListAsync();
        }

        // GET: api/cac40/AIRLIQUIDE
        [HttpGet("/api/{indice}/{stockName}")]
        public async Task<ActionResult<StockModel>> GetStockFromIndice(string indice, string stockName)
        {
            stockName = stockName.ToUpper();
            var stockIndex = new StockIndex(StockIndex.GetIndiceValue(indice));
            var listStock = stockIndex.GetStocksFromBoursier();
            var stockFounded = await _context.stockModels.SingleOrDefaultAsync(stock => stock.stockName == stockName);

            return stockFounded != null ? stockFounded : NotFound();
        }
    }
}
