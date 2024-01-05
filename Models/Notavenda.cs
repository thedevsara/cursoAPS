using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sara_paz.Models
{
    public class Notavenda
    {

        [Key]
        public int cod_nota { get;set;}
        public string? data { get;set;}
        public bool tipo {get;set;}
        public List<Cliente>? Clientes { get;set;}
        public List<Vendedor>? Vendedors { get;set;}
        public List<Transportadora>? transportadoras { get;set;}
        public List<TipoPagamento>? tipopagamentos { get;set;}
        // public List<Tipopagamento>? tipopagamentos { get;set;}
        public int Pagamentoid {get;set;}
        public Pagamento? Pagamento { get;set;}
        public int Itemid {get;set;}
        public Item? Item { get;set;}

        private bool cancelado = false;
        private bool Devolvido = false;
        public bool cancelar() {
            cancelado = true;
            return true;
            
        }
        public bool devolver(){
            Devolvido = true;
            return true;

        }
    
        
    }
}