using EadFinalFrontend.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EadFinalFrontend.Controllers
{
    public class HomeController : Controller
    {
        private Service1Client service = new Service1Client();

        public ActionResult Index()
        {
            var data = service.SearchEmployees(null);
            return View(data);
        }

        public ActionResult SearchAjax()
        {
            var keyword = this.Request.QueryString["keyword"];
            var result = service.SearchEmployees(keyword);
            return PartialView("SearchAjax", result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var result = service.AddEmployee(employee.Name, employee.Salary, employee.Department);
            if (!result)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}