using Be.The.Hero.Api.Models;
using Be.The.Hero.Api.Models.ValueObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Be.The.Hero.Api.Interfaces.Repositories
{
    public interface IIncidentRepository : IRepository<Incident, int>
    {
        Task<IEnumerable<IncidentWithOngValueObject>> SelectWithOngPaginatedAsync(int page = 1);
        Task<int> CountAllWithOngAsync();
    }
}
