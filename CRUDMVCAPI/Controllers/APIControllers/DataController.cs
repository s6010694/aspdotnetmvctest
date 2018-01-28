using CRUDMVCAPI.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace CRUDMVCAPI.Controllers.APIControllers
{
    public class DataController : ApiController
    {
        //private EmployeeDataEntities db = new EmployeeDataEntities();
        private MVCTestEntities db = new MVCTestEntities();
        // GET api/GetEmployees
        public Object Get()
        {
            //List<Employee> emplist = db.Employees.ToList();
            List<EmployeeData> emplist = db.EmployeeDatas.ToList();
            return Json(new { data = emplist });
        }

        // GET api/Get/5
        public Object Get(int id)
        {
            //var employees = db.Employees.Find(id);
            var employees = db.EmployeeDatas.Find(id);
            return Json(new { data = employees });
        }

        // POST api/Post
        //public Object Post(Employee emp)
        public Object Post(EmployeeData emp)
        {
            //Save
            //db.Employees.Add(emp);
            db.EmployeeDatas.Add(emp);
            db.SaveChanges();
            return Json(new { data = emp });
        }

        // PUT api/put/5
        //public Object Put(int id, Employee emp)
        public Object Put(int id, EmployeeData emp)
        {
            //var data = db.Employees.Find(id);
            var data = db.EmployeeDatas.Find(id);
            if (data != null)
            {
                data.FirstName = emp.FirstName;
                data.LastName = emp.LastName;
                data.EmailID = emp.EmailID;
                data.City = emp.City;
                data.Country = emp.Country;
            }
            db.SaveChanges();
            return Json(new { data = emp });
        }

        // DELETE api/<controller>/5
        public Object Delete(int id)
        {
            //Employee data = db.Employees.Find(id);
            EmployeeData data = db.EmployeeDatas.Find(id);

            //db.Employees.Remove(data);
            db.EmployeeDatas.Remove(data);
            db.SaveChanges();
            return Json(new { data = data });
        }
    }
}