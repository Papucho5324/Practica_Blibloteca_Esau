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
    public partial class Form1 : Form
    {
        private Biblioteca miBiblioteca;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            miBiblioteca = new Biblioteca();
            CargarDatosDePrueba();
            RefrescarTablas();
        }

        private void CargarDatosDePrueba()
        {
            // (Aquí puedes añadir libros, revistas y socios de prueba)
            miBiblioteca.AgregarSocio(new Usuario("123", "Juan Perez"));
            miBiblioteca.AgregarPublicacion(new Libro("L-001", "El Quijote", "Cervantes", 1605, "ISBN-1", false));
            miBiblioteca.AgregarPublicacion(new Libro("L-002", "Diccionario", "RAE", 2010, "ISBN-2", true)); // Libro de consulta
            miBiblioteca.AgregarPublicacion(new Revista("R-001", "NatGeo", "Varios", 2023, "ISSN-1", 12));
        }

        private void RefrescarTablas()
        {
            // --- PESTAÑA PRÉSTAMOS (DataGridView) ---
            var prestamosParaMostrar = miBiblioteca.GetPrestamosActivos()
                .Select(p => new
                {
                    Socio = p.Socio.NombreCompleto,
                    Material = p.MaterialPrestado.Titulo,
                    Tipo = (p.MaterialPrestado is Libro) ? "Libro" : "Revista",
                    FechaPrestamo = p.FechaPrestamo.ToShortDateString(),
                    FechaLimite = p.FechaDevolucionPrevista.ToShortDateString()
                }).ToList();

            dgvPrestamosActivos.DataSource = null;
            dgvPrestamosActivos.DataSource = prestamosParaMostrar;

            // --- PESTAÑA PRÉSTAMOS (ComboBox) ---
            // Guardamos la selección actual para que no se pierda si solo estamos refrescando
            object seleccionActual = cmbMaterial.SelectedValue;

            cmbMaterial.DataSource = null;

            // ¡REGLA DE NEGOCIO! Solo mostramos los que SÍ están disponibles
            cmbMaterial.DataSource = miBiblioteca.GetCatalogo()
                    .Where(p => p.Disponible &&
                                !(p is Libro libro && libro.EsDeConsulta))
                    .ToList();

            cmbMaterial.DisplayMember = "Titulo";      // Lo que el usuario VE (Ej: "El Quijote")
            cmbMaterial.ValueMember = "CodigoInterno"; // Lo que USAMOS (Ej: "L-001")

            // Restauramos la selección si aún existe
            if (seleccionActual != null)
            {
                cmbMaterial.SelectedValue = seleccionActual;

            }

            // --- PESTAÑA CATÁLOGO ---
            dgvCatalogo.DataSource = null;
            // GetCatalogo() devuelve la List<Publicacion> que incluye Libros y Revistas
            dgvCatalogo.DataSource = miBiblioteca.GetCatalogo();

            // Ocultar columnas que no son amigables (opcional pero recomendado)
            if (dgvCatalogo.Columns["ISBN"] != null) dgvCatalogo.Columns["ISBN"].DisplayIndex = 5;
            if (dgvCatalogo.Columns["ISSN"] != null) dgvCatalogo.Columns["ISSN"].DisplayIndex = 5;


            // --- PESTAÑA SOCIOS ---
            dgvSocios.DataSource = null;
            dgvSocios.DataSource = miBiblioteca.GetSocios();

            // Ajustar columnas para que se vea bien
            dgvSocios.Columns["IDUsuario"].HeaderText = "ID Socio";
            dgvSocios.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
            dgvSocios.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Ocupar espacio
            dgvSocios.Columns["EstaSancionado"].HeaderText = "¿Sancionado?";
            dgvSocios.Columns["FechaFinSancion"].HeaderText = "Fin Sanción";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtIdSocio_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvPrestamosActivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRealizarPrestamo_Click(object sender, EventArgs e)
        {
            // 1. Obtener los IDs (txtSocio sigue igual)
            string idSocio = txtSocio.Text; // Asumiendo que se llama txtSocio

            // ¡CAMBIO! Leemos el "Valor" del ComboBox
            string idMaterial = (string)cmbMaterial.SelectedValue;

            // 2. Validar
            if (string.IsNullOrWhiteSpace(idSocio))
            {
                MessageBox.Show("Por favor, ingrese un ID de socio.", "Campo Vacío",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMaterial.SelectedValue == null || string.IsNullOrWhiteSpace(idMaterial))
            {
                MessageBox.Show("Por favor, seleccione un material de la lista.", "Campo Vacío",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Llamar a la lógica de negocio
            ResultadoPrestamo resultado = miBiblioteca.RealizarPrestamo(idSocio, idMaterial);

            // 4. Dar retroalimentación
            if (resultado.Exito)
            {
                MessageBox.Show("¡Préstamo realizado con éxito!", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSocio.Text = ""; // Limpiar el socio
            }
            else
            {
                // Usamos el mensaje específico que nos dio la clase Biblioteca
                MessageBox.Show(resultado.Mensaje,
                                "Préstamo Denegado",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 5. Actualizar TODO (el dgv Y el cmbMaterial)
            RefrescarTablas();
        }

        private void btnRealizarDevolucion_Click(object sender, EventArgs e)
        {
            if (dgvPrestamosActivos.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un préstamo de la lista para devolver.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int indiceSeleccionado = dgvPrestamosActivos.CurrentRow.Index;

            // Obtenemos la lista ORIGINAL
            List<Prestamo> listaActiva = miBiblioteca.GetPrestamosActivos();

            // Usamos el índice para encontrar el objeto 'Prestamo'
            Prestamo prestamoADevolver = listaActiva[indiceSeleccionado];

            bool exito = miBiblioteca.RegistrarDevolucion(prestamoADevolver);

            if (exito)
            {
                if (prestamoADevolver.Socio.EstaSancionado)
                {
                    MessageBox.Show($"¡Devolución registrada!\nATENCIÓN: El socio {prestamoADevolver.Socio.NombreCompleto} " +
                                    "ha sido SANCIONADO por entrega tardía.",
                                    "Devolución con Sanción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("¡Devolución registrada con éxito!", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar la devolución.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Actualizamos todo (el préstamo desaparecerá del DGV y aparecerá en el ComboBox)
            RefrescarTablas();
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            // 1. Creamos una instancia del formulario de "Agregar Libro"
            using (FormAgregarLibro formNuevoLibro = new FormAgregarLibro())
            {
                DialogResult resultado = formNuevoLibro.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    Libro libroCreado = formNuevoLibro.NuevoLibro;

                    // --- ¡AQUÍ ESTÁ EL CAMBIO! ---
                    // 1. Llama al método y captura la respuesta 'bool'
                    bool exito = miBiblioteca.AgregarPublicacion(libroCreado);

                    // 2. Comprueba la respuesta
                    if (exito)
                    {
                        // Si fue exitoso, refresca y notifica
                        RefrescarTablas();
                        MessageBox.Show("Libro agregado al catálogo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Si NO fue exitoso, es un duplicado. Informa el error.
                        MessageBox.Show($"Error: Ya existe una publicación con el código '{libroCreado.CodigoInterno}'.",
                                        "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAgregarRevista_Click(object sender, EventArgs e)
        {
            using (FormAgregarRevista formNuevaRevista = new FormAgregarRevista())
            {
                DialogResult resultado = formNuevaRevista.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    Revista revistaCreada = formNuevaRevista.NuevaRevista;

                    // --- ¡AQUÍ ESTÁ EL CAMBIO! ---
                    // 1. Llama al método y captura la respuesta 'bool'
                    bool exito = miBiblioteca.AgregarPublicacion(revistaCreada);

                    // 2. Comprueba la respuesta
                    if (exito)
                    {
                        // Si fue exitoso, refresca y notifica
                        RefrescarTablas();
                        MessageBox.Show("Libro agregado al catálogo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Si NO fue exitoso, es un duplicado. Informa el error.
                        MessageBox.Show($"Error: Ya existe una publicación con el código '{revistaCreada.CodigoInterno}'.",
                                        "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // 1. Comprobar si hay algo seleccionado
            if (dgvCatalogo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos una fila para eliminar.",
                                "Nada seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Pedir confirmación
            int cantidad = dgvCatalogo.SelectedRows.Count;
            string mensaje = (cantidad == 1)
                ? "¿Está seguro de que desea eliminar 1 publicación?"
                : $"¿Está seguro de que desea eliminar {cantidad} publicaciones?";

            if (MessageBox.Show(mensaje, "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return; // El usuario canceló
            }

            // 3. Bucle de eliminación (¡IMPORTANTE!)
            // No podemos eliminar directamente del 'DataSource' mientras lo recorremos.
            // Primero copiamos los items a eliminar a una lista temporal.

            List<Publicacion> itemsAEliminar = new List<Publicacion>();
            foreach (DataGridViewRow row in dgvCatalogo.SelectedRows)
            {
                // 'DataBoundItem' es el objeto REAL (Libro o Revista)
                // que está "atado" a esa fila.
                itemsAEliminar.Add((Publicacion)row.DataBoundItem);
            }

            // 4. Ahora sí, iteramos la lista temporal y eliminamos
            int borradosExitosos = 0;
            int borradosFallidos = 0; // Para contar los que están prestados

            foreach (Publicacion pub in itemsAEliminar)
            {
                // Llamamos a nuestra lógica de negocio segura
                if (miBiblioteca.RemoverPublicacion(pub.CodigoInterno))
                {
                    borradosExitosos++;
                }
                else
                {
                    borradosFallidos++;
                }
            }

            // 5. Refrescar la tabla
            RefrescarTablas();

            // 6. Mostrar resumen final
            var sb = new StringBuilder();
            sb.AppendLine("Eliminación completada.");
            sb.AppendLine();
            sb.AppendLine($"{borradosExitosos} publicaciones eliminadas.");
            if (borradosFallidos > 0)
            {
                sb.AppendLine($"{borradosFallidos} no se pudieron eliminar (probablemente están prestadas).");
            }

            MessageBox.Show(sb.ToString(), "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVerificarSanciones_Click(object sender, EventArgs e)
        {
            // 1. Llama a la lógica de negocio
            miBiblioteca.ActualizarSanciones();

            // 2. Refresca la tabla para mostrar los cambios
            // (Los 'true' en "¿Sancionado?" deberían cambiar a 'false' si ya pasó el tiempo)
            RefrescarTablas();

            // 3. Notifica al usuario
            MessageBox.Show("Se han actualizado los estados de sanción de todos los socios.",
                            "Sanciones Verificadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAgregarSocio_Click(object sender, EventArgs e)
        {
            using (FormAgregarSocio formNuevoSocio = new FormAgregarSocio())
            {
                if (formNuevoSocio.ShowDialog() == DialogResult.OK)
                {
                    Usuario socioCreado = formNuevoSocio.NuevoSocio;

                    // Llamamos al nuevo método con validación
                    if (miBiblioteca.AgregarSocio(socioCreado))
                    {
                        RefrescarTablas();
                        MessageBox.Show("Socio agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Error: Ya existe un socio con el ID '{socioCreado.IDUsuario}'.",
                                        "ID Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEliminarSocio_Click(object sender, EventArgs e)
        {

            if (dgvSocios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un socio para eliminar.", "Nada seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"¿Está seguro de que desea eliminar {dgvSocios.SelectedRows.Count} socio(s)?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            // Copiamos los items a una lista temporal
            List<Usuario> sociosAEliminar = new List<Usuario>();
            foreach (DataGridViewRow row in dgvSocios.SelectedRows)
            {
                sociosAEliminar.Add((Usuario)row.DataBoundItem);
            }

            // Eliminamos de la lista temporal
            int borradosExitosos = 0;
            int borradosFallidos = 0;

            foreach (Usuario socio in sociosAEliminar)
            {
                if (miBiblioteca.RemoverSocio(socio.IDUsuario))
                {
                    borradosExitosos++;
                }
                else
                {
                    borradosFallidos++;
                }
            }

            RefrescarTablas();

            // Resumen final
            string resumen = $"{borradosExitosos} socio(s) eliminados.\n" +
                             $"{borradosFallidos} no se pudieron eliminar (porque tienen préstamos activos).";
            MessageBox.Show(resumen, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
