using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hands_on_netcore.Model;
using Microsoft.AspNetCore.Mvc;

namespace hands_on_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoService _ProdutoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _ProdutoService = produtoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return Ok(_ProdutoService.ObterProdutos());
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            return Ok(_ProdutoService.ObterProdutoPorId(id));
        }

        [HttpPost]
        public ActionResult<Produto> AddProduto([FromBody] Produto produto)
        {
            _ProdutoService.AddProduto(produto);
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }
    }
}