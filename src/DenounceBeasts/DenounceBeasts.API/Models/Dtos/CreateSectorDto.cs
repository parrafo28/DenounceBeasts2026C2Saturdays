namespace DenounceBeasts.API.Models.Entities
{
    public class CreateSectorDto
    { 
        public string Name { get; set; } = null!;
        public int MunicipalityId { get; set; } 
    }
}
