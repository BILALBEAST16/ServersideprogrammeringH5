using Microsoft.AspNetCore.DataProtection;
using ServersideprogrammeringH5.Models;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServersideprogrammeringH5.Data
{
    public class TodoItemService
    {
        private readonly ToDoContext _context;

        public TodoItemService(ToDoContext context)
        {
            _context = context;
        }


    }
}
    


