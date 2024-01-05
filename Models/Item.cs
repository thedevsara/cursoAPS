using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sara_paz.Models
{
    public class Item
    {
        [Key]
        public int iditem { get;set;}
        public double preco { get;set;}
        public string? quantidade { get;set;}
        public int percentual { get;set;}
        public List<Produto>? Produto { get;set;}
        public List<Notavenda>? Notavendas {get;set;}
        
    }
}