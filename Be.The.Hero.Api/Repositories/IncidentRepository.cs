using Be.The.Hero.Api.Config;
using Be.The.Hero.Api.Interfaces.Repositories;
using Be.The.Hero.Api.Models;
using Be.The.Hero.Api.Models.ValueObject;
using Be.The.Hero.Api.Repositories.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Be.The.Hero.Api.Repositories
{
    public  class IncidentRepository : GenericRepository<Incident, int>, IIncidentRepository
    {
        public IncidentRepository(BeTheHeroSQLiteContext context) : base (context)
        {
            _context = context;
        }

        public async Task<int> CountAllWithOngAsync()
        {
            var query = from inc in _context.Incidents 
                        join ong in _context.Ongs on inc.OngId equals ong.Id  
                        select inc;
            var total = await query.CountAsync();
            return total;
        }

        public async Task<IEnumerable<IncidentWithOngValueObject>> SelectWithOngPaginatedAsync(int page = 1)
        {
            var totalPage = 5;
            var totalPagination = (page - 1) * totalPage;

            var query = from inc in _context.Incidents
                        join ong in _context.Ongs on inc.OngId equals ong.Id
                        select new IncidentWithOngValueObject
                        {
                            Id = inc.Id,
                            Title = inc.Title,
                            Description = inc.Description,
                            Value = inc.Value,
                            OngId = inc.OngId,
                            Name = ong.Name,
                            City = ong.City,
                            Email = ong.Email,
                            Uf = ong.Uf,
                            Whatsapp = ong.Whatsapp
                        };
            var result = await query.Skip(totalPagination).Take(totalPage).ToListAsync();
            return result;
        }
    }
}
