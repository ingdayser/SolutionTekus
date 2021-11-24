using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tekus.Core.Application.Helpers;

namespace Tekus.Core.Api.Filter
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ErrorList = new List<string>();
            foreach (var arg in context.ActionArguments)
            {
                // Omitir valores nulos
                if (arg.Value == null)
                    continue;
                var vt = typeof(AbstractValidator<>);
                var et = arg.Value.GetType();
                var evt = vt.MakeGenericType(et);
                var validatorType = FindValidatorType(Assembly.GetExecutingAssembly(), evt);
                // Omitir si no tiene validador
                if (validatorType == null)
                    continue;
                var validatorInstance = (IValidator)Activator.CreateInstance(validatorType);
                var contextV = new ValidationContext<object>(arg.Value);
                var result = await validatorInstance.ValidateAsync(contextV);
                // Si hay errores copiarlos en una lista
                if (!result.IsValid)
                {
                    foreach (var e in result.Errors)
                        ErrorList.Add(e.ErrorMessage);
                }
            }
            // Si hay errores crea la respuesta personalizada
            if (ErrorList.Count > 0)
            {
                var errorResponse = RequestResult<dynamic>.CreateUnsuccessful(ErrorList);
                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
            await next();
        }
        public static Type FindValidatorType(Assembly assembly, Type evt)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            if (evt == null) throw new ArgumentNullException(nameof(evt));
            return assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(evt));
        }
    }
}
