using todo_backend.Entities;
using todo_backend.Interfaces;

namespace todo_backend.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        public Task<Exercise> CreateExercise()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exercise>> GetAllExercises()
        {
            throw new NotImplementedException();
        }
    }
}
