using MinfinAnalog.Data.Interfaces;
using MinfinAnalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MinfinAnalog.Data.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(MinfinAnalogContext context) : base(context)
        {
        }
 
        public MinfinAnalogContext MinfinAnalogContext
        {
            get { return Context as MinfinAnalogContext; }
        }

        //public override async Task<IEnumerable<User>> GetUsers()
        //{
        //    return await _context.Users.ToListAsync();
        //}

        public override void Add(User entity)
        {
            base.Add(entity);
        } 
    }
}
