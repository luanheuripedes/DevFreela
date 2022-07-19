using DevFreela.Application.ViewModels.ProjectViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _contex;

        public GetAllProjectsQueryHandler(DevFreelaDbContext contex)
        {
            _contex = contex;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _contex.Projects;

            var projectsViewModel = await projects
                .Select(p => new ProjectViewModel(p.Title, p.CreatedAt, p.Id)).ToListAsync();

            return projectsViewModel;
        }
    }
}
