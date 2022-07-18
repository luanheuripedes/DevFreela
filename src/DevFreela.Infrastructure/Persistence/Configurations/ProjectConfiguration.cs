﻿using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(t => t.Id);

            builder.Property(p => p.TotalCost).HasColumnType("decimal(18,2)");
            //Relacionamentos
            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.IdProject);
        }
    }
}
