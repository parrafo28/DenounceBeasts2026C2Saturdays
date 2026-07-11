using DenounceBeasts.Domain.Core;

namespace DenounceBeasts.Domain.Entities
{
    public class Status : BaseEntity//, INameBaseEntity//, IAuditeEntity
    {
        //public int Id { get; set; }
        public string Name { get ; set ; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        //public DateTime? DeletedAt { get; set; }

        //public string MakeSomeAuditeInfo()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
