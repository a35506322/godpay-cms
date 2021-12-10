using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodPay_CMS.Common.Helpers.Decipher
{
    public interface IDecipherHelper
    {
        string ConnEncryptorAES(string Data);
        string ConnDecryptorAES(string Data);
        string DataDecryptorAES(string Data);
        string DataEncryptorAES(string Data);
        string DecryptorRSA(string Data);
        string EncryptorRSA(string Data);
        string MD5(string Data);
        string SHA1(string Data);
        string SHA256(string Data);
        string SHA384(string Data);
        string SHA512(string Data);
    }
}
