using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Blibloteca.Clases
{
    public class Prestamo
    {
        public Publicacion MaterialPrestado { get; private set; }
        public Usuario Socio { get; private set; }
        public DateTime FechaPrestamo { get; private set; }
        public DateTime FechaDevolucionPrevista { get; private set; }

        public bool Devuelto { get; set; }

        public Prestamo(Publicacion material, Usuario socio)
        {
            if (material == null)
                throw new ArgumentNullException(nameof(material));
            if (socio == null)
                throw new ArgumentNullException(nameof(socio));

            MaterialPrestado = material;
            Socio = socio;

            FechaPrestamo = DateTime.Now;
            FechaDevolucionPrevista = FechaPrestamo.AddDays(7); 
            Devuelto = false; 
        }

        /// <summary>
        /// Método de ayuda. La clase Prestamo SÍ es responsable
        /// de saber si está atrasada o no.
        /// </summary>
        public bool EstaAtrasado()
        {
          
            return DateTime.Now > FechaDevolucionPrevista && !Devuelto;
        }
    }
}
