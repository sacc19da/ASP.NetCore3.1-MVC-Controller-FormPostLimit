using FormPostLimitSln.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FormPostLimitSln.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employee()
        {
            List<EmployeeViewModel> employeeList = GetEmployeeList();
            return View(employeeList);
        }

        [HttpPost]
        public IActionResult PostEmployee(List<EmployeeViewModel> postList)
        {
            return Content(postList.Count().ToString());
        }

        public List<EmployeeViewModel> GetEmployeeList()
        {
            List<EmployeeViewModel> retrunList = new List<EmployeeViewModel>();
            for (int i = 1; i <= 1915; i++)
            {
                EmployeeViewModel emp = new EmployeeViewModel();
                emp.EmployeeNo = i.ToString().PadLeft(3, '0');
                emp.EmployeeName = "員工" + i + "號";
                emp.EmployeeAddress = "公司宿舍第" + i + "間";

                retrunList.Add(emp);
            }
            return retrunList;
        }
    }
}
