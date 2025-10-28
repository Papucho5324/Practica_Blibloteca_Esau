using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Blibloteca.Clases
{
    public class Usuario
    {
        public string IDUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public bool EstaSancionado { get; private set; }
        public DateTime? FechaFinSancion { get; private set; }



        public Usuario(string idUsuario, string nombre)
        {
            IDUsuario = idUsuario;
            NombreCompleto = nombre;

            // Un usuario nuevo siempre inicia sin sanción
            EstaSancionado = false;
            FechaFinSancion = null;
        }

        public void Sancionar()
        {
            EstaSancionado = true;
            // La sanción dura 7 días desde este preciso momento.
            FechaFinSancion = DateTime.Now.AddDays(7);

            // Opcional: Podrías mostrar un mensaje en la UI
            Console.WriteLine($"Usuario {NombreCompleto} sancionado hasta {FechaFinSancion.Value.ToShortDateString()}");
        }

        public void VerificarEstadoSancion()
        {
            // 1. ¿El usuario está sancionado?
            if (EstaSancionado)
            {
                // 2. ¿La fecha de hoy es MÁS RECIENTE que la fecha de fin de sanción?
                if (DateTime.Now > FechaFinSancion.Value)
                {
                    // 3. Si ya pasó el tiempo, levantamos la sanción.
                    EstaSancionado = false;
                    FechaFinSancion = null; // Limpiamos la fecha

                    Console.WriteLine($"Sanción levantada para {NombreCompleto}");
                }
            }
        }
    }
}
