using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using servicios_todo_en_uno.Models;
namespace servicios_todo_en_uno.Controllers
{
    public class BancoController : ApiController
    {
     
        [HttpGet]
        public Boolean tarjetabancaria(string numerocuenta, string nombretarjeta)
        {
            string sql = "INSERT INTO tarjetabancaria(`numerocuenta`, `nombretarjeta`) VALUES (@numerocuenta, @nombretarjeta)";

            //string sql = "Insert into alumnos set id=@id, nombres=@nombres, apellidos=@apellidos";
            //sql = 
            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);

            cmd.Parameters.AddWithValue("@numerocuenta", numerocuenta);
            cmd.Parameters.AddWithValue("@nombretarjeta", nombretarjeta);
            try
            {
                cnt.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException p)
            {
                return false;
            }

        }
    }

}
