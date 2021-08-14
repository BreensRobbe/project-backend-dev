using System;
using StockApi.Repositories;
using StockApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StockApi.Services
{
    public interface IStockService
    {
        Task<List<Broker>> GetBrokers();
        Task<List<Exchange>> GetExchanges();
        Task<List<Stock>> GetStocks();
    }

    public class StockService : IStockService
    {
        private IStockRepository _stockRepo;
        private IExchangeRepository _exchangeRepo;
        private IBrokerRepository _brokerRepo;
        public StockService(
            IStockRepository stockRepository,
            IExchangeRepository exchangeRepository,
            IBrokerRepository brokerRepository)
        {
            _stockRepo = stockRepository;
            _brokerRepo = brokerRepository;
            _exchangeRepo = exchangeRepository;
        }

        public async Task<List<Stock>> GetStocks()
        {
            return await _stockRepo.GetStocks();
        }

        public async Task<List<Broker>> GetBrokers()
        {
            return await _brokerRepo.GetBrokers();
        }

        public async Task<List<Exchange>> GetExchanges()
        {
            return await _exchangeRepo.GetExchanges();
        }
    }
}
