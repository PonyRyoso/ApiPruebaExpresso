using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PruebaApis.Models.WS;
using PruebaApis.Models;
using PruebaApis.Data;

namespace PruebaApis.Controllers.CRUD
{
    public class AccessController : ApiController
    {
    

    [HttpGet]
        public List<Productos> VerProductos(int bandera)
        {   
            return ProductoData.ListarProductos(bandera);
        }

    [HttpPost]
        public object IngresarProductos([FromBody] Productos oProducto)
        {
           return ProductoData.IngresarProducto(oProducto);

        }

    [HttpPost]
        public object ActualizarProductos([FromBody] Productos oProducto)
        {
            return ProductoData.ActualizarProducto(oProducto);

        }

    [HttpDelete]
        public bool EliminarProducto([FromBody] Productos oProducto)
        {
            return ProductoData.EliminarProducto(oProducto);

        }
    }
}
