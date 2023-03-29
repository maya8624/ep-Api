using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ep.Service.Cryptograph
{
    public class CryptoService
    {  
        private static Aes CreateCipher(string key)
        {
            Aes cipher = Aes.Create(); //Defaults = Keysize 256, Mode CBC, Padding PKC27
            //Aes cipher = new AesManaged();
            //Aes cipher = new AesCryptoServiceProvider();

            cipher.Padding = PaddingMode.ISO10126;
            //cipher.Padding = PaddingMode.Zeros;
            //cipher.Mode = CipherMode.ECB;

            //Create() makes new key each time, use a consistent key for encrypt/decrypt
            //Key = GetKey(); //"LsQpq8bWkyHjewMnaG5ogtwKo5Yla6BjeS7Mj1DIDJ4=";
            cipher.Key = Convert.FromBase64String(key);// conversions.HexToByteArray("892C*E496"); //symetric key
            return cipher;
        }

        public string Encrypt(string plainText)
        {
            var key = GenerateRandomKey();
            Aes cipher = CreateCipher(key);

            //show the IV on page (will use for decrypt, normally send in clear along with ciphertext)
            var iv = Convert.ToBase64String(cipher.IV);

            //Create the encryptor, convert to bytes, and encrypt
            ICryptoTransform cryptoTransform = cipher.CreateEncryptor();
            byte[] plaintext = Encoding.UTF8.GetBytes(plainText);
            byte[] cipherText = cryptoTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            //Convert to base64 for display
            var result = Convert.ToBase64String(cipherText);
            return result;
        }

        public static string Decrypt(string key, string iv, string encryptedText)
        {
            Aes cipher = CreateCipher(key);

            //Read back in the IV used to randomize the first block
            cipher.IV = Convert.FromBase64String(iv);

            //Create the decryptor, convert from base64 to bytes, decrypt
            ICryptoTransform cryptoTransform = cipher.CreateDecryptor();
            byte[] cipherText = Convert.FromBase64String(encryptedText);
            byte[] plainText = cryptoTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);

            var originPlainText = Encoding.UTF8.GetString(plainText);
            return originPlainText;
        }

        public static string GenerateRandomKey()
        {
            byte[] key = new byte[32]; //256 bits (1 byte = 8bits)

            //Use cryptogrphically strong random number generator
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            //Get enough random bytes to fill the given buffer
            rng.GetBytes(key);

            //Convert to hex for key storage (can also use base64)
            var hex = Convert.ToBase64String(key);
            return hex;
        }

        public static string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];

            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetNonZeroBytes(salt);

            return Convert.ToBase64String(salt);
        }

        public static string HashPassword(string text, string salt)
        {
            byte[] secret = Encoding.UTF8.GetBytes(salt);
            string hashedText = Convert.ToBase64String(KeyDerivation.Pbkdf2
            (
                   password: text,
                   salt: secret,
                   prf: KeyDerivationPrf.HMACSHA256,
                   iterationCount: 10000,
                   numBytesRequested: 256 / 8)
            );
            return hashedText;
        }
    }
}