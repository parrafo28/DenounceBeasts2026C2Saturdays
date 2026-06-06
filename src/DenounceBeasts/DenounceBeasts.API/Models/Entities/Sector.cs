namespace DenounceBeasts.API.Models.Entities
{
    public class Sector
    {
        //public int SectorId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int MunicipalityId { get; set; }
         public Municipality Municipality { get; set; }
        public bool IsActive { get; set; }
    }
}
