using Business.Core.Data;
using System;
using System.Threading.Tasks;

namespace Business.Models.Fornecedores
{
    interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
