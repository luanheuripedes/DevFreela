using DevFreela.Application.InputModels.ProjectInputModels;
using DevFreela.Application.ViewModels.ProjectViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectServices
    {
        ProjectDetailsViewModel GetById(int id);

    }
}
