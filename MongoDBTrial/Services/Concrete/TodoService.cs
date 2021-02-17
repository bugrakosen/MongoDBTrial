using MongoDBTrial.Data.Abstract;
using MongoDBTrial.Entity;
using MongoDBTrial.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBTrial.Services.Concrete
{
    public class TodoService : ITodoService
    {
        private readonly IMongoRepository<TodoModel> _todoRepository;

        public TodoService(IMongoRepository<TodoModel> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task AddTodoAsync(string firstName, string lastName)
        {
            var person = new TodoModel()
            {
                 Title = "John",
                 Completed = false
            };

            await _todoRepository.InsertOneAsync(person).ConfigureAwait(false);
        }

        public IEnumerable<string> GetTodoData()
        {
            var people = _todoRepository.FilterBy(
                filter => filter.Title != "test",
                projection => projection.Title
            );
            return people;
        }
    }
}
