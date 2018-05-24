using Biblioteca.Exceptions;
using Biblioteca.Features.Rents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Applications.Features.Rents
{
    public class RentService : IRentService
    {
        IRentRepository _rentRepository;

        public RentService(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public Rent Add(Rent rent)
        {
            rent.Validate();
            return _rentRepository.Save(rent);
        }

        public void Delete(Rent rent)
        {
            if (rent.Id == 0)
                throw new IdentifierUndefinedException();

            _rentRepository.Delete(rent);
        }

        public Rent Get(Rent rent)
        {
            if (rent.Id == 0)
                throw new IdentifierUndefinedException();

            return _rentRepository.Get(rent.Id);
        }

        public IEnumerable<Rent> GetAll()
        {
            return _rentRepository.GetAll();
        }

        public Rent Update(Rent rent)
        {
            rent.Validate();
            return _rentRepository.Update(rent);
        }
    }
}
