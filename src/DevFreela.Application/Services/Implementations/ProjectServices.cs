using Dapper;
using DevFreela.Application.InputModels.ProjectInputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.ProjectViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectServices : IProjectServices
    {
        private readonly DevFreelaDbContext _contex;
        private readonly string _connectionString;
        public ProjectServices(DevFreelaDbContext contex, IConfiguration configuration)
        {
            _contex = contex;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public void Finish(int id)
        {
            var project = _contex.Projects.SingleOrDefault(p => p.Id == id);
            project.FinishProject();
            _contex.SaveChanges();
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var projects = _contex.Projects
                .Include(x => x.Client)
                .Include(x => x.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            if(projects == null)
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

        public void Start(int id)
        {
            var project = _contex.Projects.SingleOrDefault(p => p.Id == id);

            project.StartProject();
            //_contex.SaveChanges();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var sql = "UPDATE Projects SET Status = @status, StartedAt = @startedat Where Id = @id";

                sqlConnection.Execute(sql, new { status = project.Status, startedat = project.StartedAt, id = id});

                sqlConnection.Close();

            }
        }

    }
}
