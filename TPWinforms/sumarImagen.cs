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
    public partial class sumarImagen : Form
    {
        Articulo seleccionado = new Articulo();

        public sumarImagen(Articulo aux)
        {
            seleccionado = aux;
            InitializeComponent();
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            //Articulo aux = new Articulo();

            seleccionado.Imagen = tbURLImag.Text;
            negocio.agregarImagen(negocio.leerDatos(seleccionado));
            MessageBox.Show("Imagen agregada exitosamente");
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
