using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace StockApi.Models
{
    public class Exchange
    {   
        [Key]
        public int ExchangeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Continent { get; set; }
        
        public ICollection<Stock> Stocks {get; set; }
    }
}
