using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutShirt.Models
{
    public class Cartao
    {
        public long Id { get; set; }
        public string Titular { get; set; }
        public string CpfTitular { get; set; }
        public string Numero { get; set; }
        public string Cvc { get; set; }
        public DateTime DataVencimento { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}