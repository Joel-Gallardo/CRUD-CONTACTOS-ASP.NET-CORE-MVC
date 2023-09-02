using CRUDCORE.Models;
using System.Data.SqlClient; //nos permite utilizar los objetos y clases de sql
using System.Data;

namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> listarContactos()
        {
            var objectLista = new List<ContactoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL() ))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarContactos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objectLista.Add(new ContactoModel() {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }

            return objectLista;
        }


        public ContactoModel obtenerContactoById(int IdContacto)
        {
            var objetoContacto = new ContactoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerContactoById", conexion);
                cmd.Parameters.AddWithValue("IdContacto",IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objetoContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        objetoContacto.Nombre = dr["Nombre"].ToString();
                        objetoContacto.Telefono = dr["Telefono"].ToString();
                        objetoContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }

            return objetoContacto;
        }

        public bool gardarContacto(ContactoModel objetoContacto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarContacto", conexion);
                    cmd.Parameters.AddWithValue("Nombre",objetoContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono",objetoContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo",objetoContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string msgError = e.Message;
                respuesta=false;
            }

            return respuesta;
        }

        public bool editarContacto(ContactoModel objetoContacto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarContacto", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", objetoContacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", objetoContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", objetoContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", objetoContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string msgError = e.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool eliminarContacto(int idContacto)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarContacto", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", idContacto);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string msgError = e.Message;
                respuesta = false;
            }

            return respuesta;
        }


    }
}
