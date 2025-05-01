using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordHasher
{
    // Método para generar un hash de la contraseña
    public static string HashPassword(string password, string salt)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Concatenar el salt con la contraseña
            string saltedPassword = salt + password;
            
            // Convertir a bytes
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

            // Convertir el hash a una cadena hexadecimal
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }

    // Método para verificar si la contraseña ingresada coincide con el hash guardado
    public static bool VerifyPassword(string enteredPassword, string salt, string storedHash)
    {
        string enteredHash = HashPassword(enteredPassword, salt);
        return enteredHash == storedHash;
    }
}
