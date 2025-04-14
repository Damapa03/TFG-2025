using Microsoft.AspNetCore.Mvc;
using TFGApi.Dto;
using TFGApi.Error;
using TFGApi.Repository;

namespace TFGApi.Service;

public class LevelService
{
    // Instancia del repositorio de niveles, utilizado para interactuar con la base de datos
    private readonly LevelRepository _levelRepository;
    private readonly UserRepository _userRepository;

    // Constructor que recibe una instancia de LevelRepository y UserRepository (inyección de dependencias)
    public LevelService(LevelRepository levelRepository, UserRepository userRepository)
    {
        _levelRepository = levelRepository; // Se asigna la instancia del repositorio de niveles
        _userRepository = userRepository; // Se asigna la instancia del repositorio de usuarios
    }

    // Método para agregar un nuevo nivel
    public async Task<IActionResult> AddLevel(LevelInsertDTO level)
    {
        // Verifica si el objeto 'level' es nulo
        if (level == null)
        {
            throw new ArgumentException("El objeto LevelInsertDTO no puede ser nulo."); // Si es nulo, se lanza una excepción
        }

        // Verifica si el usuario existe en la base de datos
        var user = await _userRepository.getUser(level.user);
        if (user == null)
        {
            throw new UserNotFoundException("El usuario no existe"); // Si el usuario no existe, se lanza una excepción
        }

        // Verifica si el campo 'num' está vacío
        if (string.IsNullOrWhiteSpace(level.num))
        {
            throw new ArgumentException("El número del nivel no puede estar vacío"); // Si 'num' está vacío, se lanza una excepción
        }

        // Si las validaciones pasan, se llama al repositorio para agregar el nivel
        return await _levelRepository.AddLevel(level); // Se agrega el nivel a la base de datos
    }

    // Método para obtener los niveles de un usuario específico
    public async Task<ObjectResult> GetByUser(string user)
    {
        // Verifica si el usuario existe en la base de datos
        var userLevel = await _userRepository.getUser(user);
        if (userLevel == null)
        {
            throw new UserNotFoundException("El usuario no existe"); // Si el usuario no existe, se lanza una excepción
        }

        // Si el usuario existe, se llama al repositorio para obtener los niveles del usuario
        return await _levelRepository.GetLevelsByUser(user); // Retorna los niveles asociados al usuario
    }

    // Método para obtener los niveles por número
    public async Task<ObjectResult> GetByNum(string num)
    {
        // Verifica si el campo 'num' está vacío
        if (string.IsNullOrWhiteSpace(num))
        {
            throw new ArgumentException("El número del nivel no puede estar vacío"); // Si 'num' está vacío, se lanza una excepción
        }

        // Si la validación pasa, se llama al repositorio para obtener los niveles por número
        return await _levelRepository.GetLevelsByNum(num); // Retorna los niveles correspondientes al número
    }

    // Método para actualizar un nivel específico
    public async Task<ObjectResult> PutLevel(LevelUpdateDTO level, string id)
    {
        // Llama al repositorio para actualizar el nivel con el ID proporcionado
        return await _levelRepository.PutUserlevel(level, id); // Retorna la respuesta del repositorio al actualizar el nivel
    }
}
