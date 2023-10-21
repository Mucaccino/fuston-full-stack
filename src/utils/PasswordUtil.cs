namespace fuston.utils;

using BCrypt.Net;

public class PasswordUtil {
    public static string GetHashedPassword(string password) {
        return BCrypt.HashPassword(password);
    }

    public static bool VerifyHashedPassword(string password, string hashed) {
        return BCrypt.Verify(password, hashed);
    }
}