using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Moq;
using System;

namespace Tests
{
    public class ODataTestes
    {
        protected ODataContext context;

        protected ODataTestes()
        {
            context = CreateContext();
        }

        private ODataContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ODataContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
               .Options;

            var configuration = new Mock<IConfiguration>();

            return new ODataContext(configuration.Object, options);
        }
    }
}
