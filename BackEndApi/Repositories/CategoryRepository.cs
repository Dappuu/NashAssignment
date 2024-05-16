﻿using BackEndApi.Data;
using BackEndApi.Helpers;
using BackEndApi.Interfaces;
using BackEndApi.Models;
using BackEndApi.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackEndApi.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync(QueryObject query)
        {
            Expression<Func<Category, bool>> filter = null;
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                filter = c => c.Name.Contains(query.Name);
            }
            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null;
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    orderBy = query.IsDescending ? c => c.OrderByDescending(c => c.Name) : c => c.OrderBy(c => c.Name);
                }
            }
            var categories = await GetAll(filter: filter, orderBy: orderBy, includeProperties: "Products");

            return categories;
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Category?> GetByIdSubAsync(int id)
        {
            var category = await _context.Categories.Include(c => c.SubCategories).FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }
    }
}
