using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comics.Modelos.Catalogos;
using Contratos.Repositorios;

namespace AccesoDatos.Catalogos
{
    public class Escritor : Conexion, IEscritorRepositorio
    {
        public bool ActualizarEscritor(Comics.Modelos.Catalogos.Escritor escritor)
        {
            throw new NotImplementedException();
        }

        public int AgregarEscritor(Comics.Modelos.Catalogos.Escritor escritor)
        {
            throw new NotImplementedException();
        }

        public bool EliminarEscritor(int escritorId)
        {
            throw new NotImplementedException();
        }

        public List<Comics.Modelos.Catalogos.Escritor> List(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public int ObtenerCantidadEscritores()
        {
            throw new NotImplementedException();
        }

        public Comics.Modelos.Catalogos.Escritor ObtenerEscritor(int escritorId)
        {
            throw new NotImplementedException();
        }

        public int ObtenerUltimoEscritor()
        {
            throw new NotImplementedException();
        }
    }
}
