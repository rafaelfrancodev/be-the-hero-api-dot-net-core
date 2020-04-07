using Be.The.Hero.Api.Models;
using Be.The.Hero.Api.Models.ValueObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Be.The.Hero.Api.Interfaces.Services
{
    public interface IIncidentService
    {
        Task<Incident> InsertAsync(Incident entity);
        Task<IEnumerable<IncidentWithOngValueObject>> SelectWithOngPaginatedAsync(int page = 1);
        Task<int> CountAllWithOngAsync();
        Task<bool> DeleteAsync(int id, string ongId);
    }
}
