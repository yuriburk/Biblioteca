using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Rents
{
    public interface IRentService
    {
        Rent Add(Rent rent);
        Rent Update(Rent rent);
        Rent Get(Rent rent);
        IEnumerable<Rent> GetAll();
        void Delete(Rent rent);
    }
}
