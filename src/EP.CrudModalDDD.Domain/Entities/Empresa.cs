using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CrudModalDDD.Domain.Entities
{
	public class Empresa
	{
		public Empresa()
		{
			EmpresaId = Guid.NewGuid();
		}

		public Guid EmpresaId { get; set; }
		public string Nome { get; set; }
		public string Responsavel { get; set; }
		public string NomeExibicao { get; set; }
		public string Site { get; set; }
		public string Telefone1 { get; set; }
		public string Telefone2 { get; set; }
		public string Logradouro { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public Int64 BairroID { get; set; }
		public string CEP { get; set; }
		public string Email1 { get; set; }
		public string Email2 { get; set; }
		public string Descricao { get; set; }
		public bool Ativo { get; set; }
		public bool Excluido { get; set; }
		public DateTime DataCadastro { get; set; }

		public ValidationResult ValidationResult { get; set; }

		public bool IsValid()
		{
			//ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
			//return ValidationResult.IsValid;
			return true;
		}
	}
}
