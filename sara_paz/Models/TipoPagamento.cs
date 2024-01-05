using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sara_paz.Models
{
    public class TipoPagamento
    {
        [Key]
        public int idtipo { get;set;}
        public string? nomecobrado { get; set;}
        public string? informacaoadicionais { get; set;}
        public int Notavendacod { get;set;}
        public Notavenda? Notavenda { get;set;}
        
    }
}