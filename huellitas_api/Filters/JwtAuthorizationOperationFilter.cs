using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace huellitas_api.Filters
{
    public class JwtAuthorizationOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Validar si el endpoint o controlador requiere [Authorize]
            var hasAuthorize = context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                               context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            if (!hasAuthorize) return;

            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "No Autorizado (Falta Token o es inválido)" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Prohibido (No tienes los permisos requeridos)" });

            // Inicializar los requisitos de seguridad si están vacíos
            operation.Security ??= new List<OpenApiSecurityRequirement>();

            var securityScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [securityScheme] = new List<string>()
            });
        }
    }
}