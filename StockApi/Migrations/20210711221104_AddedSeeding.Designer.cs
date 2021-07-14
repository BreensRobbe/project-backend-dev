﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockApi.Data;

namespace StockApi.Migrations
{
    [DbContext(typeof(StockContext))]
    [Migration("20210711221104_AddedSeeding")]
    partial class AddedSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("BrokerStock", b =>
                {
                    b.Property<int>("BrokersBrokerId")
                        .HasColumnType("int");

                    b.Property<int>("StocksStockId")
                        .HasColumnType("int");

                    b.HasKey("BrokersBrokerId", "StocksStockId");

                    b.HasIndex("StocksStockId");

                    b.ToTable("BrokerStock");
                });

            modelBuilder.Entity("ExchangeStock", b =>
                {
                    b.Property<int>("ExchangesExchangeId")
                        .HasColumnType("int");

                    b.Property<int>("StocksStockId")
                        .HasColumnType("int");

                    b.HasKey("ExchangesExchangeId", "StocksStockId");

                    b.HasIndex("StocksStockId");

                    b.ToTable("ExchangeStock");
                });

            modelBuilder.Entity("StockApi.Models.Broker", b =>
                {
                    b.Property<int>("BrokerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Continent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BrokerId");

                    b.ToTable("TblBrokers");

                    b.HasData(
                        new
                        {
                            BrokerId = 1,
                            Continent = "Europe",
                            Country = "United Kingdom",
                            Name = "Etoro"
                        },
                        new
                        {
                            BrokerId = 2,
                            Continent = "North America",
                            Country = "USA",
                            Name = "Robinhood"
                        },
                        new
                        {
                            BrokerId = 3,
                            Continent = "North America",
                            Country = "USA",
                            Name = "Fidelity"
                        });
                });

            modelBuilder.Entity("StockApi.Models.Exchange", b =>
                {
                    b.Property<int>("ExchangeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Continent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ExchangeId");

                    b.ToTable("TblExchanges");

                    b.HasData(
                        new
                        {
                            ExchangeId = 1,
                            Continent = "North America",
                            Country = "USA",
                            Name = "New York Stock Exchange"
                        },
                        new
                        {
                            ExchangeId = 2,
                            Continent = "North America",
                            Country = "USA",
                            Name = "NASDAQ"
                        },
                        new
                        {
                            ExchangeId = 3,
                            Continent = "Asia",
                            Country = "China",
                            Name = "Hong Kong Stock Exchange"
                        });
                });

            modelBuilder.Entity("StockApi.Models.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Employees")
                        .HasColumnType("int");

                    b.Property<DateTime>("ListDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StockId");

                    b.ToTable("TblStocks");

                    b.HasData(
                        new
                        {
                            StockId = 1,
                            Employees = 12000,
                            ListDate = new DateTime(2002, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Gamestop",
                            Ticker = "GME"
                        },
                        new
                        {
                            StockId = 2,
                            Employees = 4408,
                            ListDate = new DateTime(2013, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "AMC Entertainment",
                            Ticker = "AMC"
                        },
                        new
                        {
                            StockId = 3,
                            Employees = 4044,
                            ListDate = new DateTime(1997, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Blackberry",
                            Ticker = "BB"
                        });
                });

            modelBuilder.Entity("BrokerStock", b =>
                {
                    b.HasOne("StockApi.Models.Broker", null)
                        .WithMany()
                        .HasForeignKey("BrokersBrokerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockApi.Models.Stock", null)
                        .WithMany()
                        .HasForeignKey("StocksStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExchangeStock", b =>
                {
                    b.HasOne("StockApi.Models.Exchange", null)
                        .WithMany()
                        .HasForeignKey("ExchangesExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockApi.Models.Stock", null)
                        .WithMany()
                        .HasForeignKey("StocksStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}