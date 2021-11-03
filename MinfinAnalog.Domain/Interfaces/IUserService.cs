using MinfinAnalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MinfinAnalog.Domain.Interfaces
{
    public interface IUserService
    {
            Task<IEnumerable<UserDto>> GetUsers();
            Task<UserDto> GetUserById(int userId);
            //Task<UserDto> Create(UserDto userDto);
            //Task Update(UserDto userDto);
            //Task Delete(UserDto userDto);
    }
}
