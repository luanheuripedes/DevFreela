using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _contex;

        public SkillService(DevFreelaDbContext contex)
        {
            _contex = contex;
        }

        public List<SkillViewModel> GetAll()
        {
            var skills = _contex.Skills.Select(s => new SkillViewModel(s.Id,s.Description)).ToList();
            return skills;
        }
    }
}
