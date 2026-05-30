namespace DenounceBeasts.API.Models.Entities
{
    public class Municipality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public bool IsActive { get; set; }
        public List<Sector> Sectors { get; set; }
    }
}
