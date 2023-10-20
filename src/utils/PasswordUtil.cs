namespace fuston.utils;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

public class PasswordUtil {
    public static string GetHashedPassword(password:string) {
        // Generate a 128-bit salt using a sequence of
        // cryptographically strong random bytes.
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
        
        // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return hashed;
    }

    public static string VerifyHashedPassword(password:string, hash:string) {
        return (hashed === GetHashedPassword(password))
    }
}

/*
 * SAMPLE OUTPUT
 *
 * Enter a password: Xtw9NMgx
 * Salt: CGYzqeN4plZekNC88Umm1Q==
 * Hashed: Gt9Yc4AiIvmsC1QQbe2RZsCIqvoYlst2xbz0Fs8aHnw=
 */