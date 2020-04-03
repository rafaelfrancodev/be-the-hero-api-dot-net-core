using Be.The.Hero.Api.Interfaces.Repositories;
using Be.The.Hero.Api.Interfaces.Services;
using Be.The.Hero.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Be.The.Hero.Api.Services
{
    public class OngService: IOngService
    {
        private readonly IOngRepository _ongRepository;

        public OngService(IOngRepository ongRepository)
        {
            _ongRepository = ongRepository;
        }

        public async Task<Ong> InsertAsync(Ong entity)
        {
            return await _ongRepository.InsertAsync(entity).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Ong>> SelectAllAsync()
        {
            return await _ongRepository.SelectAllAsync().ConfigureAwait(false);
        }
    }
}
