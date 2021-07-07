using System;
using System.ComponentModel.DataAnnotations;

namespace StockApi.models
{
    public class Exchange
    {   
        [Key]
        public Guid ExchangeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Continent { get; set; }
    }
}
