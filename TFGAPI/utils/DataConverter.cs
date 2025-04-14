using System.Reflection;
using TFGApi.Models;

namespace TFGApi.utils;

public class DataConverter
{
    // Convierte un objeto en un diccionario de tipo clave-valor (string, object)
    public static Dictionary<string, object> ToDictionary(object obj)
    {
        // Si el objeto es nulo, lanza una excepción
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        var dict = new Dictionary<string, object>(); // Crear un diccionario vacío

        // Recorre las propiedades del objeto y las agrega al diccionario
        foreach (PropertyInfo prop in obj.GetType().GetProperties())
        {
            var value = prop.GetValue(obj); // Obtener el valor de la propiedad

            if (value != null)
            {
                // Si la propiedad es de tipo 'Characters', convertirla también a un diccionario
                if (prop.PropertyType == typeof(Characters))
                {
                    dict[prop.Name] = ToDictionary(value); // Convertir 'Characters' a diccionario recursivamente
                }
                else
                {
                    dict[prop.Name] = value ?? DBNull.Value; // Si el valor es nulo, agregar DBNull
                }
            }
        }

        return dict; // Retorna el diccionario resultante
    }

    // Convierte un diccionario de tipo clave-valor en un objeto 'Level'
    public static Level dictionaryTolevel(Dictionary<string, object> dict, string id)
    {
        return new Level(
            id, // Asigna el ID del nivel
            dict.GetValueOrDefault("num", "").ToString()!, // Asigna el número del nivel (o cadena vacía si no existe)
            dict.GetValueOrDefault("user", "").ToString()!, // Asigna el usuario (o cadena vacía si no existe)
            Convert.ToInt32(dict.GetValueOrDefault("score", 0)), // Asigna la puntuación (por defecto 0)
            Convert.ToInt32(dict.GetValueOrDefault("gems", 0)) // Asigna la cantidad de gemas (por defecto 0)
        );
    }

    // Convierte un diccionario de tipo clave-valor en un objeto 'User'
    public static User dictionaryToUser(Dictionary<string, object> dict, string id)
    {
        return new User(
            id, // Asigna el ID del usuario
            dict.GetValueOrDefault("usuario", "").ToString()!, // Asigna el nombre de usuario
            dict.GetValueOrDefault("email", "").ToString()!, // Asigna el correo electrónico
            dict.GetValueOrDefault("password", "").ToString()!, // Asigna la contraseña
            dict.TryGetValue("characters", out var charactersObj) && charactersObj is Dictionary<string, object> charDict
                ? DictionaryToCharacters(charDict)  // Si existe 'characters' en el diccionario, lo convierte en un objeto 'Characters'
                : null // Si no existe, asigna null
        );
    }

    // Convierte un diccionario de tipo clave-valor en un objeto 'Characters'
    public static Characters DictionaryToCharacters(Dictionary<string, object> dict)
    {
        return new Characters(
            dict.TryGetValue("sonic", out var sonicObj) ? Convert.ToBoolean(sonicObj) : false, // Si existe 'sonic', asigna su valor (por defecto false)
            dict.TryGetValue("knuckles", out var knucklesObj) ? Convert.ToBoolean(knucklesObj) : false, // Si existe 'knuckles', asigna su valor (por defecto false)
            dict.TryGetValue("tails", out var tailsObj) ? Convert.ToBoolean(tailsObj) : false, // Si existe 'tails', asigna su valor (por defecto false)
            dict.TryGetValue("mario", out var marioObj) ? Convert.ToBoolean(marioObj) : false // Si existe 'mario', asigna su valor (por defecto false)
        );
    }
}