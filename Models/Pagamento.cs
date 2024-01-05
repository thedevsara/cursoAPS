using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sara_paz.Models
{
    public class Pagamento
    {
        [Key]
        public int idpag {get;set;}
        public DateOnly datalimite {get;set;}
        public double valor {get;set;}
        public bool pago {get; set;}
        public List<Notavenda>? Notavendas { get;set;}
        
    }
}