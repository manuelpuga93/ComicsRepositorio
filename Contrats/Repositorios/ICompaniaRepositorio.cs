using System;
using System.Collections.Generic;
using System.Text;
using Comics.Modelos.Catalogos;

namespace Comics.Contratos.Repositorios
{
    public interface ICompaniaRepositorio
    {
        List<Compania> List(int skip, int take);
        int ObtenerCantidadCompanias();
        int ObtenerUltimoCompania();
        Compania ObtenerCompania(int companiaId);
        int AgregarCompania(Compania compania);
        bool ActualizarCompania(Compania compania);
        bool EliminarCompania(int companiaId);
    }
}
