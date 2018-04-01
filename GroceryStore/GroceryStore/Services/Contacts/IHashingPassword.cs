using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contacts
{
    public interface IHashingPassword
    {
        string GetSHA1HashData(string data);
        bool ValidateSHA1HashData(string inputData, string storedHashData);
    }
}
