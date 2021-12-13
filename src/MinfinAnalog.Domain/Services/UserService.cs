using AutoMapper;
using MinfinAnalog.Domain.Interfaces;
using MinfinAnalog.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinfinAnalog.Domain.Entities;

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
        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(userId));
        }

        public void Create(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            _userRepository.Add(user);
            _unitOfWork.Save();
        }

        //public Task Delete(UserDto userDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Update(UserDto userDto)
        //{
        //    throw new NotImplementedException();
        //}

        // TODO UserService: Implement async methods

    }
}
