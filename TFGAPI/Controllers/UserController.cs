using Microsoft.AspNetCore.Mvc;
using TFGApi.Dto;
using TFGApi.Error;
using TFGApi.Models;
using TFGApi.Service;

namespace TFGApi.Controllers;

[ApiController] // Marca esta clase como un controlador de API
[Route("user")] // Define la ruta base para este controlador
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService; // Inyección de dependencias para el servicio de usuario
    }

    // Endpoint para registrar un usuario
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDTO user)
    {
        try
        {
            return await _userService.register(user);
        }
        catch (UserNotFoundException ex)
        {
            return NotFound(new { error = ex.Message }); // Devuelve 404 si el usuario ya existe
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message }); // Devuelve 400 si hay un error en los datos de entrada
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Error interno del servidor", details = ex.Message });
        }
    }

    // Endpoint para iniciar sesión
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
    {
        try
        {
            return await _userService.login(user);
        }
        catch (UserNotFoundException ex)
        {
            return NotFound(new { error = ex.Message }); // Devuelve 404 si el usuario no existe
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message }); // Devuelve 400 si las credenciales son incorrectas
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Error interno del servidor", details = ex.Message });
        }
    }

    // Endpoint para actualizar los personajes del usuario
    [HttpPut("{user}")]
    public async Task<IActionResult> PutUserCharacters([FromBody] UserUpdateDTO characters, string user)
    {
        try
        {
            return await _userService.putUserCharacters(characters, user);
        }
        catch (UserNotFoundException ex)
        {
            return NotFound(new { error = ex.Message }); // Devuelve 404 si el usuario no existe
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message }); // Devuelve 400 si hay datos incorrectos
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Error interno del servidor", details = ex.Message });
        }
    }
}