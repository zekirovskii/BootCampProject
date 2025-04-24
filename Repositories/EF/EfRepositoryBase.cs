﻿using BootCampProject.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts; // AppDbContext burada olmalı

namespace BootCampProject.Repositories.EF
{
    public class EfRepositoryBase<T> : IAsyncRepository<T> where T : class
    {
        protected readonly AppDbContext _context; // Değişti

        public EfRepositoryBase(AppDbContext context) // Değişti
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}