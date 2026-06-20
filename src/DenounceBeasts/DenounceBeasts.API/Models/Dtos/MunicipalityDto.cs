namespace DenounceBeasts.API.Models.Dtos
{
    public class MunicipalityDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public bool IsActive { get; set; }
        public List<SectorDto> Sectors { get; set; }
    }
}
