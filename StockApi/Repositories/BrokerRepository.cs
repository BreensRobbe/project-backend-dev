using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockApi.Data;
using StockApi.Models;

namespace StockApi.Repositories
{
    public interface IBrokerRepository
    {
        Task<List<Broker>> GetBrokers();
    }

    public class BrokerRepository : IBrokerRepository
    {
        private IStockContext _context;

        public BrokerRepository(IStockContext context)
        {
            _context = context;
        }

        public async Task<List<Broker>> GetBrokers()
        {
            return await _context.TblBrokers.ToListAsync();
        }

    }
}
