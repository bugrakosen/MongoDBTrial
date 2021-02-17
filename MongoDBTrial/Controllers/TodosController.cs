using Microsoft.AspNetCore.Mvc;
using MongoDBTrial.Entity;
using MongoDBTrial.Extensions;
using MongoDBTrial.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBTrial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost("Todo")]
        public async Task<IActionResult> AddTodo(string firstName, string lastName)
        {
            var messageContent = "Veri başarıyla eklendi.";

            return Ok(await _todoService.AddTodoAsync(firstName, lastName).ConfigureAwait(false).GetSingleObjectResponseForAddOrUpdateAsync<TodoModel>(messageContent));
        }

        [HttpGet]
        public IEnumerable<string> GetTodoData()
        {
            return _todoService.GetTodoData();
        }

    }
}
