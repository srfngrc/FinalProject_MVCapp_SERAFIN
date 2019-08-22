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
    public class TaxSystemOperatController : Controller
    {
        // GET: TaxSystemOperat
        public ActionResult Manage()
        {
            List<TaxSystemOperatMODEL> ListOfOperations = new List<TaxSystemOperatMODEL>();
            ListOfOperations = ReadAllOperationsFromDB();
            return View("Manage", ListOfOperations);
        }

        static List<TaxSystemOperatMODEL> ReadAllOperationsFromDB()
        {
            List<TaxSystemOperatMODEL> myOperations = new List<TaxSystemOperatMODEL>();
            SqlConnection myConnSRFN2 = new SqlConnection();
            try
            {
                myConnSRFN2.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;
                myConnSRFN2.Open();

                string queryString = "SELECT operationId,isin,purchaseDate,sellDate,amount,description FROM Nutella.operations;";
                SqlCommand commandReadAll = new SqlCommand(queryString, myConnSRFN2);

                SqlDataReader myUsersResults = commandReadAll.ExecuteReader();
                while (myUsersResults.Read())
                {
                    TaxSystemOperatMODEL newOperation = new TaxSystemOperatMODEL();
                    newOperation.operationId = int.Parse(myUsersResults["operationId"].ToString());
                    newOperation.isin = myUsersResults["isin"].ToString();

                    newOperation.purchaseDate = (DateTime)myUsersResults["purchaseDate"];
                    newOperation.sellDate = Convert.ToDateTime(myUsersResults["sellDate"]);

                    //the most correct one: the one with selldate but with Tostring("YYYY-MM-dd") at the end                    newOperation.amount = myUsersResults["amount"].ToString();
                    newOperation.description = myUsersResults["description"].ToString();
                    myOperations.Add(newOperation);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                myConnSRFN2.Close();
            }
            return myOperations;
        }




        // GET: TaxSystemOperat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaxSystemOperat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxSystemOperat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            TaxSystemOperatMODEL newOperation = new TaxSystemOperatMODEL();
            SqlConnection connCREATEpost = new SqlConnection();
            try
            {
                connCREATEpost.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;

                newOperation.isin = collection["isin"];
                newOperation.purchaseDate = Convert.ToDateTime(collection["purchaseDate"].ToString());
                newOperation.sellDate = Convert.ToDateTime(collection["sellDate"].ToString());
                //newOperation.sellDate = collection["sellDate"].ToString("YYYY-MM-dd");
                newOperation.amount = collection["amount"];
                newOperation.description = collection["description"];

                string queryCREATE = "INSERT INTO Nutella.operations (isin,purchaseDate,sellDate,amount,description)" +
                    " VALUES ('" +
                    newOperation.isin + "','" +
                    newOperation.purchaseDate + "','" +
                    newOperation.sellDate + "','" +
                    newOperation.amount + "','" +
                newOperation.description + "');";

                connCREATEpost.Open();

                SqlCommand commCREATEpost = new SqlCommand(queryCREATE, connCREATEpost);
                commCREATEpost.ExecuteNonQuery();

                return RedirectToAction("Manage");
            }
            catch
            {
                return View();
            }
            finally
            {
                connCREATEpost.Close();
            }
        }

        // GET: TaxSystemOperat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaxSystemOperat/Edit/5
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

        // GET: TaxSystemOperat/Delete/5
        public ActionResult Delete(int id)
        {
            //Here I open the connection to the DB and I execute the delete query
            SqlConnection connDELETEPost = new SqlConnection();
            connDELETEPost.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;

            try
            {
                connDELETEPost.Open();
                SqlCommand commDELETEpost = new SqlCommand("DELETE FROM Nutella.operations WHERE operationId = " + id + ";", connDELETEPost);
                int a = commDELETEpost.ExecuteNonQuery();
            }
            catch
            {
                return null;
            }
            finally
            {
                connDELETEPost.Close();
            }
            //After actually deleting that operation's row, 
            //I call the Manage method again to show the updated list of Operations

            return RedirectToAction("Manage");
        }

        
    }
}
