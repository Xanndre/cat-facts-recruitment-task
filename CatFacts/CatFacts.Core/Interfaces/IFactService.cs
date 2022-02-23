using CatFacts.Core.Models;
using System.Threading.Tasks;

namespace CatFacts.Core.Interfaces
{
    public interface IFactService
    {
        Task<CatFact> GetFact();
    }
}
