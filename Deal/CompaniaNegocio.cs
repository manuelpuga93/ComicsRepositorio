using System;
using System.Collections.Generic;
using System.Text;
using Comics.Contratos.Negocios;
using Comics.Contratos.Repositorios;
using Comics.Modelos.Catalogos;
using Comics.Modelos.Dtos;

namespace Negocios
{
    public class CompaniaNegocio : ICompaniaNegocio
    {
        private ICompaniaRepositorio _companiaRepositorio;

        public CompaniaNegocio(ICompaniaRepositorio companiaRepositorio)
        {
            this._companiaRepositorio = companiaRepositorio;
        }

        public DtoCompania ObtenerCompanias(int skip, int take)
        {
            var companias = this._companiaRepositorio.List(skip, take);
            var totalCompanias = this._companiaRepositorio.ObtenerCantidadCompanias();
            var dtoCompania = new DtoCompania { totalCompanias = totalCompanias, companias = companias };
            return dtoCompania;
        }

        public DtoCompania ObtenerCompanias()
        {
            var companias = this._companiaRepositorio.List();
            var totalCompanias = this._companiaRepositorio.ObtenerCantidadCompanias();
            var dtoCompania = new DtoCompania { totalCompanias = totalCompanias, companias = companias };
            return dtoCompania;
        }

        public Compania ObtenerCompaniaPorId(int companiaId)
        {
            var compania = this._companiaRepositorio.ObtenerCompania(companiaId);
            return compania;
        }

        public int CrearCompania(Compania compania)
        {
            var companiaId = this._companiaRepositorio.AgregarCompania(compania);
            return companiaId;
        }

        public int ActualizarCompania(Compania compania)
        {
            var exitoso = this._companiaRepositorio.ActualizarCompania(compania);
            if (exitoso)
            {
                return compania.id;
            }
            else
            {
                return 0;
            }
        }

        public void EliminarCompania(int companiaId)
        {
            this._companiaRepositorio.EliminarCompania(companiaId);
        }
    }
}
