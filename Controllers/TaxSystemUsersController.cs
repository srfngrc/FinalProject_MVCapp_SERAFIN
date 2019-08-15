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
            List<TaxSystemUsersMODEL> aa = new List<TaxSystemUsersMODEL>();
            aa = ReadUsersFromDB();
            return View("Manage", aa);
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
            TaxSystemUsersMODEL CreateNewUser = new TaxSystemUsersMODEL();
            SqlConnection myconnCREATE = new SqlConnection();

            try
            {  // TODO: Add insert logic here
                myconnCREATE.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;
                myconnCREATE.Open();

                CreateNewUser.userName = collection["userName"];
                CreateNewUser.passWord = collection["passWord"];
                CreateNewUser.description = collection["description"];
                CreateNewUser.isAdmin = collection["isAdmin"];

                //INSERT INTO Contact(ID, FirstName, LastName) VALUES(1, 'serafin', 'g');
                string queryCREATE = "INSERT INTO Nutella.logins (userName,passWord,description,isAdmin) VALUES ('" +
                    CreateNewUser.userName + "','" +
                    CreateNewUser.passWord + "','" +
                    CreateNewUser.description + "','" +
                    CreateNewUser.isAdmin + "');";

                SqlCommand commCREATE = new SqlCommand(queryCREATE, myconnCREATE);
                int numRowsAffected = commCREATE.ExecuteNonQuery();
                myconnCREATE.Close();

                return RedirectToAction("Manage");
            }
            catch
            {
                return View();
            }
        }

        //  THIS ReadUsersFromDB METHOD SELECTS ALL THE FIELDS FROM logins DATABASE and 
        //  STORES THEM INTO A LIST OF USERS MODELS
        static List<TaxSystemUsersMODEL> ReadUsersFromDB()
        {
            List<TaxSystemUsersMODEL> myUsers = new List<TaxSystemUsersMODEL>();
            SqlConnection myConnSRFN = new SqlConnection();
            try
            {
                myConnSRFN.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;
                myConnSRFN.Open();

                string queryString = "SELECT loginId,userName,passWord,description,isAdmin FROM Nutella.logins;";
                SqlCommand commandSRFN = new SqlCommand(queryString, myConnSRFN);

                SqlDataReader myUsersResults = commandSRFN.ExecuteReader();
                while (myUsersResults.Read())
                {
                    TaxSystemUsersMODEL newUser = new TaxSystemUsersMODEL();
                    newUser.loginId = int.Parse(myUsersResults["loginId"].ToString());
                    newUser.userName = myUsersResults["userName"].ToString();
                    newUser.passWord = myUsersResults["passWord"].ToString();
                    newUser.description = myUsersResults["description"].ToString();
                    newUser.isAdmin = myUsersResults["isAdmin"].ToString();
                    myUsers.Add(newUser);
                }

            }
            catch (Exception ex) { }
            finally
            {
                myConnSRFN.Close();
            }
            return myUsers;
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
            SqlConnection connDeleteGet = new SqlConnection();
            //abrir aqui la conexion con la BBDD y ejecutar el delete para ese loginId id.

            List<TaxSystemUsersMODEL> aa = new List<TaxSystemUsersMODEL>();
            aa = ReadUsersFromDB();
            //return View("Manage", aa);
            return RedirectToAction("Manage");
        }

    }
}
