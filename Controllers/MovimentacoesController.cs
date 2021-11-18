﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBCORE_Clinica_Medica.Models;
using WEBCORE_Clinica_Medica.Models.Dominio;

namespace WEBCORE_Clinica_Medica.Controllers
{
    [Authorize]
    public class MovimentacoesController : Controller
    {
        private readonly Contexto _context;

        public MovimentacoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Movimentacoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Movimentacoes.Include(m => m.produto);
            return View(await contexto.ToListAsync());
        }

        // GET: Movimentacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(m => m.produto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // GET: Movimentacoes/Create
        public IActionResult Create()
        {
            var tMovimentacao = Enum.GetValues(typeof(MovimentacaoTipo))
                                .Cast<MovimentacaoTipo>()
                                .Select(p => new SelectListItem
                                {
                                    Value = p.ToString(),
                                    Text = p.ToString()
                                });

            ViewBag.tMovimentacao = tMovimentacao;
            ViewData["idProduto"] = new SelectList(_context.Produtos, "id", "descricao");
            return View();
        }

        // POST: Movimentacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,idProduto,movTipo,quantidade")] Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                var produto = await _context.Produtos.FindAsync(movimentacao.idProduto);
                if (movimentacao.movTipo.Equals(MovimentacaoTipo.Entrada))
                {
                    produto.estoque += movimentacao.quantidade;
                    produto.total = produto.preco * produto.estoque;
                    _context.Add(movimentacao);
                    _context.Produtos.Update(produto);
                }
                if (movimentacao.movTipo.Equals(MovimentacaoTipo.Saída))
                {
                    produto.estoque -= movimentacao.quantidade;
                    if (produto.estoque > 0)
                    {
                        produto.total = produto.preco * produto.estoque;
                        _context.Add(movimentacao);
                        _context.Produtos.Update(produto);
                    }
                    else
                    {
                        throw new ArgumentException("A quantidade da movimentação de saída deve ser menor que o Estoque");
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idProduto"] = new SelectList(_context.Produtos, "id", "descricao", movimentacao.idProduto);
            return View(movimentacao);
        }

        // GET: Movimentacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacoes
                .Include(m => m.produto)
                .FirstOrDefaultAsync(m => m.id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // POST: Movimentacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacao = await _context.Movimentacoes.FindAsync(id);
            _context.Movimentacoes.Remove(movimentacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacaoExists(int id)
        {
            return _context.Movimentacoes.Any(e => e.id == id);
        }
    }
}
