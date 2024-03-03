using Dapper;
using ITDude.API.Enums;
using ITDude.API.Interfaces;
using ITDude.API.Models;
using ITDude.API.Models.Data;
using System.Data;

namespace ITDude.API.Repository
{
    public class HabitService : IHabitService
    {
        public readonly DapperDBContext _context;
        public HabitService(DapperDBContext context) {
            this._context = context;
        }

        public async Task<string> Create(Habit habit)
        {
            string response = string.Empty; 
            var currentDate = DateTime.Now;
            string query = "INSERT INTO dbo.habit(HabitName,CreatedDate,UpdatedDate) VALUES (@habitName,@createdDate,@updatedDate)";
            var parameters = new DynamicParameters();
            parameters.Add("habitName", habit.HabitName,DbType.String);
            parameters.Add("createdDate", currentDate, DbType.DateTime);
            parameters.Add("updatedDate", currentDate, DbType.DateTime);
            using (var connection = this._context.CreateConnection())
            {
                try
                {
                    await connection.ExecuteAsync(query, parameters);
                    response = nameof(Constants.Passed);
                }
                catch (Exception ex)
                {
                    response = nameof(Constants.Failed);
                }
                return response;
            }
        }

        public async Task<string> Delete(int id)
        {
            string response = string.Empty;
            string query = "DELETE FROM dbo.habit WHERE id=@id";
            using (var connection = this._context.CreateConnection())
            {
                try
                {
                    await connection.ExecuteAsync(query, new { id });
                    response = nameof(Constants.Passed);
                }
                catch(Exception ex)
                {
                    response = nameof(Constants.Failed);
                }
                return response;
            }
        }

        public async Task<List<Habit>> GetAll()
        {
            string query = "SELECT Id,HabitName,CreatedDate,UpdatedDate FROM dbo.habit";
            using(var connection = this._context.CreateConnection())
            {
                var habits = await connection.QueryAsync<Habit>(query);
                return habits.ToList();
            }
        }

        public async Task<Habit> GetById(int id)
        {
            string query = "SELECT Id,HabitName,CreatedDate,UpdatedDate FROM dbo.habit WHERE id=@id";
            using (var connection = this._context.CreateConnection())
            {
                var habit = await connection.QueryFirstOrDefaultAsync<Habit>(query, new {id});
                return habit;
            }
        }

        public async Task<string> Update(Habit habit, int id)
        {
            string response = string.Empty;
            var currentDate = DateTime.Now;
            string query = "UPDATE dbo.habit set HabitName=@habitName,UpdatedDate= @updatedDate WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("habitName", habit.HabitName, DbType.String);
            parameters.Add("updatedDate", currentDate, DbType.DateTime);
            using (var connection = this._context.CreateConnection())
            {
                try
                {
                    await connection.ExecuteAsync(query, parameters);
                    response = nameof(Constants.Passed);
                }
                catch (Exception ex)
                {
                    response = nameof(Constants.Failed);
                }
                return response;
            }
        }
    }
}
