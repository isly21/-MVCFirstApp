using MVCFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFirstApp.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpDBContext db = new EmpDBContext();

        // [HttpGet] // permet de specifier que c'est la methode que l'on souhaite utiliser
        public ActionResult Search()
        {
            var input = "Another Search action";
            return Content(input);
        }


        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            //List<Employee> empList = GetEmployeeList();
            var employee = empList.Single(m => m.ID == id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var employee = empList.Single(m => m.ID == id);
                if (TryUpdateModel(employee))
                {
                    //To Do:- database code
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Test()
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        //[HttpPost]
        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public static List<Employee> empList = new List<Employee>{
           new Employee{
              ID = 1,
              Name = "Allan",
              JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
              Age = 23
           },

           new Employee{
              ID = 2,
              Name = "Carson",
              JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
              Age = 45
           },

           new Employee{
              ID = 3,
              Name = "Carson",
              JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
              Age = 37
           },

           new Employee{
              ID = 4,
              Name = "Laura",
              JoiningDate = DateTime.Parse(DateTime.Today.ToString()),
              Age = 26
           },

        };
    

        public ActionResult Index()
        {
            var employees = from e in db.Employees
                            orderby e.ID
                            select e;
            return View(employees);
        }

    }
}