using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Blibloteca.Clases
{
    public class ResultadoPrestamo
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }

        // Opcional: Un código de error más específico
        public string CodigoError { get; set; }
    }
}
