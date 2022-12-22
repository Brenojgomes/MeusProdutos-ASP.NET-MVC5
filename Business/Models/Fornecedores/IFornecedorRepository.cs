﻿using Business.Core.Data;
using System;
using System.Threading.Tasks;

namespace Business.Models.Fornecedores
{
    interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}