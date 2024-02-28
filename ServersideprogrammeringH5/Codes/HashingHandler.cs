using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;
using ServersideprogrammeringH5.Models;
using System.Security.Cryptography;
using System.Text;

namespace ServersideprogrammeringH5.Codes
{
    public class HashingHandler
    {
        private readonly ToDoContext _context;
        public HashingHandler(ToDoContext context)
        {
            _context = context;
        }



        //private byte[]? _inputBytes = null;
        //public HashingHandler(String TextToHash)
        //{

        //    _inputBytes = Encoding.ASCII.GetBytes(TextToHash);

        //}

        //public String MD5Hashing()
        //{
        //    MD5 md5 = MD5.Create();
        //    byte[] hashedvalue = md5.ComputeHash(_inputBytes);
        //    return Convert.ToBase64String(hashedvalue);
        //}

        //public String SHAHashing()
        //{
        //    SHA256 sha256 = SHA256.Create();
        //    byte[] hashedvalue = sha256.ComputeHash(_inputBytes);
        //    return Convert.ToBase64String(hashedvalue);
        //}


        //public string HMACHashing() //HMAC er dynamisk, men stadig uden SALT
        //{
        //    HMACSHA256 hmac = new HMACSHA256();
        //    byte[] myKey = Encoding.ASCII.GetBytes("langtbytearray");
        //    hmac.Key = myKey;

        //    byte[] hashedValue = hmac.ComputeHash(_inputBytes);
        //    return Convert.ToBase64String(hashedValue);
        //}

        //public string PBKF2Hashing(string salt) //man kunne have alogritmenavn, antal itterationer og bytes her, hvis man vil
        //{
        //    byte[] saltAsByteArray = Encoding.ASCII.GetBytes(salt);
        //    var hashAlgoritme = new System.Security.Cryptography.HashAlgorithmName("SHA256"); //behøver ikke at være hardcoded

        //    byte[] hashedValue = Rfc2898DeriveBytes.Pbkdf2(_inputBytes, saltAsByteArray, 8, hashAlgoritme, 32); //8 er antal itterationer, 32 er antal bit
        //    return Convert.ToBase64String(hashedValue);
        //}



        //public static string BCryptHashing(string TextToHash)
        //{
        //    return BCrypt.Net.BCrypt.HashPassword(TextToHash, 10, true);
        //}

        //public static bool BCryptVerfiyHashing(string TextToHash, string HashedValue)
        //{
        //    return BCrypt.Net.BCrypt.Verify(TextToHash, HashedValue, true);
        //}

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

    

    }
}

