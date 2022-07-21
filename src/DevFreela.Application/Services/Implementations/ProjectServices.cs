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

    }
}
