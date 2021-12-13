using MinfinAnalog.Domain.Interfaces;

namespace MinfinAnalog.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MinfinAnalogContext _context;

        public UnitOfWork(MinfinAnalogContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
