using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Blibloteca.Clases
{
    public abstract class Publicacion
    {
        public string CodigoInterno { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnioPublicacion { get; set; }
        public bool Disponible { get; set; }


        public Publicacion(string codigo, string titulo, string autor, int anio)
        {
            CodigoInterno = codigo;
            Titulo = titulo;
            Autor = autor;
            AnioPublicacion = anio;

            // Todo material nuevo ingresa como disponible
            Disponible = true;
        }
    }
}
