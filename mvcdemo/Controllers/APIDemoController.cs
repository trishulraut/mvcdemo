using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    public class APIDemoController : ApiController
    {
        // GET: api/APIDemo
        public IEnumerable<mvcdemoModel> Get()
        {
            var model = new mvcdemoModel().GetMvcdemos();
            return model;
        }

        // GET: api/APIDemo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/APIDemo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/APIDemo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/APIDemo/5
        public void Delete(int id)
        {
        }
    }
}
