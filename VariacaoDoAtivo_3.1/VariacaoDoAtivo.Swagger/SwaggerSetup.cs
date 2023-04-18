using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace VariacaoDoAtivo.Swagger
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Variação do Ativo .NET Core",
                    Version= "v1",
                    Description = "Projeto desenvolvido com .NET Core e Angular a titulo de portfólio.",
                    Contact = new OpenApiContact
                    {
                        Name = "Pedro Henrique Palmuti Freitas",
                        Email = "palmutip@hotmail.com",
                        Url = new Uri("https://palmutip.github.io")
                    }
                });

                var xmlPath = Path.Combine("wwwroot", "api-documentation.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger/ui";
                c.SwaggerEndpoint("../../swagger/v1/swagger.json", "API v1");
            });
        }
    }
}
