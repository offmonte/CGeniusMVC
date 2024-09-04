using CGenius.Data;
using CGenius.DTOs;
using CGenius.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CGenius.Controllers
{
    public class AtualizacaoController : Controller
    {
        private readonly DataContext _dataContext;

        public AtualizacaoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        
        public IActionResult LerAtualizacao()
        {
            return View();
        }

        
        public IActionResult EnviarAtualizacao(AtualizacaoDTO request)
        {
            var atualizacao = new Atualizacao
            {
                CpfAtendente = request.CpfAtendente,
                CpfCliente = request.CpfCliente,
                IdScript = request.IdScript,
                IdPlano = request.IdPlano,
                IdEspecificacao = request.IdEspecificacao,
                DataAtualizacao = DateTime.Now
            };
            _dataContext.Atualizacoes.Add(atualizacao);
            _dataContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult EditarAtualizacao(int id, AtualizacaoDTO request)
        {
            var atualizacao = _dataContext.Atualizacoes.Find(id);
            if (atualizacao == null)
            {
                return NotFound();
            }

            atualizacao.CpfAtendente = request.CpfAtendente;
            atualizacao.CpfCliente = request.CpfCliente;
            atualizacao.IdScript = request.IdScript;
            atualizacao.IdPlano = request.IdPlano;
            atualizacao.IdEspecificacao = request.IdEspecificacao;

            _dataContext.Atualizacoes.Update(atualizacao);
            _dataContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeletarAtualizacao(int id)
        {
            var atualizacao = _dataContext.Atualizacoes.Find(id);
            if (atualizacao == null)
            {
                return NotFound();
            }

            _dataContext.Atualizacoes.Remove(atualizacao);
            _dataContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
