using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBTrial.Services.Abstract
{
    public interface ITodoService
    {
        public Task AddTodoAsync(string firstName, string lastName);

        public IEnumerable<string> GetTodoData();
    }
}
