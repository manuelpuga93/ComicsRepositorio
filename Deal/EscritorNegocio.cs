using System;
using System.Collections.Generic;
using System.Text;
using Comics.Contratos.Negocios;
using Comics.Modelos.Catalogos;
using Comics.Modelos.Dtos;
using Contratos.Repositorios;

namespace Negocios
{
    public class EscritorNegocio : IEscritorNegocio
    {
        private IEscritorRepositorio _escritorRepositorio;

        public EscritorNegocio(IEscritorRepositorio escritorRepositorio)
        {
            this._escritorRepositorio = escritorRepositorio;
        }

        public DtoEscritor ObtenerEscritores(int skip, int take)
        {
            var escritores = this._escritorRepositorio.List(skip, take);
            var totalEscritores = this._escritorRepositorio.ObtenerCantidadEscritores();
            var dtoEscritor = new DtoEscritor { totalEscritores = totalEscritores, escritores = escritores };
            return dtoEscritor;
        }

        public Escritor ObtenerEscritorPorId(int escritorId)
        {
            var escritor = this._escritorRepositorio.ObtenerEscritor(escritorId);
            return escritor;
        }

        public int CrearEscritor(Escritor escritor)
        {
            var escritorId = this._escritorRepositorio.AgregarEscritor(escritor);
            return escritorId;
        }

        public int ActualizarEscritor(Escritor escritor)
        {
            var exitoso = this._escritorRepositorio.ActualizarEscritor(escritor);
            if (exitoso)
            {
                return escritor.id;
            }
            else
            {
                return 0;
            }
        }

        public void EliminarEscritor(int escritorId)
        {
            this._escritorRepositorio.EliminarEscritor(escritorId);
        }
    }
}
