namespace Application.Features.Comments.DTOS;

public class CreateCommentDto : ICommentDto
{
    public string? Message { get; set; }
}
