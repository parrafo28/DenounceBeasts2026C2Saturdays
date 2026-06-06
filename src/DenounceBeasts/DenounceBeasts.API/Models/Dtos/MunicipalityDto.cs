using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenounceBeasts.API.Models.Entities
{
    public class MunicipalityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public bool IsActive { get; set; }
        public List<SectorDto> Sectors { get; set; }
    }
}
