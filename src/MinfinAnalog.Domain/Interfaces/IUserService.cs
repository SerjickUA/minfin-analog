using MinfinAnalog.Domain.DTOs;

namespace MinfinAnalog.Domain.Interfaces;
public interface IUserService
{
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUserById(int userId);
        //Task<UserDto> Create(UserDto userDto);
        //Task Update(UserDto userDto);
        //Task Delete(UserDto userDto);
}

