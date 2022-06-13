using ProyectoAuditoria.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoAuditoria.Datos
{
    public class AuditoriaDatos
    {
        

        public List<AuditoriaModel> Listar()
        {
            var oListaA = new List<AuditoriaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAudit", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListaA.Add(new AuditoriaModel()
                        {
                            IdAuditoria = dr["IdAuditoria"].ToString(),
                            FechaInicioAuditoria = dr["FechaInicioAuditoria"].ToString(),
                            FechaFinalAuditoria = dr["FechaFinalAuditoria"].ToString(),
                            Comentarios = dr["Comentarios"].ToString(),
                            Recomendacion = dr["Recomendacion"].ToString(),
                            IdActivo = dr["IdActivo"].ToString(),

                        });
                    }
                }
            }
            return oListaA;
        }

        public AuditoriaModel Obtener(string IdAuditoria)
        {

            var oAuditoria = new AuditoriaModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerAudit", conexion);
                cmd.Parameters.AddWithValue("IdAuditoria", IdAuditoria);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oAuditoria.IdAuditoria = dr["IdAuditoria"].ToString();
                        oAuditoria.FechaInicioAuditoria = dr["FechaInicioAuditoria"].ToString();
                        oAuditoria.FechaFinalAuditoria = dr["FechaFinalAuditoria"].ToString();
                        oAuditoria.Comentarios = dr["Comentarios"].ToString();
                        oAuditoria.Recomendacion = dr["Recomendacion"].ToString();
                        oAuditoria.IdActivo = dr["IdActivo"].ToString();
                    }
                }
            }
            return oAuditoria;
        }


        public bool Guardar(AuditoriaModel oauditoria)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarAudit", conexion);
                    cmd.Parameters.AddWithValue("IdAuditoria", oauditoria.IdAuditoria);
                    cmd.Parameters.AddWithValue("FechaInicioAuditoria", oauditoria.FechaInicioAuditoria);
                    cmd.Parameters.AddWithValue("FechaFinalAuditoria", oauditoria.FechaFinalAuditoria);
                    cmd.Parameters.AddWithValue("Comentarios", oauditoria.Comentarios);
                    cmd.Parameters.AddWithValue("Recomendacion", oauditoria.Recomendacion);
                    cmd.Parameters.AddWithValue("IdActivo", oauditoria.IdActivo);
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


        public bool Editar(AuditoriaModel oauditoria)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarAudit", conexion);
                    cmd.Parameters.AddWithValue("IdAuditoria", oauditoria.IdAuditoria);
                    cmd.Parameters.AddWithValue("FechaInicioAuditoria", oauditoria.FechaInicioAuditoria);
                    cmd.Parameters.AddWithValue("FechaFinalAuditoria", oauditoria.FechaFinalAuditoria);
                    cmd.Parameters.AddWithValue("Comentarios", oauditoria.Comentarios);
                    cmd.Parameters.AddWithValue("Recomendacion", oauditoria.Recomendacion);
                    cmd.Parameters.AddWithValue("IdActivo", oauditoria.IdActivo);
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


        public bool Eliminar(string IdAuditoria)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarAudit", conexion);
                    cmd.Parameters.AddWithValue("IdAuditoria", IdAuditoria);
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
