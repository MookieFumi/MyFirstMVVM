using System.Threading.Tasks;
using MyFirstMVVM.Models;

namespace MyFirstMVVM.Services
{
    public interface IBreweriesService
    {
        Task<Result<BreweryDTO>> GetBreweriesAsync(int established = 2017, int page = 1);
    }
}
