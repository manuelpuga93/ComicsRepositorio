using System;
using System.Collections.Generic;
using System.Text;

namespace Comics.Contratos.Repositorios
{
    public interface IComicRepositorio
    {
        List<Modelos.Catalogos.Comic> List(int skip, int take);
        int ObtenerCantidadComics();
    }
}
