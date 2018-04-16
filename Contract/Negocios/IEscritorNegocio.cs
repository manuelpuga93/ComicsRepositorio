using System;
using System.Collections.Generic;
using System.Text;
using Comics.Modelos.Catalogos;
using Comics.Modelos.Dtos;

namespace Comics.Contratos.Negocios
{
    public interface IEscritorNegocio
    {
        DtoEscritor ObtenerEscritores(int skip, int take);
        DtoEscritor ObtenerEscritores();
        Escritor ObtenerEscritorPorId(int escritorId);
        int CrearEscritor(Escritor escritor);
        int ActualizarEscritor(Escritor escritor);
        void EliminarEscritor(int escritorId);
    }
}
