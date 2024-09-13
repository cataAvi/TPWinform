using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {

            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, A.IdMarca, C.Descripcion as Categoria, A.IdCategoria, A.Precio, I.ImagenUrl from ARTICULOS A, IMAGENES I, MARCAS M, CATEGORIAS C where A.Id = I.IdArticulo and A.IdMarca = M.Id and A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    //aux.Marca = (int)lector["IdMarca"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Codigo = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["Categoria"];
                    aux.Marca = new Marca();
                    aux.Marca.Codigo = (int)datos.Lector["IdMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["Marca"];

                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}
