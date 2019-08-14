using FinalProject_MVCapp_SERAFIN.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_MVCapp_SERAFIN.Controllers
{
    public class TaxSystemUsersController : Controller
    {
        private List<TaxSystemUsersMODEL> userLogin;
        string myConnectionStringSRFN = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;
        public TaxSystemUsersController()
        {
            userLogin = new List<TaxSystemUsersMODEL>()
            {
                new TaxSystemUsersMODEL()
                {loginId=10,userName="Tony1",passWord="1",description="descrip10",isAdmin="yes"},
                new TaxSystemUsersMODEL()
                { loginId=11,userName="Tony2",passWord="2",description="descrip11",isAdmin="no"},
                new TaxSystemUsersMODEL()
                {loginId=12,userName="Tony3",passWord="3",description="descrip12",isAdmin="no"},
                new TaxSystemUsersMODEL()
                {loginId=14,userName="Tony4",passWord="4",description="descrip14",isAdmin="no"},
            };
        }
        // GET: TaxSystemUsers
        public ActionResult Manage()
        {
            return View(userLogin);
        }

        // GET: TaxSystemUsers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaxSystemUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxSystemUsers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        static void ReadUsers()
        {
            string myConnectionStringSRFN = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;
            string queryString = "SELECT loginId,userName,passWord,description,isAdmin FROM Nutella.Users;";
            using (var connectionSRFN = new SqlConnection(myConnectionStringSRFN))
            {
                var command = new SqlCommand(queryString, connectionSRFN);
                connectionSRFN.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                    }
                }
            }
        }
            // GET: TaxSystemUsers/Edit/5
            public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TaxSystemUsersMODEL userEdited = Nutella.Users.Find(id);
            //if (userEdited == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: TaxSystemUsers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaxSystemUsers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaxSystemUsers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
