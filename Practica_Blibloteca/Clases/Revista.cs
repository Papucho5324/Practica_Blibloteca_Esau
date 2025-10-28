using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Blibloteca.Clases
{
    public class Revista : Publicacion
    {
        public string ISSN { get; set; }
        public int NumeroEdicion { get; set; }

        public Revista(string codigo, string titulo, string autor, int anio, string issn, int numeroEdicion)
        // 1. Pasa los valores comunes al constructor de la clase base (Publicacion)
        : base(codigo, titulo, autor, anio)
        {
            // 2. Asigna las propiedades que SÓLO tiene la revista
            ISSN = issn;
            NumeroEdicion = numeroEdicion;
        }
    }
}
