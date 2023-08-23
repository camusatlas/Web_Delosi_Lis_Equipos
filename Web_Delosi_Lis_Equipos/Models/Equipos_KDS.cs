using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

using System.Drawing.Printing;

namespace Web_Delosi_Lis_Equipos.Models
{
    public class Equipos_KDS
    {
        [Display(Name = "Nombre de la Empresa")] public string nom_empresa_kds { get; set; }
        [Display(Name = "Tienda")] public string comp_tienda_kds { get; set; }
        [Display(Name = "Número de Tienda")] public string num_tienda_kds { get; set; }
        [Display(Name = "Nombre de Tienda")] public string nomb_tienda_kds { get; set; }
        [Display(Name = "IP KDS")] public string ip_kds { get; set; }
        [Display(Name = "HostName")] public string hostname { get; set; }
        [Display(Name = "Estado de Tienda")] public string estado_tienda { get; set; }
        [Display(Name = "Modelo")] public string modelo { get; set; }
        [Display(Name = "Status WS")] public string status_kds { get; set; }
        [Display(Name = "Join Tienda")] public string join_tienda { get; set; }
    }
}