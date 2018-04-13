using System;
using System.Collections.Generic;
using System.Text;
using Comics.Modelos.Catalogos;
using Comics.Modelos.Dtos;

namespace Comics.Contratos.Negocios
{
    public interface ICompaniaNegocio
    {
        DtoCompania ObtenerCompanias(int skip, int take);
        Compania ObtenerCompaniaPorId(int companiaId);
        int CrearCompania(Compania compania);
        int ActualizarCompania(Compania compania);
        void EliminarCompania(int companiaId);
    }
}
