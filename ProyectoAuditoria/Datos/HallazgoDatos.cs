using ProyectoAuditoria.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoAuditoria.Datos
{
    public class HallazgoDatos
    {
        public List<HallazgoModel> Listar()
        {
            var oListaH = new List<HallazgoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarHallazgo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListaH.Add(new HallazgoModel()
                        {
                            IdHallazgo = dr["IdHallazgo"].ToString(),
                            Comentario = dr["Comentario"].ToString(),
                            Recomendacion = dr["Recomendacion"].ToString()
                            

                        });
                    }
                }
            }
            return oListaH;
        }

        public HallazgoModel Obtener(string IdHallazgo)
        {

            var oHallazgo = new HallazgoModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerHallazgo", conexion);
                cmd.Parameters.AddWithValue("IdHallazgo", IdHallazgo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oHallazgo.IdHallazgo = dr["IdHallazgo"].ToString();
                        oHallazgo.Comentario = dr["Comentario"].ToString();
                        oHallazgo.Recomendacion = dr["Recomendacion"].ToString();
                        
                    }
                }
            }
            return oHallazgo;
        }


        public bool Guardar(HallazgoModel ohallazgo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarHallazgo", conexion);
                    cmd.Parameters.AddWithValue("IdHallazgo", ohallazgo.IdHallazgo);
                    cmd.Parameters.AddWithValue("Comentario", ohallazgo.Comentario);
                    cmd.Parameters.AddWithValue("Recomendacion", ohallazgo.Recomendacion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }


        public bool Editar(HallazgoModel ohallazgo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarHallazgo", conexion);
                    cmd.Parameters.AddWithValue("IdHallazgo", ohallazgo.IdHallazgo);
                    cmd.Parameters.AddWithValue("Comentario", ohallazgo.Comentario);
                    cmd.Parameters.AddWithValue("Recomendacion", ohallazgo.Recomendacion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }


        public bool Eliminar(string IdHallazgo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarHallazgo", conexion);
                    cmd.Parameters.AddWithValue("IdHallazgo", IdHallazgo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }
    }
}
