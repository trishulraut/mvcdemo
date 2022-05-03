using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mvcdemo.Models;
using mvcdemo.Data;

namespace mvcdemo.Controllers
{
    public class APIDemoController : ApiController
    {
        // GET: api/APIDemo
        public IEnumerable<MVCdemoModel> Get()
        {
            var model = new MVCdemoModel().GetMvcdemos();
            return model;
        }

        // GET: api/APIDemo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/APIDemo
        public string Post(MVCdemoModel model)
        {
            var messsage = new MVCdemoModel().Savemvcdemo(model);
            return messsage;
        }

        // PUT: api/APIDemo/5
        public void Put(int ID, MVCdemoModel model)
        {

            var messages = new MVCdemoModel().EditData(ID);
            return messages;
        }

        // DELETE: api/APIDemo/5
        public string Delete(int ID)
        {
            var deletedata = new MVCdemoModel().deletemvc(ID);
          return deletedata;
        }
    }
}
