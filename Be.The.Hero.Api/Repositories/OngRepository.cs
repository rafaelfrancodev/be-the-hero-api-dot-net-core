using Be.The.Hero.Api.Config;
using Be.The.Hero.Api.Interfaces.Repositories;
using Be.The.Hero.Api.Models;
using Be.The.Hero.Api.Repositories.Generic;

namespace Be.The.Hero.Api.Repositories
{
    public class OngRepository : GenericRepository<Ong, string>, IOngRepository
    {
        public OngRepository(BeTheHeroSQLiteContext context) : base (context)
        {}
    }
}
