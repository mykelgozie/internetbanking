using App.Core.Iterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Core.Services
{
    public class BankingService : IBankingService
    {
        public async Task<string> CalculateMD5(string data)
        {
            var word = data;
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(word);
                byte[] hashBytes = md5.ComputeHash(inputBytes);


                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }

        }

        public async Task<string> GetApiVersion(string path)
        {
            var arrayPath = path.Split('/');
            var a = 1;
            var version = "";
            foreach (var item in arrayPath)
            {
                if (item.Length > 1 && item[0].ToString() == "v" && int.TryParse(item[1].ToString(), out a))
                {
                    version = item[1].ToString();
                    break;
                }
            }
            var result = DateTime.UtcNow.ToString("yyyy.MM.dd");
            var final = result + "." + version + ".0";

            return final;
        }

        public async Task<bool> IsPasswordStrong(string password)
        {
            //  var pass = "Pa$$word1";
             var pass = password;

            if (string.IsNullOrWhiteSpace(pass))
            {
                return false;
            }

            var hasSpace = pass.Contains(" "); ;
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniChars = new Regex(@".{8,}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (hasNumber.IsMatch(pass) && hasUpperChar.IsMatch(pass) && hasMiniChars.IsMatch(pass)
                && hasLowerChar.IsMatch(pass) && hasSymbols.IsMatch(pass) && !hasSpace)
            {

                return true;
            }

            return false;
        }
    }
}
