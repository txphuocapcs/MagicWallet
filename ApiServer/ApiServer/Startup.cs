using ApiServer.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ApiServer.SQL;

[assembly: OwinStartup(typeof(ApiServer.Startup))]
namespace ApiServer
{
    public class Startup
    {
        public static object OAuthBearerOptions { get; internal set; }

        //startup config
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
 
            ConfigureOAuth(app);
 
            WebApiConfig.Register(config);
            SQLClient.Instance.init();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
 
        }

        //config owin token server
        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(15),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}