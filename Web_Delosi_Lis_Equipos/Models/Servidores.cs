using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

using System.Drawing.Printing;

namespace Web_Delosi_Lis_Equipos.Models
{
    public class Servidores
    {
        [Display(Name = "Nombre de la Empresa")] public string nom_emp { get; set; }
        [Display(Name = "Tienda")] public string comp_tienda_servidor { get; set; }
        [Display(Name = "Número")] public string num { get; set; }
        [Display(Name = "Departamento")] public string departamento { get; set; }
        [Display(Name = "Provincia")] public string provincia { get; set; }
        [Display(Name = "Distrito")] public string distrito { get; set; }
        [Display(Name = "Región")] public string region { get; set; }
        [Display(Name = "Servidor IP")] public string servidor_ip { get; set; }
        [Display(Name = "HostName")] public string hostname { get; set; }
        [Display(Name = "Tamaño BD")] public string tamaño_bd { get; set; }
        [Display(Name = "Estado Tienda")] public string estado_tienda { get; set; }
        [Display(Name = "Versión Micros")] public string vers_micros { get; set; }
        [Display(Name = "Sitema Operativo")] public string s_o { get; set; }
        [Display(Name = "Ram")] public string ram { get; set; }
        [Display(Name = "Modelo del Equipo")] public string model_equipo { get; set; }
        [Display(Name = "Serial del Equipo")] public string serial_equipo { get; set; }
        [Display(Name = "Nombre de Tienda")] public string nom_tienda { get; set; }
        [Display(Name = "Tecnico Asigando")] public string tecnico_asigando { get; set; }
        [Display(Name = "Fecha de Instalacion")] public string fecha_instalacion { get; set; }
        [Display(Name = "Observaciones")] public string observaciones { get; set; }
        [Display(Name = "Nombre de Tienda DWH")] public string NomTiendaDWH { get; set; }
        [Display(Name = "Email")] public string Email { get; set; }
        [Display(Name = "Telefono Tienda")] public string telefono_tienda { get; set; }
        [Display(Name = "Direccion de Tienda")] public string direccion_tienda { get; set; }
        [Display(Name = "Latitud")] public string Latitud { get; set; }
        [Display(Name = "Longitud")] public string Longitud { get; set; }
        [Display(Name = "Categoria")] public string Categoria { get; set; }
        [Display(Name = "Join Tienda")] public string join_tienda { get; set; }
    }
}