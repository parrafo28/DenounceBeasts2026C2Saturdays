using System.ComponentModel.DataAnnotations;

namespace DenounceBeasts.API.Models.Entities
{
    public class UpdateMunicipalityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public bool IsActive { get; set; }
    }
}
