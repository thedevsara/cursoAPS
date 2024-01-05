using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sara_paz.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sara_paz.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions <MyDbContext> options) : base(options)
        {           
        }

        public DbSet<Notavenda> Notavenda { get;set;}
        public DbSet<Cliente> Clientes { get;set;}
        public DbSet<Vendedor> Vendedors { get;set;}
        public DbSet<Transportadora> transportadoras { get;set;}
        public DbSet<Pagamento> Pagamento { get;set;}
        public DbSet<Item> items { get;set;}
        public DbSet<Produto> produtos { get;set;}
        public DbSet<Marca> Marca { get;set;}
        public DbSet<TipoPagamento> Tipopagamento { get;set;}
        public DbSet<PagamentoCheque> PagamentoCheque { get;set;}
        public DbSet<PagamentoCartao> Pagamentocartao { get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Notavenda)
            .WithMany (n => n.Clientes)
            .HasForeignKey(c => c.Notavendacod);
            modelBuilder.Entity<Vendedor>()
            .HasOne(v => v.NotaVenda)
            .WithMany(n => n.Vendedors)
            .HasForeignKey(v => v.Notavendacod);
            modelBuilder.Entity<Transportadora>()
            .HasOne(t => t.notavenda)
            .WithMany (n => n.transportadoras)
            .HasForeignKey(t => t.Notavendacod);
            modelBuilder.Entity<Notavenda>()
            .HasOne(n => n.Pagamento)
            .WithMany (p => p.Notavendas)
            .HasForeignKey(n => n.Pagamentoid);
            modelBuilder.Entity<TipoPagamento>()
            .HasOne(t => t.Notavenda)
            .WithMany(n => n.tipopagamentos)
            .HasForeignKey(t => t.Notavendacod);
            modelBuilder.Entity<Produto>()
            .HasOne(p => p.Item)
            .WithMany(i => i.Produto)
            .HasForeignKey(p => p.Itemid);
            modelBuilder.Entity<Marca>()
            .HasOne(m => m.Produto)
            .WithMany(p => p.Marcas)
            .HasForeignKey(m => m.Produtoid);
            modelBuilder.Entity<Notavenda>()
            .HasOne(n => n.Item)
            .WithMany(i => i.Notavendas)
            .HasForeignKey(n => n.Itemid);



        }
        
    }
}