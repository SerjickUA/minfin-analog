using MinfinAnalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MinfinAnalog.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MinfinAnalogContext _context;

        public UnitOfWork(MinfinAnalogContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
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
