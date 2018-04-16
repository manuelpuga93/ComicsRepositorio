using Comics.Modelos.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ComicViewModel
    {
        public Comic comic { get; set; }
        public string escritorNombre { get; set; }
        public string companiaNombre { get; set; }
    }
}
