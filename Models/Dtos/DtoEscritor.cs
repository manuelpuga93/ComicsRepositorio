using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comics.Modelos.Catalogos;

namespace Comics.Modelos.Dtos
{
    public class DtoEscritor
    {
        public int totalEscritores { get; set; }
        public List<Escritor> escritores { get; set; }
    }
}
