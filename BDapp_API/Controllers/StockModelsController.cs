using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDapp_API.Models;
using BDapp_API.DbModels;
using BDapp_Core.Classes;
using AutoMapper;

namespace BDapp_API.Controllers
{
    [ApiController]
    public class StockModelsController : ControllerBase
    {
        private readonly BdappContext _context;
        private readonly IMapper _mapper;

        public StockModelsController(BdappContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private async void AddStock(List<StockInfo>? stocks)
        {
            var id = 0;
            stocks?.ForEach(stock =>
            {
                var stockModel = new StockModel
                {
                    id = ++id,
                    stockName = stock.StockName,
                    stockPrice = stock.StockPrice
                };
                _context.Entry(stockModel).State = EntityState.Added;
            });
            await _context.SaveChangesAsync();
        }

        // GET: api/cac40
        [HttpGet("/api/{indice}")]
        public async Task<List<StockInformation>> GetStocksOfIndice(string indice)
        {
            var stocks = await _context.Stocks.Where(m => m.Market.Name == indice)
                .ToListAsync();
            stocks.ForEach(stock =>
            {
                stock.Prices = [.. _context.Prices.Where(price => price.StockId == stock.Id)];
            });

            return _mapper.Map<List<StockInformation>>(stocks);
        }

        // GET: api/cac40/AIR LIQUIDE
        [HttpGet("/api/{indice}/{stockName}")]
        public async Task<StockInformation> GetStockFromIndice(string indice, string stockName)
        {
            var stock = _context.Stocks.Where(m => m.Market.Name == indice && m.Name == stockName).SingleOrDefault();
            if(stock != null)
                stock.Prices = [.. _context.Prices.Where(price => price.StockId == stock.Id)];

            return _mapper.Map<StockInformation>(stock);
        }
    }
}
