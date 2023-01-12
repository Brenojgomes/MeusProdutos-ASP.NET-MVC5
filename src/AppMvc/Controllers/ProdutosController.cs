﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using AppMvc.ViewModels;
using Business.Models.Produtos;
using Business.Models.Produtos.Services;
using Infra.Data.Repository;
using Business.Core.Notificacoes;
using AutoMapper;

namespace AppMvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
            _produtoService = new ProdutoService(_produtoRepository, new Notificador());
        }

        [Route("lista-de-produtos")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos()));
        }

        [Route("dados-do-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Route("novo-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {         
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel));
                return RedirectToAction("Index");
            }
            return View(produtoViewModel);
        }

        [Route("excluir-produto/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [Route("excluir - produto /{id: guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }

            await _produtoService.Remover(id);
            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObeterProdutoFornecedor(id));
            return produto;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoService.Dispose();
                _produtoRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}