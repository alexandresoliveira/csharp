using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace PlanningPokerApi.Src.Shared.Helpers.Cryptography
{
  public class HashHelper
  {
    public string GetCypher(string text)
    {
      byte[] salt = new byte[128 / 8];

      string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        password: text,
        salt: salt,
        prf: KeyDerivationPrf.HMACSHA1,
        iterationCount: 10000,
        numBytesRequested: 256 / 8));

      return hashed;
    }
  }
}