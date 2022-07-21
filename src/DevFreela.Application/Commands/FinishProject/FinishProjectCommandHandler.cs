using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _contex;

        public FinishProjectCommandHandler(DevFreelaDbContext contex)
        {
            _contex = contex;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _contex.Projects.SingleOrDefault(p => p.Id == request.Id);
            project.FinishProject();
            await _contex.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
