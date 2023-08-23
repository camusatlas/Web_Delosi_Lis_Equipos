using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web_Delosi_Lis_Equipos.Models;

namespace Web_Delosi_Lis_Equipos.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        //Logica de Login
        public ActionResult Login()
        {
            return View();
        }
        // Registrar
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuarios oUsuario)
        {
            SqlConnection an = new SqlConnection(ConfigurationManager.ConnectionStrings["Usuario"].ConnectionString);
            bool registrado;
            string mensaje;

            if (oUsuario.Clave == oUsuario.ConfirmarClave)
            {
                oUsuario.Clave = Convertirsha256(oUsuario.Clave);
            }
            else
            {
                ViewData["Mensaje"] = "La contraseña no coinciden";
                return View();
            }
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Usuario"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                cmd.Parameters.Add("Registrar", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 300).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();
                registrado = Convert.ToBoolean(cmd.Parameters["Registrar"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            ViewData["Mesnaje"] = mensaje;
            if (registrado)
            {
                return RedirectToAction("Login", "Acceso");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(Usuarios oUsuario)
        {
            oUsuario.Clave = Convertirsha256(oUsuario.Clave);
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Usuario"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                oUsuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            if (oUsuario.IdUsuario != 0)
            {
                Session["usuario"] = oUsuario;
                return RedirectToAction("IndexBuscarServidor1", "EquiposServidor");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }
        }
        public static string Convertirsha256(string texto)
        {
            //using System.text;
            //Ussar la referencia de "System.Security.Cryptography"
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
        public ActionResult CerrarSesion()
        {
            Session["usuario"] = null;
            return RedirectToAction("Login", "Usuarios");
        }
    }
    public class ValidarSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Usuarios/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}