using Be.The.Hero.Api.Models;
using System.Threading.Tasks;

namespace Be.The.Hero.Api.Interfaces.Services
{
    public interface IIncidentService
    {
        Task<Incident> InsertAsync(Incident entity);
    }
}
