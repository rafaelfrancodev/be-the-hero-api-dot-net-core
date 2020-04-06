using System;

namespace Be.The.Hero.Api.Services
{
    public static class GenerateUniqueIdService
    {
        public static string Generate()
        {
            var guid = Guid.NewGuid();
            var hash = guid.ToString().Split('-')[0];
            return hash;
        }
    }
}
