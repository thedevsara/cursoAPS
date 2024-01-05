using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sara_paz.Models
{
    public class Produto
    {
        [Key]
        public int idprod { get;set;}
        public string? nome {get; set;}
        public string? descricao { get; set;}
        public int quantidade { get;set;}
        public double preco { get;set;}
        public int Itemid { get;set;}
        public Item? Item { get;set;}
        public List<Marca>? Marcas { get;set;}
            
    }
}