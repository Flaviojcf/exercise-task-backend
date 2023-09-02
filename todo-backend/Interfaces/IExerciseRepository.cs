using todo_backend.Entities;

namespace todo_backend.Interfaces
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAllExercises();

        Task<Exercise> CreateExercise();
    }
}
