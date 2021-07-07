using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StockApi.models;
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
                StockId = Guid.NewGuid(), Name="Gamestop", Ticker="GME", Employees=12000
            };
        }

        [HttpGet]
        [Route("stocks")]
        public ActionResult<Stock> GetStocks(){
            return new OkObjectResult(_stocks);
        }
    }
}
