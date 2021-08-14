using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StockApi.Models;
using System;
using AutoMapper;
using StockApi.Services;
using System.Threading.Tasks;

namespace StockApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class StockController : ControllerBase
    {
        private IMapper _mapper;
        private IStockService _stockService;
        public StockController(IMapper mapper, IStockService stockService){
            _mapper = mapper; 
            _stockService = stockService;
        }

        [HttpGet]
        [Route("stocks")]
        public async Task<List<Stock>> GetStocks(){
            return await _stockService.GetStocks();
        }

        [HttpGet]
        [Route("brokers")]
        public async Task<List<Broker>> GetBrokers(){
            return await _stockService.GetBrokers();
        }

        [HttpGet]
        [Route("exchanges")]
        public async Task<List<Exchange>> GetExchanges(){
            return await _stockService.GetExchanges();
        }
    }
}
