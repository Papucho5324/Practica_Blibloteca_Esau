using Practica_Blibloteca.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_Blibloteca
{
    public partial class FormAgregarSocio : Form
    {

        public Usuario NuevoSocio { get; private set; }
        public FormAgregarSocio()
        {
            InitializeComponent();
            NuevoSocio = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // 2. Validaciones (simples)
            if (string.IsNullOrWhiteSpace(txtIDUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("ID del usuario y Nombre son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // 3. Si todo es válido, CREAMOS el objeto Libro
            NuevoSocio = new Usuario(
                txtIDUsuario.Text,
                txtNombreCompleto.Text
            );

            // 4. Indicamos que todo salió bien y cerramos el formulario
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // 5. Indicamos que se canceló la operación y cerramos
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

