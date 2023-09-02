using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_backend.Entities;
using todo_backend.Interfaces;
using todo_backend.Repository;

namespace todo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetAllExercises()
        {

            var exercises = await _exerciseRepository.GetAllExercises();

            if (exercises == null)
            {
                return NotFound("Categories nof found");
            }

            return Ok(exercises);

        }

        [HttpPost]
        public async Task<ActionResult> CreateExercise([FromBody] Exercise exercise)
        {

            if (exercise == null)
                return BadRequest("Invalid Data");

            await _exerciseRepository.CreateExercise(exercise);

            return Ok(exercise);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateState(int id)
        {

            var exercise = await _exerciseRepository.UpdateState(id);
            return Ok(exercise);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ExerciseRepository>> DeleteExercise(int id)
        {

            var exercise = await _exerciseRepository.DeleteExercise(id);
            return Ok(exercise);

        }
    }
}
