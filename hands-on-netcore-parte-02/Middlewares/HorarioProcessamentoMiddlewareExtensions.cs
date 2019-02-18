using Microsoft.AspNetCore.Builder;

namespace hands_on_netcore.Middlewares
{
    public static class HorarioProcessamentoMiddlewareExtensions
    {
        public static IApplicationBuilder UseHorarioProcessamento(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HorarioProcessamentoMiddleware>();
        }
    }
}