﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Persistence.EF.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly CarManagementContext _dbContext;

        public BaseRepository(CarManagementContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}