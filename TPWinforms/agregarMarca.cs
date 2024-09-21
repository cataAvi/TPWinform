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
    public partial class agregarMarca : Form
    {
        public agregarMarca()
        {
            InitializeComponent();
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            Marca nueva = new Marca();
            nueva.Nombre = tbMarca.Text;
            MarcaNegocio negocio = new MarcaNegocio();
            negocio.agregarMarca(nueva);
            MessageBox.Show("Marca agregada correctamente");
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
