using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using EP.CrudModalDDD.Domain.Entities;

namespace EP.CrudModalDDD.Infra.Data.EntityConfig
{
    // Fluent API
    public class EmpresaConfig : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfig()
        {
            HasKey(c => c.EmpresaId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Responsavel)
                .IsRequired()
                .HasMaxLength(200);

			Property(c => c.NomeExibicao)
				.IsRequired()
				.HasMaxLength(200);

			Property(c => c.Site)
				.IsRequired()
				.HasMaxLength(200);

			Property(c => c.Telefone1)
				.IsRequired()
				.HasMaxLength(200);

			Property(c => c.Telefone2)
				.IsRequired()
				.HasMaxLength(200);

			Property(c => c.Logradouro)
				.IsRequired()
				.HasMaxLength(200);

			Property(c => c.Numero)
				.IsRequired()
				.HasMaxLength(200);

			Property(c => c.Complemento)
				.IsRequired()
				.HasMaxLength(200);

			Property(c => c.BairroID)
				.IsRequired();


			Property(e => e.CEP)
			   .IsRequired()
			   .HasMaxLength(8);

			Property(c => c.Email1)
				.IsRequired()
				.HasMaxLength(200);

			Property(c => c.Email2)
				.IsRequired()
				.HasMaxLength(200);

			Property(c => c.Descricao)
				.IsRequired()
				.HasMaxLength(200);

			Property(c => c.Complemento)
				.IsRequired()
				.HasMaxLength(200);
			
            Property(c => c.DataCadastro)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Ignore(c => c.ValidationResult);

            ToTable("Empresa");
        }
    }
}