using FinalProject_MVCapp_SERAFIN.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_MVCapp_SERAFIN.Controllers
{
    public class TaxSystemOperationController : Controller
    {
        // GET: TaxSystemOperation
        public ActionResult Manage()
        {
            //List<TaxSystemOperationMODEL> ListOfOperations = new List<TaxSystemOperationController>;
            //ListOfOperations = ReadAllOperationsFromDB();
            //return View("Manage", ListOfOperations);
            return View();
        }

        //static List<TaxSystemOperationMODEL> ReadAllOperationsFromDB()
        //{
        //    List<TaxSystemOperationMODEL> myOperations = new List<TaxSystemOperationMODEL>();
        //    SqlConnection myConnSRFN2 = new SqlConnection();
        //    try
        //    {
        //        myConnSRFN2.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;
        //        myConnSRFN2.Open();

        //        string queryString = "SELECT operationId,isin,purchaseDate,sellDate,amount,description FROM Nutella.operations;";
        //        SqlCommand commandReadAll = new SqlCommand(queryString, myConnSRFN2);

        //        SqlDataReader myUsersResults = commandReadAll.ExecuteReader();
        //        while (myUsersResults.Read())
        //        {
        //            TaxSystemOperationMODEL newOperation = new TaxSystemOperationMODEL();
        //            newOperation.operationId = int.Parse(myUsersResults["loginId"].ToString());
        //            newOperation.isin = myUsersResults["userName"].ToString();
        //            newOperation.purchaseDate = myUsersResults["passWord"].ToString();
        //            newOperation.sellDate = myUsersResults["description"].ToString();
        //            newOperation.amount = myUsersResults["isAdmin"].ToString();
        //            newOperation.description = myUsersResults["isAdmin"].ToString();
        //            myOperations.Add(newOperation);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        myConnSRFN2.Close();
        //    }
        //    return myOperations;
        //}


        // GET: TaxSystemOperation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaxSystemOperation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxSystemOperation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaxSystemOperation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaxSystemOperation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TaxSystemOperation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaxSystemOperation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
