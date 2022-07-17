using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu Projeto ASPNET Core 1","Minha Descricao de Projeto 1",1,1,1000000),
                new Project("Meu Projeto ASPNET Core 2","Minha Descricao de Projeto 2",1,1,2000000),
                new Project("Meu Projeto ASPNET Core 3","Minha Descricao de Projeto 3",1,1,3000000),
            };

            Users = new List<User>
            {
                new User("Luis Felipe", "luisdev@luisdev.com.br", new DateTime(1992,1,1)),
                new User("Roberts Maquess", "robert@luisdev.com.br", new DateTime(1997,1,1)),
                new User("Anderson Silva", "anderson@luisdev.com.br", new DateTime(2000,1,1)),
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL"),
            };
        }
        public List<Project> Projects { get;  set; }
        public List<User> Users { get;  set; }
        public List<Skill> Skills { get;  set; }
        public List<ProjectComment> ProjectsComments { get; set; }
    }
}
