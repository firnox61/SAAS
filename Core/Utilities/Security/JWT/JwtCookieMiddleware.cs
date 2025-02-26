using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtCookieMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtCookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Çerezden JWT'yi al
            if (context.Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                context.Request.Headers.Append("Authorization", $"Bearer {token}");
            }

            await _next(context);
        }
    }
}
