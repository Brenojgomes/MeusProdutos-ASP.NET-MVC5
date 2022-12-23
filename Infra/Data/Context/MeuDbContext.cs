using System.Data.Entity;
using Business.Models.Fornecedores;
using Business.Models.Produtos;

namespace Infra.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext() : base("DefaultConnection"){}

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

    }
}
