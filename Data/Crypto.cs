using System;

namespace MyLabyrinth
{
    public static class Crypto
    {
        public static string CryptoXOR(string text, int key = 42)
        {
            var result = String.Empty;
            
            foreach (var symbol in text)
            {
                result += (char) (symbol ^ key);
            }

            return result;
        }
    }
}

