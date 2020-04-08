using Be.The.Hero.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Be.The.Hero.Api.Interfaces.Services
{
    public interface IOngService
    {
        Task<Ong> InsertAsync(Ong entity);
        Task<IEnumerable<Ong>> SelectAllAsync();
        Task<Ong> SelectByIdAsync(string id);
    }
}
