using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<PaginationResult<Project>> GetAllAsync(string query, int page = 1);
        Task<Project> GetByIdAsync(int id);
        Task CreateProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);
        Task FinishProjectAsync(Project project);

        Task UpdateAsync(Project project);
        Task StartProjectAsync(Project project);
        Task SaveChangesAsync();
        Task CreateCommentAsync(ProjectComment comment);
    }
}
