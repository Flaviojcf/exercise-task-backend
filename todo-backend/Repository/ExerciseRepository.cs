using Microsoft.EntityFrameworkCore;
using todo_backend.Context;
using todo_backend.Entities;
using todo_backend.Interfaces;

namespace todo_backend.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        ApplicationDbContext _exerciseContext;

        public ExerciseRepository(ApplicationDbContext exerciseContext)
        {
            _exerciseContext = exerciseContext;
        }

        public async Task<Exercise> CreateExercise(Exercise exercise)
        {
            _exerciseContext.Add(exercise);
            await _exerciseContext.SaveChangesAsync();
            return exercise;
        }

        public async Task<IEnumerable<Exercise>> GetAllExercises()
        {
            return await _exerciseContext.Exercises.ToListAsync();
        }

        public async Task<Exercise> UpdateState(int id)
        {
            var exercise = await _exerciseContext.Exercises.FindAsync(id);

            if (exercise is null)
            {
                throw new Exception("Exercise not found."); 
            }

            exercise.IsCompleted = !exercise.IsCompleted;

            await _exerciseContext.SaveChangesAsync();

            return exercise;
        }

        public async Task<Exercise> DeleteExercise(int id)
        {
            var exercise = await _exerciseContext.Exercises.FindAsync(id);

            if (exercise is null)
            {
                throw new Exception("Exercise not found.");
            }
            _exerciseContext.Remove(exercise);
            await _exerciseContext.SaveChangesAsync();
            return exercise;
        }


    }
}
