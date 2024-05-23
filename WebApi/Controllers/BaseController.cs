using MongoDb.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase
        where T : IEntity
    {
        private readonly IRepository<T> _repository;

        public BaseController(IRepository<T> repository)
            => _repository = repository;

        [HttpGet]
        public async Task<List<T>> GetAll()
            => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(string id)
        {
            var entity = await _repository.GetAsync(id);

            if (entity is null) return NotFound();

            return entity;
        }

        [HttpPost]
        public async Task<IActionResult> Post(T newEntity)
        {
            await _repository.CreateAsync(newEntity);

            return Ok();
            // return CreatedAtAction(nameof(Get), new { id = newEntity.Id }, newEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, T updatedEntity)
        {
            var entity = await _repository.GetAsync(id);

            if (entity is null) return NotFound();

            updatedEntity.Id = entity.Id;

            await _repository.UpdateAsync(id, updatedEntity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var entity = await _repository.GetAsync(id);

            if (entity is null) return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}