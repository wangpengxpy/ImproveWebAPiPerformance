using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Filters;

namespace ImproveWebAPiPerformance
{
    public class CacheFilterAttribute : ActionFilterAttribute
    {
        public int CacheTimeDuration { get; set; }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromSeconds(CacheTimeDuration),
                MustRevalidate = true,
                Public = true
            };
        }
    }
}