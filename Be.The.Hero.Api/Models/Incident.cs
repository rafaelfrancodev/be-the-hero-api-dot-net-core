using Be.The.Hero.Api.Models.Base;

namespace Be.The.Hero.Api.Models
{
    public class Incident: BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Value  { get; set; }
        public string OngId { get; set; }
    }
}
