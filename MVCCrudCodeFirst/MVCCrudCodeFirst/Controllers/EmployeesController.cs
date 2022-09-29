using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dapper;
using MVCCrudCodeFirst.Data;
using MVCCrudCodeFirst.Models;

namespace MVCCrudCodeFirst.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private CrudDbContext db = new CrudDbContext();

        private string connectionString = "Data Source=.; Initial Catalog=CrudCodeFirst; Integrated Security=True";

        [Authorize(Roles = "Admin, Customer")]
        // GET: Employees
        public ActionResult Index()
        {
            //using linq
            //return View(db.Employees.ToList());

            //call customDapper class
            //return View(DapperORM.ReturnList<Employee>("EmployeeViewAll", null));

            //using dapper, no more class calling
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();
            //    var people = conn.Query<Employee>("EmployeeViewAll", commandType:CommandType.StoredProcedure);
            //    conn.Close();
            //    return View(people);
            //}

           try
            {
                var selectedEmployee = "Select * from Employees";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    List<Employee> employeeDynamic = connection.Query<Employee>(selectedEmployee).ToList();
                    connection.Close();
                    return View(employeeDynamic);
                }
            } catch (Exception ex)
            {
                //..
                return View();
            }
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Mobile,Age")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //using simple query
        //I will create a data folder, inside, create a class , EmployeeDAO.cs
        //I will comment the code from the Index Action Method
        public ActionResult SimpleQueryFetchAllEmployee()
        {
            List<Employee> emps = new List<Employee>();
            EmployeeDAO empDAO = new EmployeeDAO();

            emps = empDAO.FetchAllEmployee();

            return View("Index", emps);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
