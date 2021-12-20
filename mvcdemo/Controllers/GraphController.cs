using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcdemo.Data;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    public class GraphController : Controller
    {
        // GET: Graph
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RadarAreaChart()
        {
            return View(RadarChartData.GetData());
        }

        public ActionResult finalresultgraph()
        {
            return View();
        }
        public ActionResult newgraph()
        {
            return View();
        }
    }
}
    
