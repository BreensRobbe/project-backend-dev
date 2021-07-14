using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockApi.Data;
using StockApi.Models;

namespace StockApi.Repositories
{
    public interface IExchangeRepository
    {
        Task<List<Exchange>> GetExchanges();
    }

    public class ExchangeRepository : IExchangeRepository
    {
        private IStockContext _context;

        public ExchangeRepository(IStockContext context)
        {
            _context = context;
        }

        public async Task<List<Exchange>> GetExchanges()
        {
            return await _context.TblExchanges.ToListAsync();
        }
    }
}
