using MinfinAnalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinfinAnalog.Domain.Interfaces
{
    interface IUserService
    {
            Task<IEnumerable<UserDTO>> GetUserList();
            Task<UserDTO> GetUserById(int userId);
            Task<UserDTO> Create(UserDTO userModel);
            Task Update(UserDTO userModel);
            Task Delete(UserDTO userModel);
    }
}
