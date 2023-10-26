using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace MVC_Application01.Controllers
{
    public class UserRegistrationController : Controller
    {
        SqlConnection con = new SqlConnection("data source=NEHAASHISHARMA;initial catalog=MVC_Application_DB;integrated security=true");
        // GET: UserRegistration
        public ActionResult RegistrationForm()
        {
            return View();
        }

        public void insert_oparation(string A, string B, int C)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("user_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", A);
            cmd.Parameters.AddWithValue("@city", B);
            cmd.Parameters.AddWithValue("@age", C);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void delete_oparation(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("user_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", A);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult edit_oparation(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("user_edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", A);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public void update_oparation(string A, string B, int C, int D)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("user_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", A);
            cmd.Parameters.AddWithValue("@city", B);
            cmd.Parameters.AddWithValue("@age", C);
            cmd.Parameters.AddWithValue("@uid", D);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public JsonResult Display_oparation()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("user_show", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}