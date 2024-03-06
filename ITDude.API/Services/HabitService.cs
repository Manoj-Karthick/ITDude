using ITDude.API.Interfaces;
using ITDude.API.Models;
using ITDude.API.Models.Data;

namespace ITDude.API.Repository
{
    public class HabitService : IHabitService
    {
        private readonly ITDudeDBContext _context;
        public HabitService(ITDudeDBContext context) {
            _context = context;
        }

        public async Task<string> Create(Habit habit)
        {
            return "";
        }

        public async Task<string> Delete(int id)
        {
            return "";
        }

        public async Task<List<Habit>> GetAll()
        {
            return new List<Habit>();
        }

        public async Task<Habit> GetById(int id)
        {
            return new Habit();
        }

        public async Task<string> Update(Habit habit, int id)
        {
            return "";
        }
    }
}
