using System;
using Xunit;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shop.IntegrationTests
{
    public class DataOperationsTests
    {
        [Fact]
        public void CanInsertProductIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertProduct");

            using (var context = new AppDbContext())
            {
                var product = new Product();
                context.Products.Add(product);
                //Assert.AreEqual(EntityState.Added, context.Entry(product).State);
            };
        }
    }
}
