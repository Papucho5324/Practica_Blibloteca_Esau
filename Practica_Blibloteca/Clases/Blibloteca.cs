using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Blibloteca.Clases
{
    public class Biblioteca
    {

        private List<Publicacion> Catalogo;
        private List<Usuario> Socios;
        private List<Prestamo> PrestamosActivos;

        // --- Constructor ---
        // ¡INICIALIZAR LAS LISTAS!
        // Esto se llama automáticamente cuando creas una 'new Biblioteca()'
        public Biblioteca()
        {
            Catalogo = new List<Publicacion>();
            Socios = new List<Usuario>();
            PrestamosActivos = new List<Prestamo>();

            // Opcional: Podrías cargar datos de prueba aquí
            // CargarDatosDePrueba(); 
        }

        // --- Métodos de Gestión 

        // Métodos para AÑADIR datos
        public bool AgregarPublicacion(Publicacion p)
        {
            // 2. VALIDACIÓN DE DUPLICADOS
            // Usamos LINQ.Any() para verificar si "alguno" de los items 
            // en el Catálogo ya tiene el mismo CodigoInterno.

            bool yaExiste = Catalogo.Any(item => item.CodigoInterno.ToLower() == p.CodigoInterno.ToLower());

            if (yaExiste)
            {
                // 3. Si se encuentra un duplicado, NO se agrega y se retorna 'false'
                return false;
            }

            // 4. Si no es duplicado, se agrega y se retorna 'true'
            Catalogo.Add(p);
            return true;
        }

        // En: Biblioteca.cs

        /// <summary>
        /// Intenta eliminar una publicación del catálogo.
        /// Devuelve 'true' si se eliminó, 'false' si no se pudo
        /// (porque no se encontró o porque está prestada).
        /// </summary>
        public bool RemoverPublicacion(string codigoInterno)
        {
            // 1. Encontrar la publicación
            Publicacion pubAEliminar = Catalogo.Find(p => p.CodigoInterno.ToLower() == codigoInterno.ToLower());

            if (pubAEliminar == null)
            {
                return false; // No se encontró
            }

            // 2. ¡REGLA DE NEGOCIO CRÍTICA!
            // Si la publicación NO está disponible (o sea, está prestada)...
            if (!pubAEliminar.Disponible)
            {
                // ...no la elimines. Devuelve 'false'.
                return false;
            }

            // 3. Si se encontró y ESTÁ disponible, eliminarla.
            Catalogo.Remove(pubAEliminar);
            return true;
        }

        public void ActualizarSanciones()
        {
            // Llama al método que ya creamos en la clase Usuario
            foreach (Usuario socio in Socios)
            {
                socio.VerificarEstadoSancion();
            }
        }


        public bool AgregarSocio(Usuario u)
        {
            // Validamos que el IDUsuario no esté duplicado
            bool yaExiste = Socios.Any(s => s.IDUsuario.ToLower() == u.IDUsuario.ToLower());

            if (yaExiste)
            {
                return false; // Duplicado
            }

            Socios.Add(u);
            return true; // Éxito
        }


        public bool RemoverSocio(string idUsuario)
        {
            // 1. Encontrar al socio
            Usuario socio = Socios.Find(s => s.IDUsuario.ToLower() == idUsuario.ToLower());
            if (socio == null) return false; // No se encontró

            // 2. REGLA DE NEGOCIO: ¿Tiene préstamos activos?
            // Buscamos en PrestamosActivos si hay alguno de este socio que NO esté devuelto.
            bool tienePrestamos = PrestamosActivos.Any(p => p.Socio == socio && !p.Devuelto);

            if (tienePrestamos)
            {
                return false; // No se puede borrar, tiene préstamos
            }

            // 3. Si no tiene préstamos, eliminar
            Socios.Remove(socio);
            return true;
        }

        // Métodos para OBTENER datos (para la UI)
        public List<Publicacion> GetCatalogo()
        {
            return Catalogo;
        }

        public List<Usuario> GetSocios()
        {
            return Socios;
        }

        public List<Prestamo> GetPrestamosActivos()
        {
            // Filtramos solo los que no han sido devueltos
            return PrestamosActivos.Where(p => !p.Devuelto).ToList();
        }


        // --- Métodos de Lógica de Negocio (Tu código) ---

        public ResultadoPrestamo RealizarPrestamo(string idUsuario, string idMaterial)
        {
            // 1. Buscar los objetos
            Usuario usuario = Socios.Find(u => u.IDUsuario == idUsuario);
            Publicacion material = Catalogo.Find(p => p.CodigoInterno == idMaterial);

            // ¡CORRECCIÓN 2: VALIDAR NULLS!
            if (usuario == null || material == null)
                return new ResultadoPrestamo { Exito = false, Mensaje = "El ID de socio o el código de material no existen.", CodigoError = "ID_INCORRECTO" };

            // 2. Lógica de validación (¡Esto estaba perfecto!)
            if (usuario.EstaSancionado)
                return new ResultadoPrestamo { Exito = false, Mensaje = $"El socio {usuario.NombreCompleto} está sancionado.", CodigoError = "SANCIONADO" };

            if (!material.Disponible)
                return new ResultadoPrestamo { Exito = false, Mensaje = "El material ya se encuentra prestado.", CodigoError = "PRESTADO" };

            if (material is Libro libro)
            {
                if (libro.EsDeConsulta)
                {
                    return new ResultadoPrestamo { Exito = false, Mensaje = "Es libro de consulta, solo se puede usar dentro de la instalación.", CodigoError = "CONSULTA" };
                }
            }

            // 3. Crear el préstamo
            Prestamo nuevoPrestamo = new Prestamo(material, usuario);
            PrestamosActivos.Add(nuevoPrestamo);

            // 4. Actualizar estado
            material.Disponible = false;

            return new ResultadoPrestamo { Exito = true, Mensaje = "Préstamo realizado con éxito." };
        }


        public bool RegistrarDevolucion(Prestamo prestamo)
        {
            if (prestamo == null)
                return false;

            // 1. Marcar material como disponible
            prestamo.MaterialPrestado.Disponible = true;

            // 2. Marcar préstamo como devuelto
            prestamo.Devuelto = true;
            // Opcional: En lugar de marcarlo, podrías hacer:
            // PrestamosActivos.Remove(prestamo); 
            // Y tener otra lista 'HistorialPrestamos.Add(prestamo);'

            // 3. Lógica de Sanción
            if (prestamo.EstaAtrasado())
            {
                prestamo.Socio.Sancionar();
            }

            return true;
        }
    }
}