using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinforms
{
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.listar();
            dgvArticulos.DataSource = listaArticulo;
            dgvArticulos.Columns["Imagen"].Visible = false;
            cargarImagen(listaArticulo[0].Imagen);

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.Imagen);
        }

        private void cargarImagen(string imagen)
        {
            
            try
            {
               pbxArticulo.Load(imagen);
            }
            catch(Exception ex)
            {
                pbxArticulo.Load("https://designshack.net/wp-content/uploads/placeholder-image.png");
            }
        }
    }
}
