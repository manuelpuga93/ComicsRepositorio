using System;
using System.Collections.Generic;
using System.Text;
using Comics.Modelos.Catalogos;

namespace Contratos.Repositorios
{
    public interface IEscritorRepositorio
    {
        List<Escritor> List(int skip, int take);
        int ObtenerCantidadEscritores();
        int ObtenerUltimoEscritor();
        Escritor ObtenerEscritor(int escritorId);
        int AgregarEscritor(Escritor escritor);
        bool ActualizarEscritor(Escritor escritor);
        bool EliminarEscritor(int escritorId);
    }
}
