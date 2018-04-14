using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comics.Modelos.Catalogos;
using Comics.Contratos.Repositorios;

namespace AccesoDatos.Catalogos
{
    public class Comic : Conexion, IComicRepositorio
    {
        public bool ActualizarComic(Comics.Modelos.Catalogos.Comic comic)
        {
            throw new NotImplementedException();
        }

        public int AgregarComic(Comics.Modelos.Catalogos.Comic comic)
        {
            throw new NotImplementedException();
        }

        public bool EliminarComic(int comicId)
        {
            throw new NotImplementedException();
        }

        public List<Comics.Modelos.Catalogos.Comic> List(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public int ObtenerCantidadComics()
        {
            throw new NotImplementedException();
        }

        public Comics.Modelos.Catalogos.Comic ObtenerComic(int comicId)
        {
            throw new NotImplementedException();
        }

        public int ObtenerUltimoComic()
        {
            throw new NotImplementedException();
        }
    }
}
