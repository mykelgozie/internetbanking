using App.Core.Iterface;
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
        private IBankingService _bankingService;

        public HomeController(IBankingService bankingService)
        {
            _bankingService = bankingService;

        }

        [Route("bank/v{version:apiVersion}/api/version")]
        [HttpGet]
        public async Task<IActionResult> GetApiVersion1()
        {

            var path = Request.Path.Value;
            var dateVersion = await _bankingService.GetApiVersion(path);
            return Ok(dateVersion);

        }

        [Route("bank/v{version:apiVersion}/api-version")]
        
        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetApiVersion2()
        {
            var path = Request.Path.Value;
            var dateVersion = await _bankingService.GetApiVersion(path);
            return Ok(dateVersion);

        }

        [Route("bank/{version:apiVersion}/api/calc/MD5/{data}")]
        [HttpGet]
        public async Task<IActionResult> CalculateMD51(string data)
        {
            var md5Hex = await _bankingService.CalculateMD5(data);
            return Ok(md5Hex);
        
        }



        [Route("bank/{version:apiVersion}/api/calc/{data}/MD5")]
        [HttpGet]
        public async Task<IActionResult> CalculateMD52(string data)
        {
            var md5Hex = await _bankingService.CalculateMD5(data);
            return Ok(md5Hex);

        }


        [HttpGet]
        [Route("bank/v{version:apiVersion}/api/password/strong/{password}")]
        public async Task<IActionResult> IsPasswordStrong1(string password)
        {
            var isValidPassword = await _bankingService.IsPasswordStrong(password);
            if (isValidPassword)
            {
                return Ok("Password is valid");
            }
            return BadRequest("Invalid Password");
        }


        [HttpGet]
        [Route("bank/v{version:apiVersion}/api/is-password-strong/{password}")]
        public async Task<IActionResult> IsPasswordStrong2(string password)
        {
            var isValidPassword = await _bankingService.IsPasswordStrong(password);
            if (isValidPassword)
            {
                return Ok("Password is valid");
            }
            return BadRequest("Invalid Password");
        }



    }
}
