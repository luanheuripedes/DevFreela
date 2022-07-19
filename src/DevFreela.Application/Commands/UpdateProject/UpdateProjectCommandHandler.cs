using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _contex;

        public UpdateProjectCommandHandler(DevFreelaDbContext contex)
        {
            _contex = contex;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _contex.Projects.SingleOrDefault(p => p.Id == request.Id);
            project.Update(request.Title, request.Description, request.TotalCost);

           await _contex.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
