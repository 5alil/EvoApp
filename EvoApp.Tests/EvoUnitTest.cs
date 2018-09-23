using EvoApp.UI.Controllers;
using EvoApp.UI.Repositories;
using Moq;
using System.Linq;
using Xunit;

namespace EvoApp.Tests
{
    public class EvoUnitTest
    {
        private Mock<IEvoRepository> evoRepositoryMock;
        private EvoController controller;
        public EvoUnitTest()
        {
            evoRepositoryMock = new Mock<IEvoRepository>();
            controller = new EvoController(evoRepositoryMock.Object);
        }
        [Fact]
        public void TestInsertEvo()
        {
            controller.AddEvo(new UI.Services.Dto.EvoDto()
            {
                Name = "Unit Test",
                IsActive = true,
                IsDeleted = false
            });
        }
    }
}
