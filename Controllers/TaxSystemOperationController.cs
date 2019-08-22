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
            List<TaxSystemOperationMODEL> ListOfOperations = new List<TaxSystemOperationMODEL>();
            ListOfOperations = ReadAllOperationsFromDB();
            return View("Manage", ListOfOperations);
        }

        static List<TaxSystemOperationMODEL> ReadAllOperationsFromDB()
        {
            List<TaxSystemOperationMODEL> myOperations = new List<TaxSystemOperationMODEL>();
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
                    TaxSystemOperationMODEL newOperation = new TaxSystemOperationMODEL();
                    newOperation.operationId = int.Parse(myUsersResults["operationId"].ToString());
                    newOperation.isin = myUsersResults["isin"].ToString();

                    newOperation.purchaseDate = (DateTime)myUsersResults["purchaseDate"];
                    newOperation.sellDate = Convert.ToDateTime(myUsersResults["sellDate"]);

                    //the most correct one: the one with selldate but with Tostring("YYYY-MM-dd") at the end                    newOperation.amount = myUsersResults["amount"].ToString();
                    newOperation.description1 = myUsersResults["description"].ToString();
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
            TaxSystemOperationMODEL newOperation = new TaxSystemOperationMODEL();
            SqlConnection connCREATEpost = new SqlConnection();
            try
            {
                connCREATEpost.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;

                newOperation.isin = collection["isin"];
                newOperation.purchaseDate = Convert.ToDateTime(collection["purchaseDate"].ToString());
                newOperation.sellDate = Convert.ToDateTime(collection["sellDate"].ToString());
                //newOperation.sellDate = collection["sellDate"].ToString("YYYY-MM-dd");
                newOperation.amount = collection["amount"];
                newOperation.description1 = collection["description"];

                string queryCREATE = "INSERT INTO Nutella.operations (isin,purchaseDate,sellDate,amount,description)" +
                    " VALUES ('" +
                    newOperation.isin + "','" +
                    newOperation.purchaseDate + "','" +
                    newOperation.sellDate + "','" +
                    newOperation.amount + "','" +
                newOperation.description1 + "');";

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

        // GET: TaxSystemOperation/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    //I configure the connection to the DB
        //    SqlConnection connEDITget = new SqlConnection();
        //    connEDITget.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;
        //    TaxSystemOperationMODEL OperationToEdit = new TaxSystemOperationMODEL();

        //    try
        //    {
        //        string queryEDITget = "SELECT isin,purchaseDate,sellDate,amount,description FROM Nutella.operations WHERE operationId=" + id + ";";
        //        SqlCommand commandEDITget = new SqlCommand(queryEDITget, connEDITget);

        //        connEDITget.Open();
        //        SqlDataReader OperationWeWannaEdit = commandEDITget.ExecuteReader();

        //        //now I assign the result of the select to the Database to each element of the object
        //        //UserToEdit, recently created above
        //        while (OperationWeWannaEdit.Read())
        //        {
        //            OperationToEdit.isin = OperationWeWannaEdit["isin"].ToString();
        //            OperationToEdit.purchaseDate = Convert.ToDateTime(OperationWeWannaEdit["purchaseDate"]);
        //            OperationToEdit.sellDate = Convert.ToDateTime(OperationWeWannaEdit["sellDate"]);
        //            OperationToEdit.amount = OperationWeWannaEdit["amount"].ToString();
        //            OperationToEdit.description1 = OperationWeWannaEdit["description"].ToString();
        //        }

        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        connEDITget.Close();
        //    }

        //    return View(OperationToEdit);
        //}

        //// POST: TaxSystemOperation/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: TaxSystemOperation/Delete/5
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

        //// POST: TaxSystemOperation/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{

        //}
    }
}
