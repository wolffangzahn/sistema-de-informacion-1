using Prueba.Models;
using Prueba.Services;

namespace Prueba.Services.contrac
{
    public interface IRolService
    {
        Task<List<Rol>> GetList();
        Task<Rol> AgregaActualiza(Rol l, string t);
    }


}
