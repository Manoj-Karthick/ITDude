using ITDude.API.Models;

namespace ITDude.API.Interfaces
{
    public interface IHabitService
    {
        Task<List<Habit>> GetAll();
        Task<Habit> GetById(int id);
        Task<string> Create(Habit habit);
        Task<string> Update(Habit habit,int id);
        Task<string> Delete(int id);
    }
}
