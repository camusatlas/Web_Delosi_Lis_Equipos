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
    public class EquiposServidorController : Controller
    {
        // GET: EquiposServidor
        //Listado de Servidores en General para agregar Servidores
        IEnumerable<Servidores> servidor()
        {
            List<Servidores> lista = new List<Servidores>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("List_Servidores", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Servidores
                {
                    nom_emp = dr.GetString(0),
                    comp_tienda_servidor = dr.GetString(1),
                    num = dr.GetString(2),
                    departamento = dr.GetString(3),
                    provincia = dr.GetString(4),
                    distrito = dr.GetString(5),
                    region = dr.GetString(6),
                    servidor_ip = dr.GetString(7),
                    hostname = dr.GetString(8),
                    tamaño_bd = dr.GetString(9),
                    estado_tienda = dr.GetString(10),
                    vers_micros = dr.GetString(11),
                    s_o = dr.GetString(12),
                    ram = dr.GetString(13),
                    model_equipo = dr.GetString(14),
                    serial_equipo = dr.GetString(15),
                    nom_tienda = dr.GetString(16),
                    tecnico_asigando = dr.GetString(17),
                    fecha_instalacion = dr.GetString(18),
                    observaciones = dr.GetString(19),
                    NomTiendaDWH = dr.GetString(20),
                    Email = dr.GetString(21),
                    telefono_tienda = dr.GetString(22),
                    direccion_tienda = dr.GetString(23),
                    Latitud = dr.GetString(24),
                    Longitud = dr.GetString(25),
                    Categoria = dr.GetString(26),
                    join_tienda = dr.GetString(27)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        //Listado Clasico de los Servidores
        IEnumerable<Servidores> servidores1()
        {
            List<Servidores> list = new List<Servidores>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("List_clasic_Servidores", cn); //Fatala agregar el Query
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Servidores
                {
                    join_tienda = dr.GetString(0),
                    nom_tienda = dr.GetString(1),
                    servidor_ip = dr.GetString(2),
                    hostname = dr.GetString(3),
                    distrito = dr.GetString(4)
                });
            }
            dr.Close();
            cn.Close();
            return list;
        }
        // Busqueda de List_clasic_Servidores
        IEnumerable<Servidores> BuscarcarServidores1(string nombre)
        {
            List<Servidores> lista = new List<Servidores>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("Busc_List_clasic_Servidores", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Join_Tienda", nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Servidores
                {
                    join_tienda = dr.GetString(0),
                    nom_tienda = dr.GetString(1),
                    servidor_ip = dr.GetString(2),
                    hostname = dr.GetString(3),
                    distrito = dr.GetString(4)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        public ActionResult IndexBuscarServidor1(string nombre)
        {
            if (nombre == null) nombre = string.Empty;
            return View(BuscarcarServidores1(nombre));
        }
        // Listado Datos importantes
        IEnumerable<Servidores> servidores2()
        {
            List<Servidores> list = new List<Servidores>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("List_Date_Servidores", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Servidores
                {
                    vers_micros = dr.GetString(0),
                    s_o = dr.GetString(1),
                    ram = dr.GetString(2),
                    model_equipo = dr.GetString(3),
                    serial_equipo = dr.GetString(4),
                    tamaño_bd = dr.GetString(5)
                });
            }
            dr.Close();
            cn.Close();
            return list;
        }
        // Busqueda de List_Information_Servidores
        IEnumerable<Servidores> BuscarcarServidores2(string nombre)
        {
            List<Servidores> lista = new List<Servidores>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("Busc_List_Date_Servidores", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Join_Tienda", nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Servidores
                {
                    vers_micros = dr.GetString(0),
                    s_o = dr.GetString(1),
                    ram = dr.GetString(2),
                    model_equipo = dr.GetString(3),
                    serial_equipo = dr.GetString(4),
                    tamaño_bd = dr.GetString(5)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        public ActionResult IndexBuscarServidor2(string nombre)
        {
            if (nombre == null) nombre = string.Empty;
            return View(BuscarcarServidores2(nombre));
        }
        //Listado Info de la tienda
        IEnumerable<Servidores> servidores3()
        {
            List<Servidores> list = new List<Servidores>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("List_Information_Servidores", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Servidores
                {
                    Email = dr.GetString(0),
                    telefono_tienda = dr.GetString(1),
                    direccion_tienda = dr.GetString(2),
                    Categoria = dr.GetString(3)
                });
            }
            dr.Close();
            cn.Close();
            return list;
        }
        // Busqueda de List_Information_Servidores
        IEnumerable<Servidores> BuscarcarServidores3(string nombre)
        {
            List<Servidores> lista = new List<Servidores>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("Busc_List_Information_Servidores", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Join_Tienda", nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Servidores
                {
                    Email = dr.GetString(0),
                    telefono_tienda = dr.GetString(1),
                    direccion_tienda = dr.GetString(2),
                    Categoria = dr.GetString(3)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        public ActionResult IndexBuscarServidor3(string nombre)
        {
            if (nombre == null) nombre = string.Empty;
            return View(BuscarcarServidores3(nombre));
        }
        // Listado de asistencia Tecnica
        IEnumerable<Servidores> servidores4()
        {
            List<Servidores> list = new List<Servidores>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand("List_Tecnic_Servidores", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new Servidores
                {
                    nom_tienda = dr.GetString(0),
                    tecnico_asigando = dr.GetString(1),
                    fecha_instalacion = dr.GetString(2),
                    observaciones = dr.GetString(3)
                });
            }
            dr.Close();
            cn.Close();
            return list;
        }
        // Busqueda de List_Tecnic_Servidores
        IEnumerable<Servidores> BuscarcarServidores4(string nombre)
        {
            List<Servidores> lista = new List<Servidores>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand("Busc_List_Tecnic_Servidores", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Join_Tienda", nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Servidores
                {
                    nom_tienda = dr.GetString(0),
                    tecnico_asigando = dr.GetString(1),
                    fecha_instalacion = dr.GetString(2),
                    observaciones = dr.GetString(3)
                });
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        public ActionResult IndexBuscarServidor4(string nombre)
        {
            if (nombre == null) nombre = string.Empty;
            return View(BuscarcarServidores4(nombre));
        }
        // Agregar Servidor Nuevo
        string AgregarServidor(Servidores reg)
        {
            string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Ing_Servidores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Emp", reg.nom_emp);
                cmd.Parameters.AddWithValue("@Comp_Tienda", reg.comp_tienda_servidor);
                cmd.Parameters.AddWithValue("@Num", reg.num);
                cmd.Parameters.AddWithValue("@Departamento", reg.departamento);
                cmd.Parameters.AddWithValue("@Provincia", reg.provincia);
                cmd.Parameters.AddWithValue("@Distrito", reg.distrito);
                cmd.Parameters.AddWithValue("@Region", reg.region);
                cmd.Parameters.AddWithValue("@Servidor_IP", reg.servidor_ip);
                cmd.Parameters.AddWithValue("@HostName", reg.hostname);
                cmd.Parameters.AddWithValue("@Estado_Tienda", reg.tamaño_bd);
                cmd.Parameters.AddWithValue("@Vers_Micros", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Tamaño_BD", reg.vers_micros);
                cmd.Parameters.AddWithValue("@S_O", reg.s_o);
                cmd.Parameters.AddWithValue("@Ram", reg.ram);
                cmd.Parameters.AddWithValue("@Model_Equipo", reg.model_equipo);
                cmd.Parameters.AddWithValue("@Serial_Equipo", reg.serial_equipo);
                cmd.Parameters.AddWithValue("@Nom_Tienda", reg.nom_tienda);
                cmd.Parameters.AddWithValue("@Tecnico_Asigando", reg.tecnico_asigando);
                cmd.Parameters.AddWithValue("@Fecha_Instalacion", reg.fecha_instalacion);
                cmd.Parameters.AddWithValue("@Observaciones", reg.observaciones);
                cmd.Parameters.AddWithValue("@Nom_Tienda_DWH", reg.NomTiendaDWH);
                cmd.Parameters.AddWithValue("@Email", reg.Email);
                cmd.Parameters.AddWithValue("@Telefono_Tienda", reg.telefono_tienda);
                cmd.Parameters.AddWithValue("@Direccion_Tienda", reg.direccion_tienda);
                cmd.Parameters.AddWithValue("@Latitud", reg.Latitud);
                cmd.Parameters.AddWithValue("@Longitud", reg.Longitud);
                cmd.Parameters.AddWithValue("@Categoria", reg.Categoria);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.join_tienda);
                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se creo {i} Nuevo Servidor...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }
        public ActionResult CreateServidor()
        {
            ViewBag.servidors = new SelectList(servidor(), "nom_emp", "comp_tienda_servidor");
            return View(new Servidores());
        }
        [HttpPost]
        public ActionResult CreateServidor(Servidores reg)
        {
            ViewBag.mensaje = AgregarServidor(reg);
            return View(new Servidores());
        }
        // Actualizar Servidores
        string ActualizarServidor(Servidores reg)
        {
            string mensaje = string.Empty;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Delosi"].ConnectionString);
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Upd_Servidores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom_Emp", reg.nom_emp);
                cmd.Parameters.AddWithValue("@Comp_Tienda", reg.comp_tienda_servidor);
                cmd.Parameters.AddWithValue("@Num", reg.num);
                cmd.Parameters.AddWithValue("@Departamento", reg.departamento);
                cmd.Parameters.AddWithValue("@Provincia", reg.provincia);
                cmd.Parameters.AddWithValue("@Distrito", reg.distrito);
                cmd.Parameters.AddWithValue("@Region", reg.region);
                cmd.Parameters.AddWithValue("@Servidor_IP", reg.servidor_ip);
                cmd.Parameters.AddWithValue("@HostName", reg.hostname);
                cmd.Parameters.AddWithValue("@Estado_Tienda", reg.tamaño_bd);
                cmd.Parameters.AddWithValue("@Vers_Micros", reg.estado_tienda);
                cmd.Parameters.AddWithValue("@Tamaño_BD", reg.vers_micros);
                cmd.Parameters.AddWithValue("@S_O", reg.s_o);
                cmd.Parameters.AddWithValue("@Ram", reg.ram);
                cmd.Parameters.AddWithValue("@Model_Equipo", reg.model_equipo);
                cmd.Parameters.AddWithValue("@Serial_Equipo", reg.serial_equipo);
                cmd.Parameters.AddWithValue("@Nom_Tienda", reg.nom_tienda);
                cmd.Parameters.AddWithValue("@Tecnico_Asigando", reg.tecnico_asigando);
                cmd.Parameters.AddWithValue("@Fecha_Instalacion", reg.fecha_instalacion);
                cmd.Parameters.AddWithValue("@Observaciones", reg.observaciones);
                cmd.Parameters.AddWithValue("@Nom_Tienda_DWH", reg.NomTiendaDWH);
                cmd.Parameters.AddWithValue("@Email", reg.Email);
                cmd.Parameters.AddWithValue("@Telefono_Tienda", reg.telefono_tienda);
                cmd.Parameters.AddWithValue("@Direccion_Tienda", reg.direccion_tienda);
                cmd.Parameters.AddWithValue("@Latitud", reg.Latitud);
                cmd.Parameters.AddWithValue("@Longitud", reg.Longitud);
                cmd.Parameters.AddWithValue("@Categoria", reg.Categoria);
                cmd.Parameters.AddWithValue("@Join_Tienda", reg.join_tienda);
                int i = cmd.ExecuteNonQuery();
                mensaje = $"Se actualizó {i} Servidor...";
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;
            }
            finally { cn.Close(); }
            return mensaje;
        }
        // Editar Servidor
        public ActionResult EditServidor(string id)
        {
            if (string.IsNullOrEmpty(id)) { id = string.Empty; }
            Servidores reg = servidor().FirstOrDefault(x => x.nom_tienda == id);
            ViewBag.servidor = new SelectList(servidor(), "nom_emp", "comp_tienda_servidor");
            return View(new Servidores());
        }
        [HttpPost]
        public ActionResult Edit(Servidores reg)
        {
            ViewBag.mensaje = ActualizarServidor(reg);
            return View(new Servidores());
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}