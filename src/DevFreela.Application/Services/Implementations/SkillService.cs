using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels.SkillViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
        private readonly string _connectionString;

        public SkillService(DevFreelaDbContext contex, IConfiguration configuration)
        {
            _contex = contex;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public List<SkillViewModel> GetAll()
        {
            //var skills = _contex.Skills.Select(s => new SkillViewModel(s.Id,s.Description)).ToList();
            //return skills;

            // inicializo a sqlConnection
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var sql = "SELECT Id, Description FROM Skills";

                return sqlConnection.Query<SkillViewModel>(sql).ToList();
            }
        }
    }
}
