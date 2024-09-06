using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Controllers
{
    public class EmployeeController : Controller
    {
        RegisterService objService = new RegisterService();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetEmployeeDetails()
        {
            var employees = objService.GetEmployeeDetails();
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult InsertUpdateEmployee(Employee EmpDet)
        {
            try
            {
                string result = objService.InsertUpdateEmployee(EmpDet);
                return Json(result);
            }
            catch (System.Exception Ex)
            {
                return Json(Ex.Message);
            }
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.ID = id;
            return View("Create");
        }
        public JsonResult GetEmployeeById(int id)
        {
            var employee = objService.GetEmployeeById(id);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult RemoveRecord(int id)
        {
            try
            {
                var Result = objService.RemoveEmployeeData(id);
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception Ex)
            {
                return Json(Ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}