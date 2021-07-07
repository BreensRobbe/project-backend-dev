using System;
using System.ComponentModel.DataAnnotations;

namespace StockApi.models
{
    public class Broker
    {
        [Key]
        public Guid BrokerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Continent { get; set; }
    }
}
