using ProyectoAuditoria.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoAuditoria.Datos
{
    public class ActivoDatos
    {

        public List<ActivoModel> Listar()
        {
            var oLista = new List<ActivoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarActivo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ActivoModel()
                        {
                            IdActivo = dr["IdActivo"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Tipo = dr["Nombre"].ToString(),
                            Departamento = dr["Departamento"].ToString(),
                            Clasificacion = dr["Clasificacion"].ToString(),
                            Criticidad = dr["Criticidad"].ToString(),
                            Propietario = dr["Propietario"].ToString(),
                            Custodio = dr["Custodio"].ToString(),
                            Usuarios = dr["Usuarios"].ToString(),
                            Fecha_Ingreso = (dr["Fecha_Ingreso"]).ToString(),
                            Fecha_Salida = (dr["Fecha_Salida"]).ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public ActivoModel Obtener(string IdActivo)
        {

            var oActivo = new ActivoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerActivo", conexion);
                cmd.Parameters.AddWithValue("IdActivo", IdActivo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oActivo.IdActivo = dr["IdActivo"].ToString();
                        oActivo.Nombre = dr["Nombre"].ToString();
                        oActivo.Descripcion = dr["Descripcion"].ToString();
                        oActivo.Tipo = dr["Nombre"].ToString();
                        oActivo.Departamento = dr["Departamento"].ToString();
                        oActivo.Clasificacion = dr["Clasificacion"].ToString();
                        oActivo.Criticidad = dr["Criticidad"].ToString();
                        oActivo.Propietario = dr["Propietario"].ToString();
                        oActivo.Custodio = dr["Custodio"].ToString();
                        oActivo.Usuarios = dr["Usuarios"].ToString();
                        oActivo.Fecha_Ingreso = (dr["Fecha_Ingreso"]).ToString();
                        oActivo.Fecha_Salida = (dr["Fecha_Salida"]).ToString();
                    }
                }
            }
            return oActivo;
        }


        public bool Guardar(ActivoModel oactivo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarActivo", conexion);
                    cmd.Parameters.AddWithValue("IdActivo", oactivo.IdActivo);
                    cmd.Parameters.AddWithValue("Nombre", oactivo.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", oactivo.Descripcion);
                    cmd.Parameters.AddWithValue("Tipo", oactivo.Tipo);
                    cmd.Parameters.AddWithValue("Departamento", oactivo.Departamento);
                    cmd.Parameters.AddWithValue("Clasificacion", oactivo.Clasificacion);
                    cmd.Parameters.AddWithValue("Criticidad", oactivo.Criticidad);
                    cmd.Parameters.AddWithValue("Propietario", oactivo.Propietario);
                    cmd.Parameters.AddWithValue("Custodio", oactivo.Custodio);
                    cmd.Parameters.AddWithValue("Usuarios", oactivo.Usuarios);
                    cmd.Parameters.AddWithValue("Fecha_Ingreso", oactivo.Fecha_Ingreso);
                    cmd.Parameters.AddWithValue("Fecha_Salida", oactivo.Fecha_Salida);
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


        public bool Editar(ActivoModel oactivo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarActivo", conexion);
                    cmd.Parameters.AddWithValue("IdActivo", oactivo.IdActivo);
                    cmd.Parameters.AddWithValue("Nombre", oactivo.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", oactivo.Descripcion);
                    cmd.Parameters.AddWithValue("Tipo", oactivo.Tipo);
                    cmd.Parameters.AddWithValue("Departamento", oactivo.Departamento);
                    cmd.Parameters.AddWithValue("Clasificacion", oactivo.Clasificacion);
                    cmd.Parameters.AddWithValue("Criticidad", oactivo.Criticidad);
                    cmd.Parameters.AddWithValue("Propietario", oactivo.Propietario);
                    cmd.Parameters.AddWithValue("Custodio", oactivo.Custodio);
                    cmd.Parameters.AddWithValue("Usuarios", oactivo.Usuarios);
                    cmd.Parameters.AddWithValue("Fecha_Ingreso", oactivo.Fecha_Ingreso);
                    cmd.Parameters.AddWithValue("Fecha_Salida", oactivo.Fecha_Salida);
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


        public bool Eliminar(string IdActivo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarActivo", conexion);
                    cmd.Parameters.AddWithValue("IdActivo", IdActivo);
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
