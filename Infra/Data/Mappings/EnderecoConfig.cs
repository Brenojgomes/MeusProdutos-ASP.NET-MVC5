using Business.Models.Fornecedores;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.Mappings
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(x => x.id);

            Property(x => x.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(x => x.Complemento)
                .HasMaxLength(250);

            Property(x => x.Bairro)
                .IsRequired();

            Property(x => x.Cidade)
                .IsRequired();

            Property(x => x.Estado)
                .IsRequired();

            ToTable("Enderecos");


        }
    }
}
