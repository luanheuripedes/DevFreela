using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler: IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _contex;

        public CreateCommentCommandHandler(DevFreelaDbContext contex)
        {
            _contex = contex;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);
            await _contex.ProjectsComments.AddAsync(comment);
            await _contex.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
