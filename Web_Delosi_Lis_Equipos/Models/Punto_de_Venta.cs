using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

using System.Drawing.Printing;

namespace Web_Delosi_Lis_Equipos.Models
{
    public class Punto_de_Venta
    {
        [Display(Name = "Mombre de la Empresa")] public string nom_empresa_ws { get; set; }
        [Display(Name = "Tienda")] public string comp_tienda_ws { get; set; }
        [Display(Name = "Número de tienda")] public string num_tienda_ws { get; set; }
        [Display(Name = "Nombre de la tienda")] public string nomb_tienda_ws { get; set; }
        [Display(Name = "IP WS")] public string ip_ws { get; set; }
        [Display(Name = "Estado de Tienda")] public string estado_tienda { get; set; }
        [Display(Name = "Modelo")] public string modelo { get; set; }
        [Display(Name = "Status WS")] public string status_ws { get; set; }
        [Display(Name = "Join Tienda")] public string join_tienda { get; set; }
    }
}