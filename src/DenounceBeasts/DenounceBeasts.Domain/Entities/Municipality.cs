using DenounceBeasts.Domain.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenounceBeasts.Domain.Entities
{
    //[Table("MUNICIPALITY")]
    public class Municipality: BaseEntity
    {
        //[Key]
        //[Column("MUNICIPALITY_ID")]
        //public int MunicipalityId { get; set; }
        //public int Id { get; set; }
        //[Column("MUNICIPALITY_NAME")]
        //[StringLength(100, ErrorMessage= "Error Lenght",MinimumLength= 1)]
        public string Name { get; set; }
        //[Column("MUNICIPALITY_POSTAL_CODE")]
        //[MaxLength(6)]
        //[MinLength(1)]
        public string PostalCode { get; set; }
        //[Column("MUNICIPALITY_IS_ACTIVE")]
        public bool IsActive { get; set; }

        //[EmailAddress]
        //public string Email { get; set; }
        public List<Sector> Sectors { get; set; }
    }
}
