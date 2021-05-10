using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bshoes.Admin.Middleware
{
    public class loginmiddleware
    {
        private readonly RequestDelegate _next;
        public loginmiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public Task Invoke(HttpContext context)
        {
            var username = context.Request.Query["username"].ToString();
            if (username != "phong")
            {
                context.Response.Redirect("/Login");
            }

            return  _next(context);


        }
    }
    public static class CustomAuthenticationExtensions
    {
        public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<loginmiddleware>();
        }
    }
}
