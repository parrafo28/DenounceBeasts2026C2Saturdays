namespace DenounceBeasts.Domain.Contracts
{
    public interface IAuditeEntity
    {
         DateTime CreatedAt { get; set; }
         DateTime UpdatedAt { get; set; }
         DateTime? DeletedAt { get; set; }

        string MakeSomeAuditeInfo();
    }
}
