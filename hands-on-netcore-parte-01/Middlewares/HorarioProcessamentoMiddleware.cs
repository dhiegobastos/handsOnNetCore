using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace hands_on_netcore.Middlewares
{
    public class HorarioProcessamentoMiddleware
    {
        private readonly IConfiguration _configuration;
        private readonly RequestDelegate _next;

        public HorarioProcessamentoMiddleware(IConfiguration configuration, RequestDelegate next)
        {
            _configuration = configuration;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var horaLimite = _configuration.GetValue<int>("API:HoraLimite");
            var horaAtual = DateTime.Now.Hour;

            if (horaAtual >= horaLimite)
            {
                context.Response.StatusCode = 451;
                context.Response.ContentType = "application/json";

                var response = new ResponseError()
                {
                    codigo = "LDA-1234",
                    mensagem = $"Solicitação inválida. Horário limite para requisição até às {horaLimite} horas."
                };

                string jsonString = JsonConvert.SerializeObject(response);
                await context.Response.WriteAsync(jsonString, Encoding.UTF8);

                return;
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }

        private class ResponseError
        {
            public string codigo { get; set; }
            public string mensagem { get; set; }
        }
    }
}