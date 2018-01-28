using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDMVCAPI.Models.DataModels;

namespace CRUDMVCAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult GetEmployees()
        {
            //using (EmployeeDataEntities dc = new EmployeeDataEntities())
            using (MVCTestEntities dc = new MVCTestEntities())
            {
                //var employees = dc.Employees.OrderBy(a => a.FirstName).ToList();
                var employees = dc.EmployeeDatas.OrderBy(a => a.FirstName).ToList();
                return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            //using (EmployeeDataEntities dc = new EmployeeDataEntities())
            using (MVCTestEntities dc = new MVCTestEntities())
            {
                //var employees = dc.Employees.Where(a => a.EmployeeID == id).FirstOrDefault();
                var employees = dc.EmployeeDatas.Where(a => a.EmployeeID == id).FirstOrDefault();
                return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        //public ActionResult Save(Employee emp)
        public ActionResult Save(EmployeeData emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //using (EmployeeDataEntities dc = new EmployeeDataEntities())
                using (MVCTestEntities dc = new MVCTestEntities())
                {
                    if (emp.EmployeeID > 0)
                    {
                        //Edit 
                        //var v = dc.Employees.Where(a => a.EmployeeID == emp.EmployeeID).FirstOrDefault();
                        var v = dc.EmployeeDatas.Where(a => a.EmployeeID == emp.EmployeeID).FirstOrDefault();
                        if (v != null)
                        {
                            v.FirstName = emp.FirstName;
                            v.LastName = emp.LastName;
                            v.EmailID = emp.EmailID;
                            v.City = emp.City;
                            v.Country = emp.Country;
                        }
                    }
                    else
                    {
                        //Save
                        //dc.Employees.Add(emp);
                        dc.EmployeeDatas.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //using (EmployeeDataEntities dc = new EmployeeDataEntities())
            using (MVCTestEntities dc = new MVCTestEntities())
            {
                //var v = dc.Employees.Where(a => a.EmployeeID == id).FirstOrDefault();
                var v = dc.EmployeeDatas.Where(a => a.EmployeeID == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {
            bool status = false;
            //using (EmployeeDataEntities dc = new EmployeeDataEntities())
            using (MVCTestEntities dc = new MVCTestEntities())
            {
                //var v = dc.Employees.Where(a => a.EmployeeID == id).FirstOrDefault();
                var v = dc.EmployeeDatas.Where(a => a.EmployeeID == id).FirstOrDefault();
                if (v != null)
                {
                    //dc.Employees.Remove(v);
                    dc.EmployeeDatas.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


    }
}
