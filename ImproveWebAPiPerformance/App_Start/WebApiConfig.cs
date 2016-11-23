using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;

namespace ImproveWebAPiPerformance
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            var formatters = config.Formatters.Where(formatter =>
                 formatter.SupportedMediaTypes.Where(media =>
                 media.MediaType.ToString() == "application/xml" || media.MediaType.ToString() == "text/html").Count() > 0) //找到请求头信息中的介质类型
                 .ToList();

            foreach (var match in formatters)
            {
                config.Formatters.Remove(match);
            }

          

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
