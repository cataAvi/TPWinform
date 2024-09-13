using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TPWinforms
{
    class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {

                conexion.ConnectionString = "server=DESKTOP-758I0CH\\ZOOLOGIC; database=CATALOGO_P3_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, A.IdMarca, C.Descripcion as Categoria, A.IdCategoria, A.Precio, I.ImagenUrl from ARTICULOS A, IMAGENES I, MARCAS M, CATEGORIAS C where A.Id = I.IdArticulo and A.IdMarca = M.Id and A.IdCategoria = C.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    //aux.Marca = (int)lector["IdMarca"];
                    aux.Precio = (decimal)lector["Precio"];
                    aux.Imagen = (string)lector["ImagenUrl"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Codigo = (int)lector["IdCategoria"];
                    aux.Categoria.Nombre = (string)lector["Categoria"];
                    aux.Marca = new Marca();
                    aux.Marca.Codigo = (int)lector["IdMarca"];
                    aux.Marca.Nombre = (string)lector["Marca"];


                    lista.Add(aux);

                }

                conexion.Close();
                return lista; 
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
