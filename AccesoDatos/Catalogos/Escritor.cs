using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Comics.Modelos.Catalogos;
using Contratos.Repositorios;

namespace AccesoDatos.Catalogos
{
    public class Escritor : Conexion, IEscritorRepositorio
    {
        #region PRIVATE STRING QUERIES

        private string queryList = @"SELECT * FROM escritor
            ORDER BY id
            OFFSET @skip ROWS
            FETCH NEXT @take ROWS ONLY";
        private string queryCantidadescritores = "SELECT COUNT(*) FROM escritor";
        private string queryDeleteEscritor = "DELETE FROM escritor WHERE id = @id";

        #endregion

        public bool ActualizarEscritor(Comics.Modelos.Catalogos.Escritor escritor)
        {
            bool resp = false;
            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    using (SqlConnection con = _Connection())
                    {
                        var query = new SqlCommand("exec Escritor_IU", con);
                        query.Parameters.AddWithValue("@EscritorId", escritor.id);
                        query.Parameters.AddWithValue("@Nombre", escritor.nombre);
                        query.Parameters.AddWithValue("@Apellido", escritor.apellido);
                        query.Parameters.AddWithValue("@Nacimiento", escritor.nacimiento);

                        transaction.Complete();
                        resp = true;

                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return resp;
        }

        public int AgregarEscritor(Comics.Modelos.Catalogos.Escritor escritor)
        {
            int id = 0;

            try
            {

                using (TransactionScope transaction = new TransactionScope())
                {
                    using (SqlConnection con = _Connection())
                    {
                        var query = new SqlCommand("exec Escritor_IU ", con);
                        query.Parameters.AddWithValue("@EscritorId", escritor.id);
                        query.Parameters.AddWithValue("@Nombre", escritor.nombre);
                        query.Parameters.AddWithValue("@Apellido", escritor.apellido);

                        id = (int)query.ExecuteScalar();

                        transaction.Complete();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return id;
        }

        public bool EliminarEscritor(int escritorId)
        {
            bool resp = false;

            try
            {
                using (SqlConnection con = _Connection())
                {
                    var query = new SqlCommand(queryDeleteEscritor, con);
                    query.Parameters.AddWithValue("@id", escritorId);
                    query.ExecuteNonQuery();

                    resp = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); ;
            }

            return resp;
        }

        public List<Comics.Modelos.Catalogos.Escritor> List(int skip, int take)
        {
            var escritores = new List<Comics.Modelos.Catalogos.Escritor>();

            try
            {
                using (SqlConnection con = _Connection())
                {
                    var query = new SqlCommand(queryList, con);
                    query.Parameters.AddWithValue("@skip", skip);
                    query.Parameters.AddWithValue("@take", take);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var escritor = new Comics.Modelos.Catalogos.Escritor
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString()
                            };

                            escritores.Add(escritor);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return escritores;
        }

        public int ObtenerCantidadEscritores()
        {
            int totalEscritores = 0;

            try
            {
                using (SqlConnection con = _Connection())
                {
                    var query = new SqlCommand(queryCantidadescritores, con);
                    totalEscritores = (int)query.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return totalEscritores;
        }

        public Comics.Modelos.Catalogos.Escritor ObtenerEscritor(int escritorId)
        {
            var escritor = new Comics.Modelos.Catalogos.Escritor();

            try
            {
                using (SqlConnection con = _Connection())
                {
                    var query = new SqlCommand("exec Escritor_Obtener", con);
                    query.Parameters.AddWithValue("@EscritorId", escritorId);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {

                            escritor.id = Convert.ToInt32(dr["id"]);
                            escritor.nombre = dr["nombre"].ToString();
                            escritor.apellido = dr["apellido"].ToString();
                            escritor.nacimiento = dr["nacimiento"].ToString();

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return escritor;
        }

        public int ObtenerUltimoEscritor()
        {
            throw new NotImplementedException();
        }
    }
}
