﻿using Application.Common.Interfaces.Mappings;
using AutoMapper;
using Domain.Models;

namespace Application.Common.DTO;

public class CreateChatResponseDto : IMapTo<ChatResponse>
{
    public int MessageId { get; set; }
    public string BotResponse { get; set; } = string.Empty;

    void IMapTo<ChatResponse>.Mapping(Profile profile)
    {
        _ = profile.CreateMap<CreateChatResponseDto, ChatResponse>()
            .ForMember(dst => dst.Id, opt => opt.Ignore())
            .ForMember(dst => dst.Created, opt => opt.Ignore())
            .ForMember(dst => dst.Rating, opt => opt.Ignore())
            .ForMember(dst => dst.Message, opt => opt.Ignore());
    }
}
