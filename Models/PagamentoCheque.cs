using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sara_paz.Models
{
    public class PagamentoCheque: TipoPagamento
    {
        public int banco { get;set;}
        public string? nomebanco { get;set;}
    }
}