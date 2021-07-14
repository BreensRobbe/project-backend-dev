using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace StockApi.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ticker { get; set; }
        [Required]
        public int Employees { get; set; }
        [Required]
        public DateTime ListDate  { get; set; }
        public ICollection<Exchange> Exchanges {get; set; }
        public ICollection<Broker> Brokers { get; set; }

    }
}
