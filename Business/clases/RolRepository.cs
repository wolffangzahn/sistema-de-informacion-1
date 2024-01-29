using Prueba.Business.contract;
using Prueba.Models;
using System.Data;
using System.Data.SqlClient;

namespace Prueba.Business.clases
{
    public class RolRepository : IRolRepository
    {
        private readonly string connect;
        public RolRepository(IConfiguration _IConfiguration)
        {
            connect = _IConfiguration.GetConnectionString("conBase");
        }
        public async Task<List<Rol>> GetList()
        {
            List<Rol> list = new List<Rol>();
            Rol l;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from Rol", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        l = new Rol();
                        l.Id = Convert.ToInt32(reader["Id"]);
                        l.NombreRol = Convert.ToString(reader["NombreRol"]);

                        list.Add(l);
                    }
                }
            }
            return list;
        }
        public async Task<Rol> AgregaActualiza(Rol l, string t)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string cadena = "";
                if (t == "c")
                    cadena = "set @I=(select isnull(max(Id),0)+1 from Rol)" + 
                        "insert into rol(NombreRol) values(@NombreRol)";
                if (t == "u")
                    cadena = "update Rol set NombreRol=@NombreRol where Id=@Id;";
                using (SqlCommand cmd = new SqlCommand(cadena, conn))
                {
                    SqlParameter Result = new SqlParameter("@I", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(Result);
                    cmd.Parameters.AddWithValue("@Id", l.Id);
                    cmd.Parameters.AddWithValue("@NombreRol", l.NombreRol);
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    if (t == "c")
                        l.Id = int.Parse(Result.Value.ToString());

                }
            }
            return l;
        }
    }
}
