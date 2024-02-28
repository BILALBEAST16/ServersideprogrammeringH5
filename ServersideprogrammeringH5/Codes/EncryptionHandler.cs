using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using ServersideprogrammeringH5.Models;

namespace ServersideprogrammeringH5.Codes
{
    public class EncryptionHandler
    {
        private readonly IDataProtector _protector;
        private readonly ToDoContext _context;
        private readonly EncryptionHandler _encryptionHandler;
        public EncryptionHandler(IDataProtectionProvider protector, ToDoContext context)
        {
            _protector = protector.CreateProtector("Todo");
            _context = context;
        }

        public string EncryptSymetrisk(string textToEncrypt) =>
            _protector.Protect(textToEncrypt);

        public string DecryptSymetrisk(string textToDecrypt) =>
            _protector.Unprotect(textToDecrypt);
    

        public async Task AddTodoItem( ToDoList newItem, string user)
        {
            newItem.Item = _encryptionHandler.EncryptSymetrisk(newItem.Item);

            _context.ToDoLists.Add(newItem);
            await _context.SaveChangesAsync();
        }
    }
}
