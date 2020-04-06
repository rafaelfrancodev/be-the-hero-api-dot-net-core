using Be.The.Hero.Api.Config;
using Be.The.Hero.Api.Interfaces.Repositories;
using Be.The.Hero.Api.Models;
using Be.The.Hero.Api.Repositories.Generic;

namespace Be.The.Hero.Api.Repositories
{
    public class IncidentRepository : GenericRepository<Incident, int>, IIncidentRepository
    {
        public IncidentRepository(BeTheHeroSQLiteContext context) : base (context)
        {}
    }
}
