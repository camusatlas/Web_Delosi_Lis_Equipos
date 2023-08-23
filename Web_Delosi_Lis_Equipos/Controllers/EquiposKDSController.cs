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
    public class EquiposKDSController : Controller
    {
        // GET: EquiposKDS
        // Listado de KDS
        IEnumerable<Equipos_KDS> kds()
        {
            List<Equipos_KDS> lista = new List<Equipos_KDS>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("List_KDS", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Equipos_KDS
                {
                    nom_empresa_kds = dr.GetString(0),
                    comp_tienda_kds = dr.GetString(1),
                    num_tienda_kds = dr.GetString(2),
                    nomb_tienda_kds = dr.GetString(3),
                    ip_kds = dr.GetString(4),
                    hostname = dr.GetString(5),
                    estado_tienda = dr.GetString(6),
                    modelo = dr.GetString(7),
                    status_kds = dr.GetString(8),
                    join_tienda = dr.GetString(9),
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        // Buqueda de KDS
        IEnumerable<Equipos_KDS> buscarKDS(string nombre)
        {
            List<Equipos_KDS> lista = new List<Equipos_KDS>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("BuscKDS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Join_tienda", nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Equipos_KDS
                {
                    nom_empresa_kds = dr.GetString(0),
                    comp_tienda_kds = dr.GetString(1),
                    num_tienda_kds = dr.GetString(2),
                    nomb_tienda_kds = dr.GetString(3),
                    ip_kds = dr.GetString(4),
                    hostname = dr.GetString(5),
                    estado_tienda = dr.GetString(6),
                    modelo = dr.GetString(7),
                    status_kds = dr.GetString(8),
                    join_tienda = dr.GetString(9)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        public ActionResult IndexBuscarKDS(string nombre)
        {
            if (nombre == null) nombre = string.Empty;
            return View(buscarKDS(nombre));
        }
        //Agregar KDS Nuevos
        string AgregarKDS(Equipos_KDS reg)
        {
            string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Ing_KDS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Empresa", reg.nom_empresa_kds);
                cmd.Parameters.AddWithValue("@Comp_tienda", reg.comp_tienda_kds);
                cmd.Parameters.AddWithValue("@Num_Tienda", reg.num_tienda_kds);
                cmd.Parameters.AddWithValue("@Nomb_Teinda", reg.nomb_tienda_kds);
                cmd.Parameters.AddWithValue("@IP_WS", reg.ip_kds);
                cmd.Parameters.AddWithValue("@HostName", reg.hostname);
                cmd.Parameters.AddWithValue("@Estado_Tienda", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Modelo", reg.modelo);
                cmd.Parameters.AddWithValue("@Status_WS", reg.status_kds);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.join_tienda);

                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se creo {i} Nuevo Kds...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }
        public ActionResult CreateKDS()
        {
            ViewBag.servidors = new SelectList(kds(), "nom_empresa_kds", "comp_tienda_kds");
            return View(new Equipos_KDS());
        }
        [HttpPost]
        public ActionResult CreateKDS(Equipos_KDS reg)
        {
            ViewBag.mensaje = AgregarKDS(reg);
            return View(new Equipos_KDS());
        }
        // Actualizar KDS
        string ActualizarKDS(Equipos_KDS reg)
        {
            string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Upd_KDS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Empresa", reg.nom_empresa_kds);
                cmd.Parameters.AddWithValue("@Comp_tienda", reg.comp_tienda_kds);
                cmd.Parameters.AddWithValue("@Num_Tienda", reg.num_tienda_kds);
                cmd.Parameters.AddWithValue("@Nomb_Teinda", reg.nomb_tienda_kds);
                cmd.Parameters.AddWithValue("@IP_KDS", reg.ip_kds);
                cmd.Parameters.AddWithValue("@HostName", reg.hostname);
                cmd.Parameters.AddWithValue("@Modelo", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Status_WS", reg.modelo);
                cmd.Parameters.AddWithValue("@Status_WS", reg.status_kds);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.join_tienda);
                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se actualizó {i} KDS...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }
        public ActionResult EditKDS(string id)
        {
            if (string.IsNullOrEmpty(id)) { id = string.Empty; }
            Equipos_KDS reg = kds().FirstOrDefault(x => x.join_tienda == id);
            ViewBag.punto_De_Venta = new SelectList(kds(), "nom_empresa_kds", "comp_tienda_kds");
            return View(reg);
        }
        [HttpPost]
        public ActionResult EditKDS(Equipos_KDS reg)
        {
            ViewBag.mensaje = ActualizarKDS(reg);
            return View(new Equipos_KDS());
        }
    }
}