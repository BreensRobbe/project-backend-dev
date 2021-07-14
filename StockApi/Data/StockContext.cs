using System;
using Microsoft.EntityFrameworkCore;
using StockApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using StockApi.Config;
using System.Collections.Generic;



namespace StockApi.Data
{
    public class StockContext : DbContext
    {
        public DbSet<Broker> TblBrokers { get; set; }
        public DbSet<Stock> TblStocks { get; set; }
        public DbSet<Exchange> TblExchanges { get; set; }
        private ConnectionStrings _connectionStrings;
        public StockContext(DbContextOptions<StockContext> options, IOptions<ConnectionStrings> connectionStrings) : base(options){
            _connectionStrings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options){



            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            options.UseMySql(_connectionStrings.SQL, ServerVersion.AutoDetect(_connectionStrings.SQL));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            
            Broker etoro = new Broker(){BrokerId=1, Name="Etoro", Country="United Kingdom", Continent="Europe"};
            Broker robinhood = new Broker(){BrokerId=2, Name="Robinhood", Country="USA", Continent="North America"};
            Broker fidelity = new Broker(){BrokerId=3, Name="Fidelity", Country="USA", Continent="North America",};

            Exchange newyorkStockExchange = new Exchange(){ExchangeId=1, Name="New York Stock Exchange", Country="USA", Continent="North America"};
            Exchange nasdaq = new Exchange(){ExchangeId=2, Name="NASDAQ", Country="USA", Continent="North America"};
            Exchange hongkongStockExchange = new Exchange(){ExchangeId=3, Name="Hong Kong Stock Exchange", Country="China", Continent="Asia"};

            Stock gamestop = new Stock(){StockId=1, Name="Gamestop", Ticker="GME", Employees=12000, ListDate=new DateTime(2002, 2, 13)};
            Stock amc = new Stock(){StockId=2, Name="AMC Entertainment", Ticker="AMC", Employees=4408, ListDate=new DateTime(2013, 12, 18)};
            Stock bb = new Stock(){StockId=3, Name="Blackberry", Ticker="BB", Employees=4044, ListDate=new DateTime(1997, 10, 28)};

            // Data seeding: Brokers
            modelBuilder.Entity<Broker>().HasData(etoro);
            modelBuilder.Entity<Broker>().HasData(robinhood);
            modelBuilder.Entity<Broker>().HasData(fidelity);


            // Data seeding: Exchanges
            modelBuilder.Entity<Exchange>().HasData(newyorkStockExchange);
            modelBuilder.Entity<Exchange>().HasData(nasdaq);
            modelBuilder.Entity<Exchange>().HasData(hongkongStockExchange);


            // Data seeding: Stocks
            modelBuilder.Entity<Stock>().HasData(gamestop);
            modelBuilder.Entity<Stock>().HasData(amc);
            modelBuilder.Entity<Stock>().HasData(bb);


            // Data seeding: Joint tables
            modelBuilder.Entity("BrokerStock").HasData(new {BrokersBrokerId=1, StocksStockId=1});
            modelBuilder.Entity("BrokerStock").HasData(new {BrokersBrokerId=2, StocksStockId=3});

            modelBuilder.Entity("ExchangeStock").HasData(new {ExchangesExchangeId=1, StocksStockId=1});
            modelBuilder.Entity("ExchangeStock").HasData(new {ExchangesExchangeId=2, StocksStockId=3});
        }
    }
}
