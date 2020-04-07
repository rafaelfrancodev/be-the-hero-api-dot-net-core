using System.Text.Json.Serialization;

namespace Be.The.Hero.Api.Models.ValueObject
{
    public class IncidentWithOngValueObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        [JsonPropertyName("ong_id")]
        public string OngId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }
    }
}
