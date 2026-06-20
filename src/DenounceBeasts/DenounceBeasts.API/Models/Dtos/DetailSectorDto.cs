using DenounceBeasts.API.Models.Dtos;

namespace DenounceBeasts.API.Models.Dtos
{
    public class DetailSectorDto: BaseDto
    {
        //public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int MunicipalityId { get; set; }
        public bool IsActive { get; set; }
        public string MunicipalityName { get; set; }
        //public MunicipalityDto Municipality { get; set; }
        public string RandomInfo { get; set; }

    }
}
