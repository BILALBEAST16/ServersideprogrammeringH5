using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using ServersideprogrammeringH5.Models;
using System.Security.Cryptography;
namespace ServersideprogrammeringH5.Codes

{
    public class AsymetriskEncryptionHandler
    {
        //private string _privateKey;
        //public string _publicKey;
        //public AsymetriskEncryptionHandler() 
        //{
        //    using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        //    {
        //        _privateKey = rsa.ToXmlString(true);

        //        _publicKey = rsa.ToXmlString(false);
        //    }
        //}
        //public string EncryptAsymetrisk(string textToEncrypt)
        //{
        //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        //    {
        //        rsa.FromXmlString(_publicKey);

        //        byte[] dataToEncryptAsByteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
        //        byte[] encryptDataAsByteArray = rsa.Encrypt(dataToEncryptAsByteArray, true);
        //        var encryptedDataAsString = Convert.ToBase64String(encryptDataAsByteArray);

        //        return encryptedDataAsString;

        //    }
        //}

        //public string DecryptAsymetrisk(string textToDecrypt)
        //{
        //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        //    {
        //        rsa.FromXmlString(_publicKey);

        //        byte[] dataToDecryptAsByteArray = System.Text.Encoding.UTF8.GetBytes(textToDecrypt);
        //        byte[] decryptDataAsByteArray = rsa.Decrypt(dataToDecryptAsByteArray, true);
        //        var decryptedDataAsString = Convert.ToBase64String(decryptDataAsByteArray);

        //        return decryptedDataAsString;

        //    }
        //}

       

    }
}
