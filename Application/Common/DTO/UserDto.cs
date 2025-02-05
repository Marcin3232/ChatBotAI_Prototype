using Application.Common.Interfaces.Mappings;
using Domain.Models;

namespace Application.Common.DTO;

public class UserDto : IMapFrom<User>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
