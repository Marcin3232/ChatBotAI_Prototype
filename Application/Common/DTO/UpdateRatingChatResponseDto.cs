using Application.Common.Interfaces.Mappings;
using Domain.Models;


namespace Application.Common.DTO;

public class UpdateRatingChatResponseDto : IMapTo<ChatResponse>
{
    public int Id { get; set; }
    public int? Rating { get; set; }

    void IMapTo<ChatResponse>.Mapping(AutoMapper.Profile profile)
    {
        _ = profile.CreateMap<UpdateRatingChatResponseDto, ChatResponse>()
            .ForMember(dst => dst.Id, opt => opt.Ignore())
            .ForMember(dst => dst.Created, opt => opt.Ignore())
            .ForMember(dst => dst.MessageId, opt => opt.Ignore())
            .ForMember(dst => dst.Message, opt => opt.Ignore())
            .ForMember(dst => dst.BotResponse, opt => opt.Ignore());
    }
}