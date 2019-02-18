using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hands_on_netcore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hands_on_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }
        // GET: api/Turma
        [HttpGet]
        public IActionResult Get()
        {
            _turmaService.ExecutarRegrasTurma();
            return Ok("Regra Executada");
        }
    }
}
