using HorasExtrasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace HorasExtrasAPI.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : Controller
    {
       
        [Route("/error")]
        public MyErrorResponse MyErrorResponse ()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; // Exception
            var code = 500; // Internal Server Error by default

            if (exception is NotFoundException) code = 404; // Not Found
            else if (exception is UnauthorizedAccessException) code = 401; // Unauthorized
            else if (exception is IOException) code = 400; // Bad Request

            Response.StatusCode = code; // codigo de error

            return new MyErrorResponse(exception); // ErrorResponse model
        }

    }
}
