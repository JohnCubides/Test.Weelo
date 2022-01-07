using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Persistence;

namespace Test.Weelo.Test.Unit.Persistence
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertOwnerIntoDatabasee()
        { 
            using var context = new ApplicationDbContext();
            OwnerEntity owner = new OwnerEntity();
            context.Owner.Add(owner);
            Assert.AreEqual(EntityState.Added, context.Entry(owner).State);
        }

        [Test]
        public void CanInserPropertyIntoDatabasee()
        {
            using var context = new ApplicationDbContext();
            PropertyEntity property = new PropertyEntity();
            context.Property.Add(property);
            Assert.AreEqual(EntityState.Added, context.Entry(property).State);
        }

        [Test]
        public void CanInserPropertyImageIntoDatabasee()
        {
            using var context = new ApplicationDbContext();
            PropertyImageEntity propertyImage = new PropertyImageEntity();
            context.PropertyImage.Add(propertyImage);
            Assert.AreEqual(EntityState.Added, context.Entry(propertyImage).State);
        }

        [Test]
        public void CanInserPropertyTraceIntoDatabasee()
        {
            using var context = new ApplicationDbContext();
            PropertyTraceEntity propertyTrace = new PropertyTraceEntity();
            context.PropertyTrace.Add(propertyTrace);
            Assert.AreEqual(EntityState.Added, context.Entry(propertyTrace).State);
        }
    }
}
