﻿using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Repositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly DevFreelaDbContext _context;
        private readonly string _connectionString;

        public ProjectRepository(DevFreelaDbContext context,IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DevFreelaDbContext");
        }

        public async Task CreateCommentAsync(ProjectComment comment)
        {
            await _context.ProjectsComments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task CreateProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Project project)
        {
             _context.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task FinishProjectAsync(Project project)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var script = "UPDATE Projects SET Status = @status WHERE Id = @id;";

                await sqlConnection.ExecuteAsync(script, new { status = project.Status, id = project.Id });
            }
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
           return await _context.Projects
               .Include(x => x.Client)
               .Include(x => x.Freelancer)
               .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task StartProjectAsync(Project project)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                await sqlConnection.OpenAsync();

                var sql = "UPDATE Projects SET Status = @status, StartedAt = @startedat Where Id = @id";

                await sqlConnection.ExecuteAsync(sql, new { status = project.Status, startedat = project.StartedAt, id = project.Id });

                await sqlConnection.CloseAsync();
            }
        }
    }
}
