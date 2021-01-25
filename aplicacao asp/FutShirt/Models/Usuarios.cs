using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutShirt.Models
{
    public class Usuarios
    {
        //Cadastro dados pessoais
        private int id;
        private string nome, email, telefone, cpf, senha;
        private DateTime nascimento;

        //Cadastro endereço
        private string cep, estado, cidade, logradouro, numero, complemento;
    }   
}