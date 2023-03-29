using ep.Service.Cryptograph;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;
using Xunit;

namespace ep.Tests.Services
{
    public class CryptoServiceTests
    {
        [Fact]
        public void GenerateRandomKey_WhenCalles_ShouldReturnRandomHashedKey()
        {
            var result = CryptoService.GenerateRandomKey();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GenerateSalt_WhenCalled_ShouldRetrunHashedSaltString()
        {
            var result = CryptoService.GenerateSalt();            
            Assert.NotEmpty(result);
        }
    }
}
