using AtallaHSM.Data.DBDapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Description;
using IOperationFilter = Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter;

namespace HPPay.Infrastructure.Swagger
{

    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public string controllerName = null;
        
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            controllerName = context.MethodInfo.DeclaringType.ToString();
            if (!controllerName.Contains("TMFL") && !controllerName.Contains("HLFL") && !controllerName.Contains("CustomerAPI") && !controllerName.Contains("SFLAPI") && !controllerName.Contains("STFCAPI") && !controllerName.Contains("M2PAPI"))
            {

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "access token",
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                        Default = new OpenApiString("Bearer ")
                    }                


                }); ;
                operation.Parameters.Add(new OpenApiParameter
                {

                    Name = "API_Key",
                    In = ParameterLocation.Header,
                    Description = "API_Key",
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }


                }
                );

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Secret_Key",
                    In = ParameterLocation.Header,
                    Description = "Secret_Key",
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }

                }
                );
            }
            else if (controllerName.Contains("TMFL") || controllerName.Contains("HLFL"))
            {
                operation.Parameters.Add(new OpenApiParameter
                {

                    Name = "Username",
                    In = ParameterLocation.Header,
                    Description = "Username",
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }


                }
               );

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Password",
                    In = ParameterLocation.Header,
                    Description = "Password",
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }

                }
                );

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "SecurityToken",
                    In = ParameterLocation.Header,
                    Description = "SecurityToken",
                    Required = false,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }

                }
                );
            }
        
        }
    }

}
