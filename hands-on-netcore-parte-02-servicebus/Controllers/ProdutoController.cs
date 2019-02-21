using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using hands_on_netcore.Model.Domain;
using hands_on_netcore.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace hands_on_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        private readonly IServiceBus _serviceBus;

        public ProdutoController(IProdutoService produtoService, IMapper mapper,
            IServiceBus serviceBus)
        {
            _produtoService = produtoService;
            _mapper = mapper;
            _serviceBus = serviceBus;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDto>> Get()
        {
            IList<Produto> produtos = _produtoService.ObterProdutos();
            return Ok(_mapper.Map<IList<ProdutoDto>>(produtos));
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoDto> GetById(int id)
        {
            Produto produto = _produtoService.ObterProdutoPorId(id);
            if (produto != null)
            {
                return Ok(_mapper.Map<ProdutoDto>(produto));
            }
            return NotFound(id);
        }

        [HttpPost]
        public ActionResult<NovoProdutoDto> AddProduto([FromBody] NovoProdutoDto novoProduto)
        {
            Produto produto = _mapper.Map<Produto>(novoProduto);

            Produto produtoCriado = _produtoService.AddProduto(produto);

            // Envia mensagem
            _serviceBus.Publicar(produtoCriado.Id.ToString(), JsonConvert.SerializeObject(produtoCriado));

            return CreatedAtAction(nameof(GetById), new { id = produtoCriado.Id }, novoProduto);
        }
    }
}