using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaApis.Models
{
    public class Productos
    {

        public int id_producto              { get; set; }
        public int id_marca                 { get; set; }

        public string Marca                 { get; set; }

        public int id_presentacion          { get; set; }

        public string Presentacion          { get; set; }

        public int id_proveedor             { get; set; }

        public string Proveedor             { get; set; }

        public int id_zona                  { get; set; }

        public string Zona                  { get; set; }

        public int codigo                   { get; set; }

        public string descripcion_producto  { get; set; }

        public double precio                { get; set; }

        public int stock                    { get; set; }

        public int IMPUESTO                 { get; set; }

        public double peso                  { get; set; }

    }
}