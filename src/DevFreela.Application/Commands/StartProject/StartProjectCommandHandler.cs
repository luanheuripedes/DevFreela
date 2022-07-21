using Dapper;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _contex;
        private readonly string _connectionString;

        public StartProjectCommandHandler(DevFreelaDbContext contex, IConfiguration configuration)
        {
            _contex = contex;
            _connectionString = configuration.GetConnectionString("DevFreelaCs"); 
        }

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _contex.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.StartProject();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                await sqlConnection.OpenAsync();

                var sql = "UPDATE Projects SET Status = @status, StartedAt = @startedat Where Id = @id";

                await sqlConnection.ExecuteAsync(sql, new { status = project.Status, startedat = project.StartedAt, id = project.Id });

                await sqlConnection.CloseAsync();

                return Unit.Value;
            }
        }
    }
}
