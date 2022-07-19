using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {

        private readonly DevFreelaDbContext _contex;

        public DeleteProjectCommandHandler(DevFreelaDbContext contex)
        {
            _contex = contex;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _contex.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.CancelProject();

            await _contex.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
