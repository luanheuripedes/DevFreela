using DevFreela.Application.InputModels.ProjectInputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.ProjectViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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
        public ProjectServices(DevFreelaDbContext contex)
        {
            _contex = contex;
        }


        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);
            _contex.Projects.Add(project);

            _contex.SaveChanges();

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _contex.ProjectsComments.Add(comment);
            _contex.SaveChanges();

        }

        public void Delete(int id)
        {
            var project = _contex.Projects.SingleOrDefault(p => p.Id == id);

            project.CancelProject();

            _contex.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _contex.Projects.SingleOrDefault(p => p.Id == id);
            project.FinishProject();
            _contex.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var projects = _contex.Projects;

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Title, p.CreatedAt,p.Id)).ToList();

            return projectsViewModel;
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
            _contex.SaveChanges();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _contex.Projects.SingleOrDefault(p => p.Id == inputModel.Id);
            project.Update(inputModel.Title,inputModel.Description,inputModel.TotalCost);
            _contex.SaveChanges();
        }
    }
}
