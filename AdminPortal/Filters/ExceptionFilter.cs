using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using Application.Exceptions;
using Application.Models.Profile;
using Application.Models.Account;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortal.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new BadRequestObjectResult(context.Exception.Message);
        }
    }
}
