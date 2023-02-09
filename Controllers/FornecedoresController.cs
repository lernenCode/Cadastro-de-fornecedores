using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cadastro_de_fornecedores.Models;
using Cadastro_de_fornecedores.Repositorio;

namespace Cadastro_de_fornecedores.Controllers
{
    [Route("[controller]")]
    public class FornecedoresController : Controller
    {
        private readonly IFornecedoresRepositorio _FornecedoresRepositorio;
        public FornecedoresController(IFornecedoresRepositorio FornecedoresRepositorio)
        {
            _FornecedoresRepositorio = FornecedoresRepositorio;
        }

        [Route("Fornecedores/Index")]
        public IActionResult Index()
        {
            List<FornecedoresModel> Fornecedores = _FornecedoresRepositorio.BuscarTodos();
            return View(Fornecedores);
        }
        
        [Route("Fornecedores/Criar")]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost("Fornecedores/Adicionar")]
        public IActionResult Adicionar(FornecedoresModel Fornecedores)
        {
            _FornecedoresRepositorio.Adicionar(Fornecedores);
            return RedirectToAction("Index");
        }

        [Route("Fornecedores/Editar")]
        public IActionResult Editar(int id)
        {
            FornecedoresModel fornecedores = _FornecedoresRepositorio.ListarPorId(id);
            return View(fornecedores);
        }

        [HttpPost("Fornecedores/Alterar")]
        public IActionResult Alterar(FornecedoresModel Fornecedores)
        {
            _FornecedoresRepositorio.Atualizar(Fornecedores);
            return RedirectToAction("Index");
        }

        [Route("Fornecedores/ApagarConfirmacao")]
        public IActionResult ApagarConfirmacao(int id)
        {
            FornecedoresModel fornecedores = _FornecedoresRepositorio.ListarPorId(id);
            return View(fornecedores);
        }

        public IActionResult Apagar(int id)
        {
            _FornecedoresRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
        
    }
}