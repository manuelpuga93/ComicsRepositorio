using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comics.Modelos.Catalogos;
using Comics.Contratos.Repositorios;
using System.Data.SqlClient;
using System.Transactions;

namespace AccesoDatos.Catalogos
{
    public class Compania : Conexion, ICompaniaRepositorio
    {

        #region PRIVATE STRING QUERIES

        private string queryList = @"SELECT * FROM compania
            ORDER BY id
            OFFSET @skip ROWS
            FETCH NEXT @take ROWS ONLY";
        private string queryCantidadcompanias = "SELECT COUNT(*) FROM compania";
        private string queryDeleteCompania = "DELETE FROM compania WHERE id = @id";

        #endregion

        public bool ActualizarCompania(Comics.Modelos.Catalogos.Compania compania)
        {
            bool resp = false;
            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    using (SqlConnection con = _Connection())
                    {
                        var query = new SqlCommand("exec Compania_IU", con);
                        query.Parameters.AddWithValue("@CompaniaId", compania.id);
                        query.Parameters.AddWithValue("@Nombre", compania.nombre);
                        query.Parameters.AddWithValue("@Founded", compania.founded);

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

        public int AgregarCompania(Comics.Modelos.Catalogos.Compania compania)
        {
            int id = 0;

            try
            {

                using (TransactionScope transaction = new TransactionScope())
                {
                    using (SqlConnection con = _Connection())
                    {
                        var query = new SqlCommand("exec Compania_IU ", con);
                        query.Parameters.AddWithValue("@CompaniaId", compania.id);
                        query.Parameters.AddWithValue("@Nombre", compania.nombre);
                        query.Parameters.AddWithValue("@founded", compania.founded);

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

        public bool EliminarCompania(int companiaId)
        {
            bool resp = false;

            try
            {
                using (SqlConnection con = _Connection())
                {
                    var query = new SqlCommand(queryDeleteCompania, con);
                    query.Parameters.AddWithValue("@id", companiaId);
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

        public List<Comics.Modelos.Catalogos.Compania> List(int skip, int take)
        {
            var companias = new List<Comics.Modelos.Catalogos.Compania>();

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
                            var compania = new Comics.Modelos.Catalogos.Compania
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                founded = dr["founded"].ToString()
                            };

                            companias.Add(compania);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return companias;
        }

        public int ObtenerCantidadCompanias()
        {
            int totalCompanias = 0;

            try
            {
                using (SqlConnection con = _Connection())
                {
                    var query = new SqlCommand(queryCantidadcompanias, con);
                    totalCompanias = (int)query.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return totalCompanias;
        }

        public Comics.Modelos.Catalogos.Compania ObtenerCompania(int companiaId)
        {
            var compania = new Comics.Modelos.Catalogos.Compania();

            try
            {
                using (SqlConnection con = _Connection())
                {
                    var query = new SqlCommand("exec Compania_Obtener", con);
                    query.Parameters.AddWithValue("@CompaniaId", companiaId);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {

                            compania.id = Convert.ToInt32(dr["id"]);
                            compania.nombre = dr["nombre"].ToString();
                            compania.founded = dr["founded"].ToString();

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return compania;
        }

        public int ObtenerUltimoCompania()
        {
            throw new NotImplementedException();
        }
    }
}
