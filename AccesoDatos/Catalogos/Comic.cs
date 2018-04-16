using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comics.Modelos.Catalogos;
using Comics.Contratos.Repositorios;
using System.Data.SqlClient;
using System.Transactions;
using Models;

namespace AccesoDatos.Catalogos
{
    public class Comic : Conexion, IComicRepositorio
    {
        #region PRIVATE STRING QUERIES

        private string queryList = @"SELECT * FROM comics tb
            Inner JOIN escritor e on tb.escritor = e.id
	        inner join compania c on tb.compania = c.id
            ORDER BY tb.id
            OFFSET @skip ROWS
            FETCH NEXT @take ROWS ONLY";
        private string queryCantidadComics = "SELECT COUNT(*) FROM comics";
        private string queryDeleteComic = "DELETE FROM comics WHERE id = @id";

        #endregion

        public bool ActualizarComic(Comics.Modelos.Catalogos.Comic comic)
        {
            bool resp = false;
            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    using (SqlConnection con = _Connection())
                    {
                        var query = new SqlCommand("Comic_IU", con);
                        query.CommandType = System.Data.CommandType.StoredProcedure;
                        query.Parameters.AddWithValue("@ComicId", comic.id);
                        query.Parameters.AddWithValue("@Titulo", comic.titulo);
                        query.Parameters.AddWithValue("@Anio", comic.anio);
                        query.Parameters.AddWithValue("@Numero", comic.numero);
                        query.Parameters.AddWithValue("@EscritorId", comic.escritor);
                        query.Parameters.AddWithValue("@CompaniaId", comic.compania);

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

        public int AgregarComic(Comics.Modelos.Catalogos.Comic comic)
        {
            int id = 0;

            try
            {

                using (TransactionScope transaction = new TransactionScope())
                {
                    using (SqlConnection con = _Connection())
                    {
                        var query = new SqlCommand("Comic_IU ", con);
                        query.CommandType = System.Data.CommandType.StoredProcedure;
                        query.Parameters.AddWithValue("@ComicId", comic.id);
                        query.Parameters.AddWithValue("@Titulo", comic.titulo);
                        query.Parameters.AddWithValue("@Anio", comic.anio);
                        query.Parameters.AddWithValue("@Numero", comic.numero);
                        query.Parameters.AddWithValue("@EscritorId", comic.escritor);
                        query.Parameters.AddWithValue("@CompaniaId", comic.compania);

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

        public bool EliminarComic(int comicId)
        {
            bool resp = false;

            try
            {
                using (SqlConnection con = _Connection())
                {
                    var query = new SqlCommand(queryDeleteComic, con);
                    query.Parameters.AddWithValue("@id", comicId);
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

        public List<ComicViewModel> List(int skip, int take)
        {
            var comics = new List<ComicViewModel>();

            try
            {
                using (SqlConnection con = _Connection())
                {
                    var query = new SqlCommand("Comic_ObtenerLista", con);
                    query.CommandType = System.Data.CommandType.StoredProcedure;

                    query.Parameters.AddWithValue("@Skip", skip);
                    query.Parameters.AddWithValue("@Take", take);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var comicVM = new ComicViewModel();
                            comicVM.escritorNombre = dr["escritorNombre"].ToString();
                            comicVM.companiaNombre = dr["companiaNombre"].ToString();


                            var comic = new Comics.Modelos.Catalogos.Comic
                            {
                                id = Convert.ToInt32(dr["id"]),
                                titulo = dr["titulo"].ToString(),
                                anio = Convert.ToInt32(dr["anio"]),
                                numero = Convert.ToInt32(dr["numero"]),
                                escritor = Convert.ToInt32(dr["escritor"]),
                                compania = Convert.ToInt32(dr["compania"])
                            };
                            comicVM.comic = comic;

                            comics.Add(comicVM);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return comics;
        }

        public int ObtenerCantidadComics()
        {
            int totalComics = 0;

            try
            {
                using (SqlConnection con = _Connection())
                {
                    var query = new SqlCommand(queryCantidadComics, con);
                    totalComics = (int)query.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return totalComics;
        }

        public Comics.Modelos.Catalogos.Comic ObtenerComic(int comicId)
        {
            var comic = new Comics.Modelos.Catalogos.Comic();

            try
            {
                using (SqlConnection con = _Connection())
                {
                    var query = new SqlCommand("exec Comic_Obtener", con);
                    query.Parameters.AddWithValue("@ComicId", comicId);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            comic.id = Convert.ToInt32(dr["id"]);
                            comic.titulo = dr["titulo"].ToString();
                            comic.anio = Convert.ToInt32(dr["anio"]);
                            comic.numero = Convert.ToInt32(dr["numero"]);
                            comic.escritor = Convert.ToInt32(dr["escritor"]);
                            comic.compania = Convert.ToInt32(dr["compania"]);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return comic;
        }

        public int ObtenerUltimoComic()
        {
            throw new NotImplementedException();
        }
    }
}
