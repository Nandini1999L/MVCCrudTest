using CrudOperation.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace CrudOperation.Controllers
{
    public class RegisterController : Controller
    {
        RegisterService objService = new RegisterService();

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
    }
}