using DevFreela.Application.ViewModels.ProjectViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        private readonly DevFreelaDbContext _contex;

        public GetProjectByIdQueryHandler(DevFreelaDbContext contex)
        {
            _contex = contex;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var projects =  await _contex.Projects
                .Include(x => x.Client)
                .Include(x => x.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == request.Id);

            if (projects == null)
            {
                return null;
            }

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                projects.Id,
                projects.Title,
                projects.Description,
                projects.TotalCost,
                projects.StartedAt,
                projects.FinishedAt,
                projects.Client.Name,
                projects.Freelancer.Name);

            return projectDetailsViewModel;
        }
    }
}
