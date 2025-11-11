using Asp_API.Model;

namespace Asp_API.Service
{
    public interface ITodoService
    {
        IEnumerable<Todo> GetAll();
        Todo? GetById(int Id);
        Todo Create(Todo item);
        bool Update(int ID, Todo item);
        bool Delete(int ID);
    }
}
