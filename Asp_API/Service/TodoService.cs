using Asp_API.Model;

namespace Asp_API.Service
{
    public class TodoService : ITodoService
    {
        private static List<Todo> Todos = new()
        {
            new Todo {ID = 1 , Title= "Giao An" , IsDone=false},
            new Todo {ID = 2 , Title = "Hoc ASP" , IsDone =false},
        };
        public IEnumerable<Todo> GetAll()
        {
            return Todos;
        }
        public Todo? GetById(int Id)
        {
            return Todos.FirstOrDefault(x => x.ID == Id);
        }
        public Todo Create(Todo item) {
            item.ID = Todos.Max(x => x.ID) + 1;
            Todos.Add(item);
            return item;
        }
        public bool Update(int ID, Todo item)
        {
            var todo = Todos.FirstOrDefault(x => x.ID == ID);
            if (todo == null) return false;
            todo.Title = item.Title;
            todo.IsDone = item.IsDone;
            return true;
        }
        public bool Delete(int ID) {
            var todo = Todos.FirstOrDefault( x => x.ID == ID);
            if(todo == null) return false;
            Todos.Remove(todo);
            return true;
        }
    }
}
