using MinfinAnalog.Domain.Entities;
using MinfinAnalog.Domain.Interfaces;

namespace MinfinAnalog.Data.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(MinfinAnalogContext context) : base(context)
        {
        }
 
        public MinfinAnalogContext MinfinAnalogContext
        {
            get { return Context as MinfinAnalogContext ?? throw new ArgumentNullException(nameof(Context)); }
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
