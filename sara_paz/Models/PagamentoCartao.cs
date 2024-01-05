using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sara_paz.Models
{
    public class PagamentoCartao: TipoPagamento
    {
        public string? numerocart { get;set;}
        public string? bandeira { get;set;}
        
    }
}