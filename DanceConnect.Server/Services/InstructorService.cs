using DanceConnect.Server.DataContext;
using DanceConnect.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace DanceConnect.Server.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly DanceConnectContext _context;

        public InstructorService(DanceConnectContext context)
        {
            _context = context;
        }
        public async Task<Instructor> AddInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return instructor;
        }

        public async Task<List<Instructor>> GetAllInstructorsAsync()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            return await _context.Instructors.FindAsync(id)?? throw new Exception($"Instructor with id {id} does not exists");
        }
    }
}
