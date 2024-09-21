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
    public partial class Form1 : Form
    {
        private List<Articulo> listaArticulo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoria");


        }

        private void cargar()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulo = negocio.listar();
                dgvArticulos.DataSource = listaArticulo;
                ocultarColumnas();

                cargarImagen(listaArticulo[0].Imagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Imagen"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["posVec"].Visible = false;
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow != null)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                seleccionado.Imagenes = negocio.cargarVecImagenes(seleccionado.Id);
                if (seleccionado.Imagenes.Count > 0)
                    cargarImagen(seleccionado.Imagenes[0]);
            }
            
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

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

                Articulo selecionado;
                selecionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                frmAltaArticulo modificar = new frmAltaArticulo(selecionado); // instancio el form de modificacion/alta pero usando el constructor donde tiene como parametro un objeto Articulo
                modificar.ShowDialog();
                cargar();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("Está seguro que desea eliminar el artículo seleccionado?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.Id);
                    cargar();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            List<string> lista = new List<string>();
            lista = negocio.cargarVecImagenes(seleccionado.Id);
            int maximo = lista.Count;

            if (lista.Count > 1)
            {
                if (seleccionado.posVec < (maximo - 1))
                    seleccionado.posVec++;
                else if (seleccionado.posVec == (maximo - 1))
                    seleccionado.posVec = 0;

                cargarImagen(lista[seleccionado.posVec]);
            }

            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            List<string> lista = new List<string>();
            lista = negocio.cargarVecImagenes(seleccionado.Id);
            int maximo = lista.Count;

            if (seleccionado.posVec == 0)
                seleccionado.posVec = maximo - 1;
            else
                seleccionado.posVec--;

            cargarImagen(lista[seleccionado.posVec]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Articulo selecionado;
            selecionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            sumarImagen aux = new sumarImagen(selecionado);
            aux.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            agregarMarca aux = new agregarMarca();
            aux.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            agregarCategoria aux = new agregarCategoria();
            aux.ShowDialog();
        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txbFiltro.Text))
                {
                    MessageBox.Show("Debe cargar un valor numérico");
                    return true;
                }
                if (!(soloNumeros(txbFiltro.Text)))
                {
                    MessageBox.Show("Por favor, solo ingresar números");
                    return true;
                }
            }
                
            return false;
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txbFiltro.Text;

                if (filtro != null)
                {
                    dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
                }
                else
                {
                    dgvArticulos.DataSource = listaArticulo;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void txbFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txbFiltroRapido.Text;


            if (filtro.Length >= 3)
            {
                listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulo;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();

            if(opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }
    }
}
