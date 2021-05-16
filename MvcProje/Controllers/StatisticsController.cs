using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var value1 = context.Categories.Count().ToString();
            ViewBag.CategoryCount = value1;

            var value2 = context.Headings.Count(x => x.CategoryID == 13).ToString();
            ViewBag.Heading = value2;

            var value3 = context.Writers.Where(x => x.WriterName.Contains("a") || x.WriterName.Contains("A")).Count();
            ViewBag.Writer = value3;

            var value4 = context.Categories.Where(x => x.CategoryID == context.Headings.GroupBy(a => a.CategoryID).OrderByDescending(a => a.Count())
                .Select(a => a.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.HeadingMax = value4;

            var value5 = context.Categories.Where(b => b.CategoryStatus == true).Count() -
                          context.Categories.Where(b => b.CategoryStatus == false).Count();
            ViewBag.StatusDiffrerent = value5;

            return View();
        }
    }
}