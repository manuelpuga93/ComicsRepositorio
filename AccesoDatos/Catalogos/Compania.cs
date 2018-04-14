using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comics.Modelos.Catalogos;
using Comics.Contratos.Repositorios;

namespace AccesoDatos.Catalogos
{
    public class Compania : Conexion, ICompaniaRepositorio
    {

        public bool ActualizarCompania(Comics.Modelos.Catalogos.Compania compania)
        {
            throw new NotImplementedException();
        }

        public int AgregarCompania(Comics.Modelos.Catalogos.Compania compania)
        {
            throw new NotImplementedException();
        }

        public bool EliminarCompania(int companiaId)
        {
            throw new NotImplementedException();
        }

        public List<Comics.Modelos.Catalogos.Compania> List(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public int ObtenerCantidadCompanias()
        {
            throw new NotImplementedException();
        }

        public Comics.Modelos.Catalogos.Compania ObtenerCompania(int companiaId)
        {
            throw new NotImplementedException();
        }

        public int ObtenerUltimoCompania()
        {
            throw new NotImplementedException();
        }
    }
}
