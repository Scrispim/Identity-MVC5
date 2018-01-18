using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EP.CrudModalDDD.Application.ViewModels
{
    public class EmpresaViewModel
    {
        public EmpresaViewModel()
        {
            EmpresaId = Guid.NewGuid();
        }

        [Key]
        public Guid EmpresaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

		[Required(ErrorMessage = "Preencha o campo Responsável")]
		[MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string Responsavel { get; set; }

		[Required(ErrorMessage = "Preencha o campo Nome de Exibição")]
		[MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string NomeExibicao { get; set; }

		[Required(ErrorMessage = "Preencha o campo Site")]
		[MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string Site { get; set; }

		[Required(ErrorMessage = "Preencha o campo Telefone 1")]
		[MaxLength(15, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(8, ErrorMessage = "Mínimo {0} caracteres")]
		public string Telefone1 { get; set; }

		[Required(ErrorMessage = "Preencha o campo Telefone 2")]
		[MaxLength(15, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(8, ErrorMessage = "Mínimo {0} caracteres")]
		public string Telefone2 { get; set; }

		[Required(ErrorMessage = "Preencha o campo Logradouro")]
		[MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string Logradouro { get; set; }

		[Required(ErrorMessage = "Preencha o campo Número")]
		[MaxLength(10, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(1, ErrorMessage = "Mínimo {0} caracteres")]
		public string Numero { get; set; }

		[Required(ErrorMessage = "Preencha o campo Complemento")]
		[MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string Complemento { get; set; }

		[Required(ErrorMessage = "Preencha o campo Bairro")]
		public Int64 BairroID { get; set; }

		[Required(ErrorMessage = "Preencha o campo CEP")]
		[MaxLength(8, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string CEP { get; set; }

		[Required(ErrorMessage = "Preencha o campo Email 1")]
		[MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string Email1 { get; set; }

		[Required(ErrorMessage = "Preencha o campo Email 2")]
		[MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string Email2 { get; set; }

		[Required(ErrorMessage = "Preencha o campo Descrição")]
		[MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
		[MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
		public string Descricao { get; set; }

		
        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }
		public bool Excluido { get; set; }

		[ScaffoldColumn(false)]
		public DateTime DataCadastro { get; set; }

		[ScaffoldColumn(false)]
		public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

	}
}