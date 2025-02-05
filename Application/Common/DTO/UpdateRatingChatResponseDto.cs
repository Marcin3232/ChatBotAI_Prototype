using Application.Common.Interfaces.Mappings;
using Domain.Models;


namespace Application.Common.DTO;

public class UpdateRatingChatResponseDto : IMapTo<ChatResponse>
{
    public int Id { get; set; }
    public int? Rating { get; set; }
}
