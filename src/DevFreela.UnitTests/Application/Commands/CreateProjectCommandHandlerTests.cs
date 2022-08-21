using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDateIsOk_Executed_ReturnProjectId()
        {
            //Arrange
            //var projectRepository = new Mock<IProjectRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Titulo de Teste",
                Description= "dESCRICAO DA HORA",
                TotalCost = 50000,
                IdClient = 1,
                IdFreelancer = 2
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(unitOfWork.Object);


            //Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());


            //Assert
            Assert.True(id >= 0);

            unitOfWork.Verify(pr => pr.Projects.CreateProjectAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
