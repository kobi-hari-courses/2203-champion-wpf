using System.Threading.Tasks;

namespace FunWithMvvm.Services
{
    public interface ITitleService
    {
        Task<string> GetTitle();
    }
}