using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Iterface
{
    public interface IBankingService
    {

        public Task<string> GetApiVersion();

        public Task<string> CalculateMD5();

        public Task<Boolean> IsPasswordStrong();
    }
}
