using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Delosi_Lis_Equipos.Models;

namespace Web_Delosi_Lis_Equipos.Controllers
{
    public class Punto_VentaController : Controller
    {
        // GET: Punto_Venta
        // Listado de Punto de Venta
        IEnumerable<Punto_de_Venta> punto_De_Ventas()
        {
            List<Punto_de_Venta> lista = new List<Punto_de_Venta>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("List_Punto_Venta", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Punto_de_Venta
                {
                    nom_empresa_ws = dr.GetString(0),
                    comp_tienda_ws = dr.GetString(1),
                    num_tienda_ws = dr.GetString(2),
                    nomb_tienda_ws = dr.GetString(3),
                    ip_ws = dr.GetString(4),
                    estado_tienda = dr.GetString(5),
                    modelo = dr.GetString(6),
                    status_ws = dr.GetString(7),
                    join_tienda = dr.GetString(8),
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        // Busqueda de Punto de Venta
        IEnumerable<Punto_de_Venta> buscarPuntoVenta(string nombre)
        {
            List<Punto_de_Venta> lista = new List<Punto_de_Venta>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("BuscPuntoVenta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Join_tienda", nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Punto_de_Venta
                {
                    nom_empresa_ws = dr.GetString(0),
                    comp_tienda_ws = dr.GetString(1),
                    num_tienda_ws = dr.GetString(2),
                    nomb_tienda_ws = dr.GetString(3),
                    ip_ws = dr.GetString(4),
                    estado_tienda = dr.GetString(5),
                    modelo = dr.GetString(6),
                    status_ws = dr.GetString(7),
                    join_tienda = dr.GetString(8)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        public ActionResult IndexBuscarPuntoVenta(string nombre)
        {
            if (nombre == null) nombre = string.Empty;
            return View(buscarPuntoVenta(nombre));
        }
        // Agregar Punto de Venta
        string AgregarPuntoVenta(Punto_de_Venta reg)
        {
            string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Ing_Punto_Ventas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Empresa", reg.nom_empresa_ws);
                cmd.Parameters.AddWithValue("@Comp_tienda", reg.comp_tienda_ws);
                cmd.Parameters.AddWithValue("@Num_Tienda", reg.num_tienda_ws);
                cmd.Parameters.AddWithValue("@Nomb_Teinda", reg.nomb_tienda_ws);
                cmd.Parameters.AddWithValue("@IP_WS", reg.ip_ws);
                cmd.Parameters.AddWithValue("@Estado_Tienda", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Modelo", reg.modelo);
                cmd.Parameters.AddWithValue("@Status_WS", reg.status_ws);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.join_tienda);
                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se creo {i} Nuevo Punto de Venta...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }
        public ActionResult CreatePuntoVenta()
        {
            ViewBag.servidors = new SelectList(punto_De_Ventas(), "nom_empresa_ws", "comp_tienda_ws");
            return View(new Punto_de_Venta());
        }
        [HttpPost]
        public ActionResult CreatePuntoVenta(Punto_de_Venta reg)
        {
            ViewBag.mensaje = AgregarPuntoVenta(reg);
            return View(new Punto_de_Venta());
        }
        // Actualizar Punto de Venta
        string ActualizarPuntoVenta(Punto_de_Venta reg)
        {
            string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Upd_Punto_Venta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Empresa", reg.nom_empresa_ws);
                cmd.Parameters.AddWithValue("@Comp_tienda", reg.comp_tienda_ws);
                cmd.Parameters.AddWithValue("@Num_Tienda", reg.num_tienda_ws);
                cmd.Parameters.AddWithValue("@Nomb_Teinda", reg.nomb_tienda_ws);
                cmd.Parameters.AddWithValue("@IP_WS", reg.ip_ws);
                cmd.Parameters.AddWithValue("@Estado_Tienda", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Modelo", reg.modelo);
                cmd.Parameters.AddWithValue("@Status_WS", reg.status_ws);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.join_tienda);
                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se actualizó {i} Punto de Venta...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }
        public ActionResult EditPuntoVenta(string id)
        {
            if (string.IsNullOrEmpty(id)) { id = string.Empty; }
            Punto_de_Venta reg = punto_De_Ventas().FirstOrDefault(x => x.join_tienda == id);
            ViewBag.punto_De_Venta = new SelectList(punto_De_Ventas(), "nom_empresa_ws", "comp_tienda_ws");
            return View(reg);
        }
        [HttpPost]
        public ActionResult EditPuntoVenta(Punto_de_Venta reg)
        {
            ViewBag.mensaje = ActualizarPuntoVenta(reg);
            return View(new Punto_de_Venta());
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}