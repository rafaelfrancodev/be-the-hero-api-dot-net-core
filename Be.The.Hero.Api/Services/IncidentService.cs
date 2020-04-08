using Be.The.Hero.Api.Interfaces.Repositories;
using Be.The.Hero.Api.Interfaces.Services;
using Be.The.Hero.Api.Models;
using Be.The.Hero.Api.Models.ValueObject;
using System.Collections.Generic;
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

        public async Task<int> CountAllWithOngAsync()
        {
            return await _incidentRepository.CountAllWithOngAsync();
        }

        public async Task<bool> DeleteAsync(int id, string ongId)
        {
            var incident = await _incidentRepository.SelectByIdAsync(id);

            if(incident != null && incident.OngId == ongId)
            {
                return await _incidentRepository.DeleteAsync(id);
            }

            return false;

        }

        public async Task<Incident> InsertAsync(Incident entity)
        {
            return await _incidentRepository.InsertAsync(entity).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Incident>> SelectAllByOngAsync(string ongId)
        {
            return await _incidentRepository.SelectFilterAsync(x => x.OngId == ongId);             
        }

        public async Task<IEnumerable<IncidentWithOngValueObject>> SelectWithOngPaginatedAsync(int page = 1)
        {
            return await _incidentRepository.SelectWithOngPaginatedAsync(page);
        }
    }
}
