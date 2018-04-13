using System;
using System.Collections.Generic;
using System.Text;

namespace Comics.Modelos.Catalogos
{
    public class Comic
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public int anio { get; set; }
        public int numero { get; set; }
        public int escritor { get; set; }
        public int compania { get; set; }
    }
}
