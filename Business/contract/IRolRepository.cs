using Prueba.Models;

namespace Prueba.Business.contract
{
    public interface IRolRepository
    {
        Task<Rol> AgregaActualiza(Rol l, string t);
        Task<List<Rol>> GetList();
    }
}
