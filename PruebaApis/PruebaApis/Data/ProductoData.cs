using PruebaApis.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PruebaApis.Data
{
    public class ProductoData
    {

        // LISTAR PRODUCTO
        public static List<Productos> ListarProductos ( int bandera )
        {
            List<Productos> oListaProductos = new List<Productos>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SP_ListarProducto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bandera", bandera);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                          
                            oListaProductos.Add(new Productos()
                            {

                                id_producto          =  Convert.ToInt32(dr["id_producto"]),
                                id_marca             =  Convert.ToInt32(dr["id_marca"]),
                                Marca                =  dr["Marca"].ToString(),
                                id_presentacion      =  Convert.ToInt32(dr["id_presentacion"]),
                                Presentacion         = dr["Presentacion"].ToString(),
                                id_proveedor         = Convert.ToInt32(dr["id_proveedor"]),
                                Proveedor            = dr["Proveedor"].ToString(),
                                id_zona              = Convert.ToInt32(dr["id_zona"]),
                                Zona                 = dr["Zona"].ToString(),
                                codigo               = Convert.ToInt32(dr["codigo"]),
                                descripcion_producto = dr["descripcion_producto"].ToString(),
                                precio               = Convert.ToDouble(dr["precio"]),
                                stock                = Convert.ToInt32(dr["stock"]),
                                IMPUESTO             = Convert.ToInt32(dr["IMPUESTO"]),
                                peso                 = Convert.ToDouble(dr["peso"]),
                            });
                        }

                    }



                    return oListaProductos;
                }
                catch (Exception ex)
                {
                    return oListaProductos;
                }
            }
        }

        // Ingresar Producto
        public static object IngresarProducto(Productos oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SP_InsProducto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_marca",                    oProducto.id_marca);
                cmd.Parameters.AddWithValue("@id_presentacion",             oProducto.id_presentacion);
                cmd.Parameters.AddWithValue("@id_proveedor",                oProducto.id_proveedor);
                cmd.Parameters.AddWithValue("@id_zona",                     oProducto.id_zona);
                cmd.Parameters.AddWithValue("@codigo",                      oProducto.codigo);
                cmd.Parameters.AddWithValue("@descripcion_producto",        oProducto.descripcion_producto);
                cmd.Parameters.AddWithValue("@precio",                      oProducto.precio);
                cmd.Parameters.AddWithValue("@stock",                       oProducto.stock);
                cmd.Parameters.AddWithValue("@impuesto",                    oProducto.IMPUESTO);
                cmd.Parameters.AddWithValue("@peso",                        oProducto.peso);

                try
                {
                     oConexion.Open();
                     cmd.ExecuteNonQuery();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                    return (true, "Ingresado Correctamente");
                    }
                    else { return (false , "Error"); }
                }
                catch (Exception ex)
                {
                    return (false, "Error");
                }
            }
        }


        // ACTUALIZAR PRODUCTO
        public static object ActualizarProducto(Productos oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdProducto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", oProducto.id_producto);
                cmd.Parameters.AddWithValue("@id_marca", oProducto.id_marca);
                cmd.Parameters.AddWithValue("@id_presentacion", oProducto.id_presentacion);
                cmd.Parameters.AddWithValue("@id_proveedor", oProducto.id_proveedor);
                cmd.Parameters.AddWithValue("@id_zona", oProducto.id_zona);
                cmd.Parameters.AddWithValue("@codigo", oProducto.codigo);
                cmd.Parameters.AddWithValue("@descripcion_producto", oProducto.descripcion_producto);
                cmd.Parameters.AddWithValue("@precio", oProducto.precio);
                cmd.Parameters.AddWithValue("@stock", oProducto.stock);
                cmd.Parameters.AddWithValue("@impuesto", oProducto.IMPUESTO);
                cmd.Parameters.AddWithValue("@peso", oProducto.peso);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return (true, "Actualizado Correctamente");
                    }
                    else { return (false, "Error"); }
                }
                catch (Exception ex)
                {
                    return (false, "Error");
                }
            }
        }

        // ELiminar Producto

        public static bool EliminarProducto(Productos oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("Sp_DelProducto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", oProducto.id_producto);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}