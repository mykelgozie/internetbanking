using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Iterface
{
    public interface IBankingService
    {

        public Task<string> GetApiVersion(string path);

        public Task<string> CalculateMD5(string data);

        public Task<Boolean> IsPasswordStrong(string password);
    }
}
