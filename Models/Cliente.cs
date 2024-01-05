using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sara_paz.Models
{
    public class Cliente
    {
        [Key]
        public int idcliente { get; set;}
        public string? nome { get;set;}
        public int Notavendacod { get;set;}
        public Notavenda? Notavenda { get; set;}
    }
}