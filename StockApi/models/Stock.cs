using System;
using System.ComponentModel.DataAnnotations;

namespace StockApi.models
{
    public class Stock
    {
        [Key]
        public Guid StockId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ticker { get; set; }
        [Required]
        public int Employees { get; set; }
        [Required]
        public DateTime ListDate  { get; set; }
        //public string Exchanges { get; set; } // list
        //public string Brokers { get; set; } // list 
    }
}
