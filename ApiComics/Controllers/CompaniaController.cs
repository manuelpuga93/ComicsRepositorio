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
    [RoutePrefix("api/v1/companias")]
    public class CompaniaController : ApiController
    {
        private ICompaniaNegocio _companiaNegocio;

        public CompaniaController(ICompaniaNegocio companiaNegocio)
        {
            this._companiaNegocio = companiaNegocio;
        }

        [HttpGet]
        [Route("", Name = "ObtenerCompanias")]
        public IHttpActionResult ObtenerCompanias(int skip, int take)
        {
            try
            {
                var companias = this._companiaNegocio.ObtenerCompanias(skip, take);
                if (companias.totalCompanias > 0)
                {
                    return this.Ok(companias);
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
        [Route("{companiaId}", Name = "ObtenerCompaniaPorId")]
        public IHttpActionResult ObtenerCompaniaPorId(int companiaId)
        {
            try
            {
                var compania = this._companiaNegocio.ObtenerCompaniaPorId(companiaId);
                if (compania.id > 0)
                {
                    return this.Ok(compania);
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
        [Route("", Name = "CrearCompania")]
        public IHttpActionResult CrearCompania([FromBody] Compania compania)
        {
            try
            {
                var companiaId = this._companiaNegocio.CrearCompania(compania);
                return this.Ok(companiaId);
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
        [Route("{companiaId}", Name = "ActualizarCompania")]
        public IHttpActionResult ActualizarCompania([FromBody] Compania compania, int companiaId)
        {
            try
            {
                var companiaIdActualizado = this._companiaNegocio.ActualizarCompania(compania);
                return this.Ok(companiaIdActualizado);
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
        [Route("{companiaId}", Name = "EliminarCompania")]
        public IHttpActionResult EliminarCompania(int companiaId)
        {
            try
            {
                this._companiaNegocio.EliminarCompania(companiaId);
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
