using Microsoft.AspNetCore.Mvc;
using TFGApi.Dto;
using TFGApi.Error;
using TFGApi.Service;

namespace TFGApi.Controllers;

[Route("level")]
[ApiController]
public class LevelController : ControllerBase
{
    // Declara una variable privada de solo lectura para el servicio de nivel
    private readonly LevelService _levelService;

    // Constructor del controlador, inyecta el servicio de nivel
    public LevelController(LevelService levelService)
    {
        _levelService = levelService;
    }

    // Método que maneja una solicitud POST para agregar un nuevo nivel
    // Recibe un objeto LevelInsertDTO en el cuerpo de la solicitud y lo pasa al servicio para agregar el nivel
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] LevelInsertDTO level)
    {
        try
        {
            // Llama al servicio para agregar el nivel y devuelve el resultado
            return await _levelService.AddLevel(level);
        }
        catch (ArgumentException ex)
        {
            // Captura excepciones de argumentos inválidos (por ejemplo, datos faltantes)
            return BadRequest(new { error = ex.Message }); // Devuelve un código 400 con el mensaje del error
        }
        catch (UserNotFoundException ex)
        {
            // Captura excepciones cuando el usuario no se encuentra
            return NotFound(new { error = ex.Message }); // Devuelve un código 404 si el usuario no se encuentra
        }
        catch (Exception ex)
        {
            // Captura cualquier otra excepción no manejada
            return StatusCode(500, new { error = "Ocurrió un error inesperado", details = ex.Message }); // Devuelve un código 500 para errores generales
        }
    }

    // Método que maneja una solicitud GET para obtener los niveles asociados a un usuario específico
    // Recibe el nombre del usuario como parámetro de ruta
    [HttpGet("getbyuser/{user}")]
    public async Task<ObjectResult> GetLevelsByUser(string user)
    {
        try
        {
            // Llama al servicio para obtener los niveles por usuario y devuelve el resultado
            return await _levelService.GetByUser(user);
        }
        catch (ArgumentException ex)
        {
            // Captura excepciones de argumentos inválidos (por ejemplo, usuario vacío)
            return BadRequest(new { error = ex.Message }); // Devuelve un código 400 con el mensaje del error
        }
        catch (UserNotFoundException ex)
        {
            // Captura excepciones cuando el usuario no se encuentra
            return NotFound(new { error = ex.Message }); // Devuelve un código 404 si el usuario no se encuentra
        }
        catch (Exception ex)
        {
            // Captura cualquier otra excepción no manejada
            return StatusCode(500, new { error = "Ocurrió un error inesperado", details = ex.Message }); // Devuelve un código 500 para errores generales
        }
    }

    // Método que maneja una solicitud GET para obtener los niveles por número específico
    // Recibe el número como parámetro de ruta
    [HttpGet("getbynum/{num}")]
    public async Task<ObjectResult> GetLevelsByNum(string num)
    {
        try
        {
            // Llama al servicio para obtener los niveles por número y devuelve el resultado
            return await _levelService.GetByNum(num);
        }
        catch (ArgumentException ex)
        {
            // Captura excepciones de argumentos inválidos (por ejemplo, número vacío)
            return BadRequest(new { error = ex.Message }); // Devuelve un código 400 con el mensaje del error
        }
        catch (Exception ex)
        {
            // Captura cualquier otra excepción no manejada
            return StatusCode(500, new { error = "Ocurrió un error inesperado", details = ex.Message }); // Devuelve un código 500 para errores generales
        }
    }

    // Método que maneja una solicitud PUT para actualizar un nivel existente
    // Recibe un objeto LevelUpdateDTO en el cuerpo de la solicitud y el ID del nivel como parámetro de ruta
    [HttpPut("{id}")]
    public async Task<ObjectResult> PutLevel([FromBody] LevelUpdateDTO level, string id)
    {
        try
        {
            // Llama al servicio para actualizar el nivel con el ID y devuelve el resultado
            return await _levelService.PutLevel(level, id);
        }
        catch (ArgumentException ex)
        {
            // Captura excepciones de argumentos inválidos (por ejemplo, datos inválidos)
            return BadRequest(new { error = ex.Message }); // Devuelve un código 400 con el mensaje del error
        }
        catch (Exception ex)
        {
            // Captura cualquier otra excepción no manejada
            return StatusCode(500, new { error = "Ocurrió un error inesperado", details = ex.Message }); // Devuelve un código 500 para errores generales
        }
    }
}