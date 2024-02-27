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

        public async Task SubmitCPR(string cprNumber, string username, int id)
        {
            // Hash CPR-nummeret
            string hashedCPR = HashCPR(cprNumber);

            // Gem de hashede oplysninger i databasen
            var cpr = new Cpr { CprNr = hashedCPR, User = username, Id = id };
            _context.Cprs.Add(cpr);
            await _context.SaveChangesAsync();
        }

        public string HashCPR(string cprNumber)
        {
            // Implementer den ønskede hashing-algoritme, f.eks. SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Konverter CPR-nummeret til byte-array
                byte[] bytes = Encoding.UTF8.GetBytes(cprNumber);

                // Beregn hashen for CPR-nummeret
                byte[] hashBytes = sha256Hash.ComputeHash(bytes);

                // Konverter hashen til en streng
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async Task AddTodoItem(string item, string userName)
        {
            var todoItem = new ToDoList { Item = item, User = userName };
            _context.ToDoLists.Add(todoItem);
            await _context.SaveChangesAsync();
        }

    }
}
    


