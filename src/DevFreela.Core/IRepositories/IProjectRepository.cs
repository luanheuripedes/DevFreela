using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync(string query);
        Task<Project> GetByIdAsync(int id);
        Task CreateProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);
        Task FinishProjectAsync(Project project);
        Task StartProjectAsync(Project project);
        Task SaveChangesAsync();
        Task CreateCommentAsync(ProjectComment comment);
    }
}
