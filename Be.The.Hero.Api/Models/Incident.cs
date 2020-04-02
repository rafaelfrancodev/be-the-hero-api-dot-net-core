namespace Be.The.Hero.Api.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Value  { get; set; }
        public string OngId { get; set; }
    }
}
