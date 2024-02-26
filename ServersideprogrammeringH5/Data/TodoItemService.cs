using ServersideprogrammeringH5.Models;

namespace ServersideprogrammeringH5.Data
{
    public class TodoItemService
    {
        private readonly ToDoContext _context;

        public TodoItemService(ToDoContext context)
        {
            _context = context;
        }

        public async Task AddTodoItem(string item, string userName)
        {
            var todoItem = new ToDoList { Item = item, User = userName };
            _context.ToDoLists.Add(todoItem);
            await _context.SaveChangesAsync();
        }
    }
}

