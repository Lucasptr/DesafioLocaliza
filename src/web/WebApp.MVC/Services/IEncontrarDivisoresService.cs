using System.Threading.Tasks;
using WebApp.MVC.Models;

namespace WebApp.MVC.Services
{
    public interface IEncontrarDivisoresService
    {
        Task<DivisoresNumero> RetornarDivisoresNumero(int numeroBase);
    }
}
