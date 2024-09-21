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
            try
            {
                if(tbCategoria.Text == "")
                {
                    MessageBox.Show("Por favor, completar con los datos necesarios");
                }
                else
                {
                    Categoria nueva = new Categoria();
                    nueva.Nombre = tbCategoria.Text;
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    negocio.agregarCategoria(nueva);
                    MessageBox.Show("Categoria agregada correctamente");
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
