using Be.The.Hero.Api.Models.Base;

namespace Be.The.Hero.Api.Models
{
    public class Ong: BaseEntity<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }
    }
}
