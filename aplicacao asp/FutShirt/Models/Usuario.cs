using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutShirt.Models
{
    public partial class Usuario
    {
        //Cadastro dados pessoais
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public bool VerificacaoEmail { get; set; }
        public string CodigoAtivacao { get; set; }
    }
}