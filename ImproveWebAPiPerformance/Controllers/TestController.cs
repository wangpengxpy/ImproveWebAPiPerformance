using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ImproveWebAPiPerformance.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [CompressContent]
        [CacheFilter(CacheTimeDuration = 100)]
        public async Task<IHttpActionResult> GetZipData()
        {
            var sw = new Stopwatch();
            sw.Start();
            Dictionary<object, object> dict = new Dictionary<object, object>();
            List<Employee> li = new List<Employee>();
            li.Add(new Employee { Id = "2", Name = "xpy0928", Email = "a@gmail.com" });
            li.Add(new Employee { Id = "3", Name = "tom", Email = "b@mail.com" });
            li.Add(new Employee { Id = "4", Name = "jim", Email = "c@mail.com" });
            li.Add(new Employee { Id = "5", Name = "tony", Email = "d@mail.com" });

            sw.Stop();

            dict.Add("Details", li);
            dict.Add("Time", sw.Elapsed.Milliseconds);

            return Ok(dict);

        }

        public async Task<IHttpActionResult> Register(Employee model)
        {
            var result = await UserManager.CreateAsync(model);
            return Ok(result);
        }
    }
}
