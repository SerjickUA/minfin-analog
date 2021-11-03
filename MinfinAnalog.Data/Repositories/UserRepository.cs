using MinfinAnalog.Data.Interfaces;
using MinfinAnalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinfinAnalog.Data.Repositories
{
    class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(MinfinAnalogContext context) : base(context)
        {
            
        }
 
        public MinfinAnalogContext EShoppingTutorialDbContext
        {
            get { return Context as MinfinAnalogContext; }
        }
 
        public override void Add(User entity)
        {

            base.Add(entity);
        } 
    }
}
