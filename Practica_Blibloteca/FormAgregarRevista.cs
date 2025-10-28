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
    public partial class FormAgregarRevista : Form
    {

        public Revista NuevaRevista { get; private set; }
        public FormAgregarRevista()
        {
            InitializeComponent();
            NuevaRevista = null;
        }

        private void FormAgregarRevista_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 2. Validaciones (simples)
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Código y Título son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de año (simple)
            if (!int.TryParse(txtAnio.Text, out int anio) )
            {
                MessageBox.Show("El año debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación de número de edición (simple)
            if (!int.TryParse(txtEdicion.Text, out int edicion))
            {
                MessageBox.Show("El número de edición debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Si todo es válido, CREAMOS el objeto Libro
            NuevaRevista = new Revista(
                txtCodigo.Text,
                txtTitulo.Text,
                txtAutor.Text,
                anio,
                txtISSN.Text,
                edicion
            );

            // 4. Indicamos que todo salió bien y cerramos el formulario
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
