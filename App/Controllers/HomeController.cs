using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class HomeController : ControllerBase
    {

        [Route("bank/v{version:apiVersion}/api/version")]
        [HttpGet]
        public async Task<IActionResult> GetApiVersion1()
        {

            var path = Request.Path.Value;
           var arrayPath = path.Split('/');
            var a = 1;
            var version = "";
            foreach (var item in  arrayPath) 
            {
                
                if (item.Length > 1 &&  item[0].ToString() == "v" && int.TryParse(item[1].ToString(), out a))
                {

                    version = item[1].ToString();
                    break;
                    
                }

            }
            return Ok(version);

        }

        [Route("bank/v{version:apiVersion}/api-version")]
        
        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetApiVersion2()
        {
            var path = Request.Path.Value;
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


            var result =  DateTime.UtcNow.ToString("yyyy.MM.dd");
            var final = result + "." + version + ".0";
            return Ok(final) ;


        }

        [Route("bank/{version:apiVersion}/api/calc/MD5")]
        [HttpGet]
        public async Task<IActionResult> CalculateMD51()
        {
            var word = "test-string-1";
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(word);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

            
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return  Ok(sb.ToString());
            }
        
        }

        [HttpGet]
        [Route("bank/api/password/strong")]
        public async Task<IActionResult> IsPasswordStrong()
        {
            var pass = "Pa$$word1";

            if (string.IsNullOrWhiteSpace(pass))
            {
                return Ok("Password should not be empty");
            }

            var hasSpace = pass.Contains(" "); ;
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniChars = new Regex(@".{8,}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (hasNumber.IsMatch(pass) && hasUpperChar.IsMatch(pass) && hasMiniChars.IsMatch(pass)
                && hasLowerChar.IsMatch(pass) && hasSymbols.IsMatch(pass)  && !hasSpace)
            {

                return Ok("good");
            }



            return BadRequest();

        }


    }
}
