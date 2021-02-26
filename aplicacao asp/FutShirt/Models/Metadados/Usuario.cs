using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FutShirt.Models
{
	[MetadataType(typeof(UsuarioMetaDados))]
	public partial class Usuario
	{
		public string ConfirmarSenha { get; set; }
	}

	public class UsuarioMetaDados
	{
		[Display(Name = "Nome")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar um nome.")]
		public string Nome { get; set; }

		[Display(Name = "Email")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar um email.")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(Name = "CPF")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###.###.###-##}")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar um cpf válido.")]
		public string Cpf { get; set; }

		[Display(Name = "Telefone")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:(##) #####-####}")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar um número de telefone.")]
		[DataType(DataType.PhoneNumber)]
		public string Telefone { get; set; }

		[Display(Name = "Data de Nascimento")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar uma data de nascimento.")]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime DataNascimento { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar uma senha.")]
		[DataType(DataType.Password)]
		[MinLength(8, ErrorMessage = "A senha deve possuir no mínimo 8 caracteres.")]
		public string Senha { get; set; }

		[Display(Name = "Confirmar Senha")]
		[DataType(DataType.Password)]
		[Compare("Senha", ErrorMessage = "As senhas não conferem.")]
		public string ConfirmarSenha { get; set; }
	}
}