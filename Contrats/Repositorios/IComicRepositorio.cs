using System;
using System.Collections.Generic;
using System.Text;
using Comics.Modelos.Catalogos;

namespace Comics.Contratos.Repositorios
{
    public interface IComicRepositorio
    {
        List<Comic> List(int skip, int take);
        int ObtenerCantidadComics();
        int ObtenerUltimoComic();
        Comic ObtenerComic(int comicId);
        int AgregarComic(Comic comic);
        bool ActualizarComic(Comic comic);
        bool EliminarComic(int comicId);
    }
}
