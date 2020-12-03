using FizzWare.NBuilder;
using FluentAssertions;
using Models;
using Moq;
using ODataTest.Controllers;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests.Controllers
{
    public class PeopleControllerTest
    {
        private readonly PeopleController peopleController;
        private readonly Mock<IPeopleServices> peopleService;

        public PeopleControllerTest()
        {
            peopleService = new Mock<IPeopleServices>();
            peopleController = new PeopleController(peopleService.Object);
        }

        [Fact]
        [Description("Should call people services get all")]
        public void ShouldCallPeopleServiceGetAll()
        {
            StubPeopleServiceGetAll();

            peopleController.GetAll();

            peopleService.Verify(ps => ps.GetAll(), Times.Once);
        }

        private void StubPeopleServiceGetAll()
        {
            peopleService
                .Setup(ps => ps.GetAll())
                .Returns(Builder<People>.CreateListOfSize(5).All().Build().AsQueryable());
        }
    }
}
