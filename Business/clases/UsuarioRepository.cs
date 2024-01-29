using Prueba.Business.contract;
using Prueba.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Business.clases
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string connec;
        public UsuarioRepository(IConfiguration _IConfiguration)
        {
            connec = _IConfiguration.GetConnectionString("conBase");
        }
        public async Task<Usuario> GetNombreUsuario(string nombreusuario)
        {
            List<string> list = new List<string>();
            Usuario oUsuario = new Usuario();
            using (SqlConnection conn = new SqlConnection(connec))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("Select * from trnUsuario where Nombreusuario='"+ nombreusuario+ "';", conn);
                using (var reader =await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        oUsuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString());
                        oUsuario.NombreUsuario = reader["NombreUsuario"].ToString();
                        oUsuario.Clave = reader["Clave"].ToString();
                        oUsuario.Salt = reader["Salt"].ToString();
                    }
                }
            }
            return oUsuario;
        }
      
        }
}
