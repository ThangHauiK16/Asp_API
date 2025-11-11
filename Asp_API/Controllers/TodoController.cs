using Asp_API.Model;
using Asp_API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Asp_API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetAll () => Ok(_todoService.GetAll());
        [HttpGet("{Id}")]
        public ActionResult<Todo> GetById(int Id)
        {
            var item = _todoService.GetById(Id);
            return item == null ? NotFound() : Ok(item);
        }
        [HttpPost]
        public ActionResult<Todo> Create(Todo item) {
            var created = _todoService.Create(item);
            return CreatedAtAction(nameof(GetById) , new { id = created.ID}, created);
            //return Ok(created);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Todo item)
        {
            return _todoService.Update(id, item) ? NoContent() : NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _todoService.Delete(id) ? NoContent() : NotFound();
        }
    }
}
