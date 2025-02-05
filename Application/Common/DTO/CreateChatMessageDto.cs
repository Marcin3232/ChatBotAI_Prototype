using Application.Common.Interfaces.Mappings;
using AutoMapper;
using Domain.Models;

namespace Application.Common.DTO;

public class CreateChatMessageDto : IMapTo<ChatMessage>
{
    public int UserId { get; set; } = 0;

    public string UserMessage { get; set; } = string.Empty;

    void IMapTo<ChatMessage>.Mapping(Profile profile)
    {
        _ = profile.CreateMap<CreateChatMessageDto, ChatMessage>()
            .ForMember(dst => dst.UserMessage, opt => opt.Ignore())
            .ForMember(dst => dst.User, opt => opt.Ignore())
            .ForMember(dst => dst.Id, opt => opt.Ignore())
            .ForMember(dst => dst.Created, opt => opt.Ignore())
            .ForMember(dst => dst.Responses, opt => opt.Ignore());
    }
}
