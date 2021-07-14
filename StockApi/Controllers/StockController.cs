using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StockApi.Models;
using System;

namespace StockApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class StockController : ControllerBase
    {
        private static Stock _stocks;

        public StockController(){
            _stocks = new Stock(){
                StockId =0 , Name="Gamestop", Ticker="GME", Employees=12000
            };
            
        }

        [HttpGet]
        [Route("stocks")]
        public ActionResult<Stock> GetStocks(){
            return new OkObjectResult(_stocks);
        }
    }
}
