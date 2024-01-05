using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sara_paz.Models
{
    public class Marca
    {
        [Key]
        public int idmar {get;set;}
        public string? none { get;set;}
        public string? descricao { get;set;}
        public int Produtoid { get;set;}
        public Produto? Produto { get;set;}  
        
    }
}