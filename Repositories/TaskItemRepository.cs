using CRUD.Models;
using CRUD.Interfaces;
using Microsoft.EntityFrameworkCore;
using CRUD.Data;

namespace CRUD.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly RepositoryContext _context;

        public TaskItemRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            return await _context.TaskItem.ToListAsync();
        }

        public async Task<TaskItem> GetById(int id)
        {
            return await _context.TaskItem.FindAsync(id);
        }

        public async Task Add(TaskItem task)
        {
            await _context.TaskItem.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TaskItem task)
        {
            _context.TaskItem.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var task = await GetById(id);
            if (task != null)
            {
                _context.TaskItem.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
