using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using servicios_todo_en_uno.Models;
namespace servicios_todo_en_uno.Controllers
{
    public class detallecompraController : ApiController
    {
        [HttpGet]
        public detallesresultadomodels datos(string usuario)
        {
            string sql = "SELECT nombres,apellidos,correo," +
                "nombreproducto,precio,numerocuenta,nombretarjeta\r\nFROM registros " +
                "INNER JOIN productos ON registros.idregistros = productos.idproductos\r\n" +
                "INNER JOIN tarjetabancaria ON tarjetabancaria.idtarjetabancaria = productos.idproductos WHERE correo = @correo";

            //string sql = "Insert into alumnos set id=@id, nombres=@nombres, apellidos=@apellidos";
            //sql = 
            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);
            cmd.Parameters.AddWithValue("@correo", usuario);
            try
            {
                cnt.Open();

                MySqlDataReader cursor = cmd.ExecuteReader();
                detallesresultadomodels login = new detallesresultadomodels();
                while (cursor.Read())
                {
                    login.nombres = cursor.GetString(0);
                    login.apellidos = cursor.GetString(1);
                    login.correo = cursor.GetString(2);
                    login.nombreproducto= cursor.GetString(3);
                    login.precio = cursor.GetInt32(4);
                    login.numerocuenta = cursor.GetString(5);
                    login.nombretarjeta = cursor.GetString(6);


                }
                cursor.Close();
                cnt.Close();
                return login;
            }
            catch (MySqlException p)
            {
                return null;
            }

        }
    }

    }

