
using TFGApi.Dto;
using TFGApi.Repository;
using Microsoft.AspNetCore.Mvc;
using TFGApi.Models;
using System.Text.RegularExpressions;
using TFGApi.Error;

namespace TFGApi.Service;

public class UserService
{
    private readonly UserRepository _userRepository;

    // Constructor que recibe una instancia de UserRepository para la inyección de dependencias
    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository; // Asigna el repositorio de usuarios a la variable de instancia
    }

    // Método para manejar el inicio de sesión de un usuario
    public async Task<ObjectResult> login(UserLoginDTO usuario)
    {
        // Verifica si el nombre de usuario es nulo o está vacío
        if (string.IsNullOrWhiteSpace(usuario.user))
        {
            throw new ArgumentException("El nombre de usuario no puede estar en blanco.");
        }

        // Verifica si la contraseña es nula o está vacía
        if (string.IsNullOrWhiteSpace(usuario.password))
        {
            throw new ArgumentException("La contraseña no puede estar en blanco.");
        }

        // Llama al repositorio para intentar iniciar sesión con las credenciales proporcionadas
        return await _userRepository.login(usuario);
    }

    // Método para manejar el registro de un nuevo usuario
    public async Task<ObjectResult> register(UserRegisterDTO user)
    {
        // Expresión regular para validar el formato de correo electrónico
        string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // Verifica si el nombre de usuario está vacío después de quitar los espacios en blanco
        if (user.usuario.Trim() == "")
        {
            throw new ArgumentException("El nombre de usuario no puede estar en blanco.");
        }

        // Verifica si el usuario ya existe consultando el repositorio
        var checkUserResult = await _userRepository.getUser(user.usuario);

        if (checkUserResult != null)
        {
            // Si el usuario ya existe, lanza una excepción personalizada
            throw new UserNotFoundException("El usuario ya existe");
        }

        // Verifica si las contraseñas son nulas o vacías
        if (string.IsNullOrWhiteSpace(user.password) || string.IsNullOrWhiteSpace(user.repeatPassword))
        {
            throw new ArgumentException("Las contraseñas no pueden estar en blanco.");
        }

        // Verifica si las contraseñas coinciden
        if (user.password != user.repeatPassword)
        {
            throw new ArgumentException("Las contraseñas no coinciden.");
        }

        // Verifica si el correo está vacío
        if (string.IsNullOrWhiteSpace(user.email))
        {
            throw new ArgumentException("El correo no puede estar vacío.");
        }

        // Valida si el formato del correo es correcto utilizando una expresión regular
        if (!Regex.IsMatch(user.email, emailRegex))
        {
            throw new ArgumentException("El formato del correo no es correcto.");
        }

        // Llama al repositorio para registrar el nuevo usuario
        return await _userRepository.register(user);
    }

    // Método para actualizar los datos de "Characters" de un usuario
    public async Task<ObjectResult> putUserCharacters(UserUpdateDTO userCharacters, string user)
    {
        // Verifica si el usuario existe consultando el repositorio
        var checkUserResult = await _userRepository.getUser(user);

        if (checkUserResult == null)
        {
            // Si el usuario no existe, lanza una excepción personalizada
            throw new UserNotFoundException("El usuario no existe");
        }

        // Llama al repositorio para actualizar los "Characters" del usuario
        return await _userRepository.putUserCharacters(userCharacters, checkUserResult.id!);
    }
}
