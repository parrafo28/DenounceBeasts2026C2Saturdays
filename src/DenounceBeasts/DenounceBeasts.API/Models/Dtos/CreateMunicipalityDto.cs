using System.ComponentModel.DataAnnotations;

namespace DenounceBeasts.API.Models.Entities
{
    public class CreateMunicipalityDto
    { 
        public string Name { get; set; }
        public string PostalCode { get; set; }
    }
}
