using Newtonsoft.Json.Linq;
using System;
using System.Security.Cryptography;
using Xunit;

namespace ep.Tests.Services
{
    public class CryptoServiceTests
    {
        [Fact]
        public void GenerateHahsedKey()
        {
            byte[] key = new byte[32]; //256 bits (1 byte = 8bits)

            //Use cryptogrphically strong random number generator
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            var Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            //Get enough random bytes to fill the given buffer
            rng.GetBytes(key);

            //Convert to hex for key storage (can also use base64)
            var hex = Convert.ToBase64String(key);

            Assert.NotEmpty(hex);
        }
    }
}
