using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Features.Rents
{
    public interface IRentRepository
    {
        Rent Save(Rent rent);
        Rent Update(Rent rent);
        Rent Get(long id);
        IEnumerable<Rent> GetAll();
        void Delete(Rent rent);
    }
}
