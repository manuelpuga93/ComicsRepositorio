using System;
using System.Collections.Generic;
using System.Text;
using Comics.Modelos.Catalogos;
using Comics.Modelos.Dtos;

namespace Comics.Contratos.Negocios
{
    public interface IComicNegocio
    {
        DtoComic ObtenerComics(int skip, int take);
        Comic ObtenerComicPorId(int comicId);
        int CrearComic(Comic comic);
        int ActualizarComic(Comic comic);
        void EliminarComic(int comicId);
    }
}
}
