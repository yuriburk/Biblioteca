using Biblioteca.Common.Tests.Base;
using Biblioteca.Features.Books;
using Biblioteca.Features.Rents;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Tests.Features.Rents
{
    [TestFixture]
    public class RentTest
    {
        Rent _rent;

        [SetUp]
        public void Initialize()
        {
            _rent = new Rent();
        }
    }
}
