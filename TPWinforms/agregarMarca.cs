﻿using System;
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
            try
            {
                if(tbMarca.Text == "")
                {
                    MessageBox.Show("Por favor ingresar los datos requeridos");
                }
                else
                {
                    Marca nueva = new Marca();
                    nueva.Nombre = tbMarca.Text;
                    MarcaNegocio negocio = new MarcaNegocio();
                    negocio.agregarMarca(nueva);
                    MessageBox.Show("Marca agregada correctamente");
                }

            }
            catch (Exception ex)
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
