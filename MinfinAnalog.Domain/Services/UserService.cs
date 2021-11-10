using AutoMapper;
using MinfinAnalog.Domain.Interfaces;
using MinfinAnalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinfinAnalog.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _userRepository.GetAllAsync());
            //throw new NotImplementedException();
        }
        public async Task<UserDto> GetUserById(int userId)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(userId));
        }

        //public Task<UserDto> Create(UserDto userDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Delete(UserDto userDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Update(UserDto userDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
