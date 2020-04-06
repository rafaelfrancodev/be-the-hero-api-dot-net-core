using Be.The.Hero.Api.Interfaces.Repositories;
using Be.The.Hero.Api.Interfaces.Services;
using Be.The.Hero.Api.Models;
using System.Threading.Tasks;

namespace Be.The.Hero.Api.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;

        public IncidentService(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<Incident> InsertAsync(Incident entity)
        {
            return await _incidentRepository.InsertAsync(entity).ConfigureAwait(false);
        }
    }
}
