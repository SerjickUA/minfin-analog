using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinfinAnalog.Data.Interfaces
{
    public interface IUnitOfWork
    {
        int Save();
    }
}
