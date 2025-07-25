﻿using DevFreela.Core.IRepositories;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        public IProjectRepository Projects { get; }
        public IUserRepository Users { get; }
        public ISkillRepository Skills { get; }
        private readonly DevFreelaDbContext _context;

        public UnitOfWork(IProjectRepository projects, IUserRepository users, ISkillRepository skills, DevFreelaDbContext context)
        {
            Projects = projects;
            Users = users;
            Skills = skills;
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> CompleteAsync()
        {
           return  await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        
    }
}
