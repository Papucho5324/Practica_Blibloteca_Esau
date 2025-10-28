using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Blibloteca.Clases
{
    public class Libro : Publicacion
    {
        public string ISBN { get; set; }
        public bool EsDeConsulta { get; set; }

        public Libro(string codigo, string titulo, string autor, int anio, string isbn, bool esDeConsulta)
        // 1. Pasa los valores comunes al constructor de la clase base (Publicacion)
        : base(codigo, titulo, autor, anio)
        {
            // 2. Asigna las propiedades que SÓLO tiene el libro
            ISBN = isbn;
            EsDeConsulta = esDeConsulta;
        }
    }
}
