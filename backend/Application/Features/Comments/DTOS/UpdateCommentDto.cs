namespace Application.Features.Comments.DTOS;

public class UpdateCommentDto : ICommentDto
{
     public int Id { get; set; }
    public string? Message { get; set; }
}
