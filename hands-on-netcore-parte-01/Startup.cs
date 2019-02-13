using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using hands_on_netcore.Middlewares;
using hands_on_netcore.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace hands_on_netcore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddJsonOptions(opcoes =>
            {
                opcoes.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddSingleton<IProdutoService, ProdutoService>(ec =>
            {
                int qtdProdutos = Configuration.GetValue<int>("API:NumeroProdutos");
                return new ProdutoService(qtdProdutos);
            });

            //Configuração de propriedades do middleware de compressão
            services.Configure<GzipCompressionProviderOptions>(opcoes =>
            {
                opcoes.Level = CompressionLevel.Optimal;
            });
            services.AddResponseCompression(opcoes =>
            {
                opcoes.Providers.Add<GzipCompressionProvider>();
                opcoes.EnableForHttps = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Middleware customizado
            app.UseHorarioProcessamento();

            app.UseHttpsRedirection();

            // Middleware Compressão
            app.UseResponseCompression();

            app.UseMvc();
        }
    }
}
