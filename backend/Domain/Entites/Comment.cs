using Domain.Common;

namespace Domain.Entites;

public class Comment : BaseEntity
{
    public string? Message { get; set; }
}
