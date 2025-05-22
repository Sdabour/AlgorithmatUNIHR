using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Owin;
using Microsoft.Owin;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
 
[assembly: OwinStartup(typeof(AlgorithmatMVC.Startup))]
namespace AlgorithmatMVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
            app.UseJwtBearerAuthentication(
                 new JwtBearerAuthenticationOptions
                 {
                     AuthenticationMode = AuthenticationMode.Active,
                     TokenValidationParameters = new TokenValidationParameters()
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = "JWTAuthenticationServer", //some string, normally web url,
                         ValidAudience = "JWTServicePostmanClient",
                         IssuerSigningKey = new

  SymmetricSecurityKey(Encoding.UTF8.GetBytes("SAMEHODRYBUWNLIGZKCFJKPQT"))

                     }
                 });


        }

    }
}