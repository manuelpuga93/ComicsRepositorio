using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Comics.Contratos.Negocios;
using Comics.Modelos.Catalogos;

namespace ApiComics.Controllers
{
    [RoutePrefix("api/v1/comic")]
    public class ComicController : ApiController
    {
        private IComicNegocio _comicNegocio;

        public ComicController(IComicNegocio comicNegocio)
        {
            this._comicNegocio = comicNegocio;
        }

        [HttpGet]
        [Route("", Name = "ObtenerComics")]
        public IHttpActionResult ObtenerComics(int skip, int take)
        {
            try
            {
                var comics = this._comicNegocio.ObtenerComics(skip, take);
                if (comics.totalComics > 0)
                {
                    return this.Ok(comics);
                }
                else
                {
                    return new StatusCodeResult(HttpStatusCode.NotFound, this);
                }
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("{comicId}", Name = "ObtenerComicPorId")]
        public IHttpActionResult ObtenerComicPorId(int comicId)
        {
            try
            {
                var comic = this._comicNegocio.ObtenerComicPorId(comicId);
                if (comic.id > 0)
                {
                    return this.Ok(comic);
                }
                else
                {
                    return new StatusCodeResult(HttpStatusCode.NotFound, this);
                }
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("", Name = "CrearComic")]
        public IHttpActionResult CrearComic([FromBody] Comic comic)
        {
            try
            {
                var comicId = this._comicNegocio.CrearComic(comic);
                return this.Ok(comicId);
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        [Route("{comicId}", Name = "ActualizarComic")]
        public IHttpActionResult ActualizarComic([FromBody] Comic comic, int comicId)
        {
            try
            {
                var comicIdActualizado = this._comicNegocio.ActualizarComic(comic);
                return this.Ok(comicIdActualizado);
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("{comicId}", Name = "EliminarComic")]
        public IHttpActionResult EliminarComic(int comicId)
        {
            try
            {
                this._comicNegocio.EliminarComic(comicId);
                return new StatusCodeResult(HttpStatusCode.NoContent, this);
            }
            catch (HttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
