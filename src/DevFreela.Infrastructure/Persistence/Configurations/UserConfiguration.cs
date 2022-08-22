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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(t => t.Id);

            builder.HasMany(u => u.Skills)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.OwnedProjects)
                .WithOne(u => u.Client)
                .HasForeignKey(u => u.IdClient)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.FreelanceProjects)
                .WithOne(u => u.Freelancer)
                .HasForeignKey(u => u.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Comments)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
