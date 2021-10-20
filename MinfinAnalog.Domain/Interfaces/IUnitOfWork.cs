using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinfinAnalog.Domain.Interfaces
{
    interface IUnitOfWork
    {
        int Save();
    }
}
