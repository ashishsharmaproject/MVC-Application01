using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using MVC_Application01.Models;
using System.Web.UI.WebControls;

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

        public void insert_oparation(UserRegistrationModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("user_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.Parameters.AddWithValue("@age", obj.Age);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void delete_oparation(UserRegistrationModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("user_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.UID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult edit_oparation(UserRegistrationModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("user_edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.UID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public void update_oparation(UserRegistrationModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("user_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.Parameters.AddWithValue("@age", obj.Age);
            cmd.Parameters.AddWithValue("@uid", obj.UID);
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
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}