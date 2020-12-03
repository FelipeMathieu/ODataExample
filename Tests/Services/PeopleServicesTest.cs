using FluentAssertions;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests.Services
{
    public class PeopleServicesTest : ODataTestes
    {
        private readonly IPeopleServices peopleService;
        private readonly List<People> peopleData = new List<People>()
        {
            new People()
            {
                Id = 1,
                Name = "Han Solo"
            },
            new People()
            {
                Id = 2,
                Name = "Leia"
            },
            new People()
            {
                Id = 3,
                Name = "Yoda"
            }
        };

        public PeopleServicesTest()
        {
            peopleService = new PeopleServices(context);
            InsertDummyData();
        }

        [Fact]
        [Description("Should receive correct IQueryable as response")]
        public void ShouldCheckIQueryable()
        {
            var result = peopleService.GetAll();

            result.Should().BeEquivalentTo(peopleData.AsQueryable());
        }

        private void InsertDummyData()
        {
            context.AddRange(peopleData);
            context.SaveChanges();
        }
    }
}
