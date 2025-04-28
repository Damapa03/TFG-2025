using TFGApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Firestore;
using TFGApi.utils;
using TFGApi.Models;
using TFGApi.Error;

namespace TFGApi.Repository;

// Define un repositorio para gestionar la lógica de acceso a datos de los usuarios en Firestore
public class UserRepository : ControllerBase
{
    // Declara variables privadas para la conexión a Firestore y la colección de usuarios
    private readonly FirestoreDb _db;
    private readonly CollectionReference _usersRef;

    // Constructor que recibe una instancia de DAO y establece la conexión con Firestore
    public UserRepository(DAO dao)
    {
        _db = dao.GetDbConnection();  // Obtiene la conexión a la base de datos
        _usersRef = _db.Collection("Users");  // Referencia a la colección "Users" en Firestore
    }

    // Método para manejar el login de un usuario
    // Recibe un DTO de login con las credenciales del usuario
    public async Task<ObjectResult> login(UserLoginDTO usuario)
    {
        try
        {
            // Convierte el DTO a un diccionario
            // var userData = DataConverter.ToDictionary(usuario);

            // // Obtiene el usuario de la base de datos mediante el nombre de usuario
            // User? user = await getUser(userData["user"].ToString()!);

            // // Si no se encuentra el usuario, lanza una excepción personalizada
            // if (user == null)
            // {
            //     throw new UserNotFoundException("El usuario no existe");
            // }

            // // Compara la contraseña proporcionada con la almacenada en la base de datos
            // if (user.password != usuario.password)
            // {
            //     throw new ArgumentException("La contraseña no es correcta.");
            // }


            var firebaseApp = FirebaseApp

            // Si todo es correcto, devuelve un resultado de éxito
            return Ok(new
            {
                message = "Login realizado correctamente",
                estado = true
            });
        }
        catch (Exception ex)
        {
            // Si ocurre una excepción, devuelve un código de error 500 con detalles
            return StatusCode(500, new { error = "Error al logear al usuario", details = ex.Message });
        }
    }

    // Método para registrar un nuevo usuario
    public async Task<ObjectResult> register(UserRegisterDTO user)
    {
        try
        {
            // Crea un nuevo objeto de usuario con los datos proporcionados
            User newUser = new User(
                null,  // El ID se genera automáticamente en Firestore
                user.usuario,  // Nombre de usuario
                user.email,  // Correo electrónico
                user.password,  // Contraseña
                new Characters(false, false, false, false)  // Establece los valores predeterminados para "Characters"
            );

            // Convierte el nuevo usuario a un diccionario
            var userData = DataConverter.ToDictionary(newUser);

            // Agrega el documento a Firestore
            DocumentReference docRef = await _usersRef.AddAsync(userData);

            // Devuelve un mensaje de éxito
            return Ok(new
            {
                message = "Registro realizado correctamente"
            });
        }
        catch (Exception ex)
        {
            // Si ocurre una excepción, devuelve un código de error 500 con detalles
            return StatusCode(500, new { error = "Error registrar el usuario", details = ex.Message });
        }
    }

    // Método para obtener un usuario por su nombre de usuario
    public async Task<User?> getUser(string user)
    {
        try
        {
            // Realiza una consulta para buscar un usuario con el nombre proporcionado
            Query query = _usersRef.WhereEqualTo("usuario", user);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            User? users = null;

            try
            {
                // Si se encuentra al menos un documento, convierte el primer documento en un objeto de tipo User
                DocumentSnapshot queryResult = querySnapshot.Documents.First();
                users = DataConverter.dictionaryToUser(queryResult.ToDictionary(), queryResult.Id);
            }
            catch (Exception) { }

            // Devuelve el usuario encontrado o null si no se encuentra
            return users;

        }
        catch (Exception e)
        {
            // Si ocurre una excepción en la consulta, lanza una excepción personalizada
            throw new UserServiceException("Error al realizar la operación", e);
        }
    }

    // Método para actualizar los datos de "Characters" de un usuario específico
    public async Task<ObjectResult> putUserCharacters(UserUpdateDTO userCharacters, string id)
    {
        try
        {
            // Referencia al documento del usuario usando el ID proporcionado
            DocumentReference docRef = _usersRef.Document(id);

            // Actualiza los datos del documento con los nuevos valores de los "Characters"
            await docRef.UpdateAsync(DataConverter.ToDictionary(userCharacters));

            // Devuelve un mensaje de éxito
            return Ok(new { message = "Usuario editado correctamente" });
        }
        catch (Exception e)
        {
            // Si ocurre una excepción, devuelve un código de error 400 con detalles
            return StatusCode(400, new { error = "Error al modificar el nivel", details = e.Message });
        }
    }
}
