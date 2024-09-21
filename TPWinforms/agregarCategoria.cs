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
    public partial class agregarCategoria : Form
    {
        public agregarCategoria()
        {
            InitializeComponent();
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            Categoria nueva = new Categoria();
            nueva.Nombre = tbCategoria.Text;
            CategoriaNegocio negocio = new CategoriaNegocio();
            negocio.agregarCategoria(nueva);
            MessageBox.Show("Categoria agregada correctamente");
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
