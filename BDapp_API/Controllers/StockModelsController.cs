using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDapp_API.Models;
using BDapp.classes;

namespace BDapp_API.Controllers
{
    [ApiController]
    public class StockModelsController : ControllerBase
    {
        private readonly StockContext _context;

        public StockModelsController(StockContext context)
        {
            _context = context;
        }

        private async void AddStock(List<Stock>? stocks)
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
            _context.stockModels.RemoveRange(_context.stockModels);
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
            _context.stockModels.RemoveRange(_context.stockModels);
            var stockIndex = new StockIndex(StockIndex.GetIndiceValue(indice));
            var listStock = stockIndex.GetStocksFromBoursier();
            var stockFounded = await _context.stockModels.SingleOrDefaultAsync(stock => stock.stockName == stockName);

            return stockFounded != null ? stockFounded : NotFound();
        }
    }
}
