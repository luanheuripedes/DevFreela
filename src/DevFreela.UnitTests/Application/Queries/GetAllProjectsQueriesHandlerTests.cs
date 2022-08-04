using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQueriesHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {

            //Arrange
            var projects = new List<Project>
            {
                new Project("Nome Do Teste 1", "Descrição De Teste 1", 1,2,10000),
                new Project("Nome Do Teste 2", "Descrição De Teste 2", 1,2,20000),
                new Project("Nome Do Teste 3", "Descrição De Teste 3", 1,2,30000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(x => x.GetAllAsync().Result).Returns(projects);

            var getAllProjectQuery = new GetAllProjectsQuery("");
            var getAllProjectQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModelList = await getAllProjectQueryHandler.Handle(getAllProjectQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
