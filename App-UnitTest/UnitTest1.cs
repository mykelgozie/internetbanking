using App.Core.Iterface;
using App.Core.Services;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace App_UnitTest
{
    [TestFixture]
    public class Tests
    {
        IBankingService service;
        [SetUp]
        public void Setup()
        {
             service = new BankingService();
        }

        [Test]
        public async Task GetVersionTestAsync()
        {
           // IBankingService service = new BankingService();
            var path = "bank/v2/api-version";
            var result = DateTime.UtcNow.ToString("yyyy.MM.dd");
            var expected = result + "." + "2" + ".0";
            var version = await service.GetApiVersion(path);
            Assert.That(expected, Is.EqualTo(version));
        }

        [Test]
        public async Task CalculateMD5Test()
        {
            var expected = "7FE8C14D5E3D1CFB648F77F05766A013";
            var testPassword = "test-string-1"; 
            var testResult =   await service.CalculateMD5(testPassword);
            Assert.That(expected, Is.EqualTo(testResult));


        }

        [Test]
        public async Task IsPasswordStrongTest()
        {
            var password = "Pa$$w0rd";
            var expected = true;
            var testResult = await service.IsPasswordStrong(password);
            Assert.That(expected, Is.EqualTo(testResult));
        }
    }
}