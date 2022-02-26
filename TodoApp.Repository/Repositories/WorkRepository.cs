﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;
using TodoApp.Core.Repositories;

namespace TodoApp.Repository.Repositories
{
    public class WorkRepository : GenericRepository<WorkDto>, IWorkRepository
    {
        private IHttpContextAccessor _httpContextAccessor;
        
        public WorkRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddWorkByUniqueId(Work work)
        {
            await _context.Works.AddAsync(work);
        }

        public async Task<List<Work>> GetWorkByUniqueId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return await _context.Works.Where(x => x.UserId == userId).ToListAsync();
        }

      

        
    }
}
