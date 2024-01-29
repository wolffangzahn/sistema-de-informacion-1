using Prueba.Models;

namespace Prueba.Business.contract
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetNombreUsuario(string nombreusuario);
        //Task<List<Usuario>> GetList();
      //  Task<Usuario> AgregaActualiza(Usuario l, string t);
    }
}
