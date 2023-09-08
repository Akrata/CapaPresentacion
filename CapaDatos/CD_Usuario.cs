using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using(SqlConnection con = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "select id_usr,nro_dcm_usr,nmb_cmp_usr,eml_usr, psw_usr, est_usr from t_usr";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario {
                                IdUsuario = Convert.ToInt32(reader["id_usr"]),
                                Documento = reader["nro_dcm_usr"].ToString(),
                                NombreCompleto = reader["nmb_cmp_usr"].ToString(),
                                Correo = reader["eml_usr"].ToString(),
                                Clave = reader["psw_usr"].ToString(),
                                Estado = Convert.ToBoolean(reader["est_usr"])

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>();
                }
                
                return lista;
            }
        }

        
    }
}
