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
    public class Cartao
    {
        //Cadastro cartão
        public long Id { get; set; }
        public string Titular { get; set; }
        public string CpfTitular { get; set; }
        public string Numero { get; set; }
        public string Cvc { get; set; }
        public DateTime DataVencimento { get; set; }
    }
    public class Endereco
    {
        //Cadastro endereço
        public long Id { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento{ get; set; }
    }
}