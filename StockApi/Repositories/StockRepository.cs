using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockApi.Data;
using StockApi.Models;

namespace StockApi.Repositories
{
   public interface IStockRepository
   {
       Task<List<Stock>> GetStocks();
   }
   
    public class StockRepository : IStockRepository
    {
        private IStockContext _context;

        public StockRepository(IStockContext context){
            _context = context;
        }

        public async Task<List<Stock>> GetStocks(){
            return await _context.TblStocks.ToListAsync();
        }
    }
}
