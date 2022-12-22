using Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Models.Produtos
{
    interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObeterProdutosPorFornecedor(Guid fornecedorId); 
        Task<IEnumerable<Produto>> ObeterProdutosFornecedores(); 
        Task<Produto> ObeterProdutoFornecedor(Guid id); 
    }
}
