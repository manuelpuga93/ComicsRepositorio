using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comics.Modelos.Catalogos;

namespace Comics.Modelos.Dtos
{
    public class DtoComic
    {
        public int totalComics { get; set; }
        public List<Comic> comics { get; set; }
    }
}
