using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");
            builder.HasKey(x => x.Id);


            //Relacionamentos
            builder.HasMany(x => x.UserSkills)
                .WithOne(x => x.Skill)
                .HasForeignKey(x => x.IdSkill);
        }
    }
}
