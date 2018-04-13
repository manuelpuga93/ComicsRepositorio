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
    [RoutePrefix("api/v1/escritores")]
    public class EscritorController : ApiController
    {
        private IEscritorNegocio _escritorNegocio;

        public EscritorController(IEscritorNegocio escritorNegocio)
        {
            this._escritorNegocio = escritorNegocio;
        }

        [HttpGet]
        [Route("", Name = "ObtenerEscritores")]
        public IHttpActionResult ObtenerEscritores(int skip, int take)
        {
            try
            {
                var escritores = this._escritorNegocio.ObtenerEscritores(skip, take);
                if (escritores.totalEscritores > 0)
                {
                    return this.Ok(escritores);
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
        [Route("{escritorId}", Name = "ObtenerEscritorPorId")]
        public IHttpActionResult ObtenerEscritorPorId(int escritorId)
        {
            try
            {
                var escritor = this._escritorNegocio.ObtenerEscritorPorId(escritorId);
                if (escritor.id > 0)
                {
                    return this.Ok(escritor);
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
        [Route("", Name = "CrearEscritor")]
        public IHttpActionResult CrearEscritor([FromBody] Escritor escritor)
        {
            try
            {
                var escritorId = this._escritorNegocio.CrearEscritor(escritor);
                return this.Ok(escritorId);
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
        [Route("{escritorId}", Name = "ActualizarEscritor")]
        public IHttpActionResult ActualizarEscritor([FromBody] Escritor escritor, int escritorId)
        {
            try
            {
                var escritorIdActualizado = this._escritorNegocio.ActualizarEscritor(escritor);
                return this.Ok(escritorIdActualizado);
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
        [Route("{escritorId}", Name = "EliminarEscritor")]
        public IHttpActionResult EliminarEscritor(int escritorId)
        {
            try
            {
                this._escritorNegocio.EliminarEscritor(escritorId);
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
