using Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Mappings
{
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfig()
        {
            HasKey(f => f.id);

            Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(F => F.Documento)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute { IsUnique = true }));

            HasRequired(f=>f.Endereco)
        }
    }
}
