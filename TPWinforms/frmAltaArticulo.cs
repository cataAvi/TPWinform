using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace TPWinforms
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articuloAux = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
            Text = "Agregar Articulo";
        }

        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            articuloAux = articulo;
            Text = "Modificar Articulo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool soloNumeros(string cadena)
        {
            foreach(char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }

            return true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            string error = "";

            try
            {
                if (articuloAux == null)
                {
                    articuloAux = new Articulo();
                }

                if (txbCodigo.Text == "")
                {
                    error = error + "Debe cargar el campo código. ";
                }
                if (txbNombre.Text == "")
                {
                    error = error + "Debe cargar el campo nombre. ";
                }
                if (txbPrecio.Text == "")
                {
                    error = error + "Debe cargar el campo precio. ";
                }
                if (!(soloNumeros(txbPrecio.Text)))
                {
                    error = error + "Solo cargar números en el campo precio. ";
                }

                if (error == "")
                {
                    articuloAux.Codigo = txbCodigo.Text;
                    articuloAux.Nombre = txbNombre.Text;
                    articuloAux.Descripcion = txbDescripcion.Text;
                    articuloAux.Imagen = txbUrlImagen.Text;
                    articuloAux.Marca = (Marca)cboMarca.SelectedItem;
                    articuloAux.Categoria = (Categoria)cboCategoria.SelectedItem;
                    articuloAux.Precio = decimal.Parse(txbPrecio.Text);

                    if (articuloAux.Id != 0)
                    {
                        negocio.modificar(articuloAux);
                        MessageBox.Show("Articulo modificado en el inventario");
                    }
                    else
                    {

                        negocio.agregar(articuloAux);
                        negocio.agregarImagen(negocio.leerDatos(articuloAux));
                        MessageBox.Show("Articulo agregado en el inventario");


                    }

                    Close();
                }
                else
                {
                    MessageBox.Show(error);
                }
                


                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                // agregar los valores predeterminados para los campos de Marca y Negocio
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Codigo";
                cboMarca.DisplayMember = "Nombre";
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Codigo";
                cboCategoria.DisplayMember = "Nombre";


                // Bansandonos en la misma logica... si seleccionamos un articulo en el form principal e ingresamos
                // a este form mediante el boton modificar necesito mostrar los datos a modificar
                if (articuloAux != null)
                {
                    txbCodigo.Text = articuloAux.Codigo;
                    txbNombre.Text = articuloAux.Nombre;
                    txbDescripcion.Text = articuloAux.Descripcion;
                    txbUrlImagen.Text = articuloAux.Imagen;
                    cargarImagen(articuloAux.Imagen);
                    cboMarca.SelectedValue = articuloAux.Marca.Codigo;
                    cboCategoria.SelectedValue = articuloAux.Categoria.Codigo;
                    txbPrecio.Text = articuloAux.Precio.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txbUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txbUrlImagen.Text);
        }

        private void cargarImagen(string imagen)
        {

            try
            {
                pcbUrlImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                pcbUrlImagen.Load("https://designshack.net/wp-content/uploads/placeholder-image.png");
            }
        }

    }
}
