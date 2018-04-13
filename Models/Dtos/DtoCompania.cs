using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comics.Modelos.Catalogos;

namespace Comics.Modelos.Dtos
{
    public class DtoCompania
    {
        public int totalCompanias { get; set; }
        public List<Compania> companias { get; set; }
    }
}
