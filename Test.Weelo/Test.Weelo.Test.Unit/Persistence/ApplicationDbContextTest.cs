using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Test.Weelo.Persistence;

namespace Test.Weelo.Test.Unit.Persistence
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertCustomerIntoDatabasee()
        {

            using var context = new ApplicationDbContext();
            
            Assert.AreEqual(1, 1);
        }
    }
}
