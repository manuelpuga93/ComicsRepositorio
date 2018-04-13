using System;
using System.Collections.Generic;
using System.Text;
using Comics.Contratos.Negocios;
using Comics.Contratos.Repositorios;
using Comics.Modelos.Catalogos;
using Comics.Modelos.Dtos;

namespace Negocios
{
    public class ComicNegocio : IComicNegocio
    {
        private IComicRepositorio _comicRepositorio;

        public ComicNegocio(IComicRepositorio comicRepositorio)
        {
            this._comicRepositorio = comicRepositorio;
        }

        public DtoComic ObtenerComics(int skip, int take)
        {
            var comics = this._comicRepositorio.List(skip, take);
            var totalComics = this._comicRepositorio.ObtenerCantidadComics();
            var dtoComics = new DtoComic { totalComics = totalComics, comics = comics };
            return dtoComics;
        }

        public Comic ObtenerComicPorId(int comicId)
        {
            var comic = this._comicRepositorio.ObtenerComic(comicId);
            return comic;
        }

        public int CrearComic(Comic comic)
        {
            var comicId = this._comicRepositorio.AgregarComic(comic);
            return comicId;
        }

        public int ActualizarComic(Comic comic)
        {
            var exitoso = this._comicRepositorio.ActualizarComic(comic);
            if (exitoso)
            {
                return comic.id;
            }
            else
            {
                return 0;
            }
        }

        public void EliminarComic(int comicId)
        {
            this._comicRepositorio.EliminarComic(comicId);
        }

    }
}
