using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using TFGApi.Dto;
using TFGApi.Models;
using TFGApi.utils;

namespace TFGApi.Repository;

public class LevelRepository : ControllerBase
{
    // Conexión a la base de datos Firestore
    private readonly FirestoreDb _db;
    // Referencia a la colección 'Levels' en Firestore
    private readonly CollectionReference _levelsRef;

    // Constructor que recibe la instancia de DAO y establece la conexión con Firestore
    public LevelRepository(DAO dao)
    {
        _db = dao.GetDbConnection(); // Obtiene la conexión a Firestore
        _levelsRef = _db.Collection("Levels"); // Referencia a la colección 'Levels'
    }

    // Método para agregar un nuevo nivel a la base de datos
    public async Task<IActionResult> AddLevel(LevelInsertDTO level)
    {
        try
        {
            // Convierte el objeto LevelInsertDTO a un diccionario
            var levelData = DataConverter.ToDictionary(level);

            // Agrega el documento a la colección 'Levels' en Firestore
            DocumentReference docRef = await _levelsRef.AddAsync(levelData);

            // Retorna un mensaje de éxito
            return Ok(new
            {
                message = "Nivel agregado correctamente"
            });
        }
        catch (Exception ex)
        {
            // Si ocurre un error, retorna un error con detalles
            return StatusCode(500, new { error = "Error al agregar el nivel", details = ex.Message });
        }
    }

    // Método para obtener los niveles de un usuario específico
    public async Task<ObjectResult> GetLevelsByUser(string user)
    {
        try
        {
            // Realiza una consulta para obtener los niveles del usuario
            Query query = _levelsRef.WhereEqualTo("user", user);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            // Lista para almacenar los niveles del usuario
            List<Level> userLevels = new List<Level>();

            // Itera sobre los resultados y los agrega a la lista
            foreach (DocumentSnapshot queryResult in querySnapshot.Documents)
            {
                userLevels.Add(DataConverter.dictionaryTolevel(queryResult.ToDictionary(), queryResult.Id));
            }

            // Si hay niveles encontrados, los devuelve en la respuesta
            if (userLevels.Count != 0)
            {
                return Ok(new { userLevels });
            }
            else
            {
                // Si no se encuentran niveles, retorna un error
                return StatusCode(404, new { error = "El usuario no ha completado el nivel" });
            }
        }
        catch (Exception e)
        {
            // Si ocurre un error, retorna un error con detalles
            return StatusCode(404, new { error = "El usuario no ha completado el nivel", details = e.Message });
        }
    }

    // Método para obtener los niveles por número
    public async Task<ObjectResult> GetLevelsByNum(string num)
    {
        try
        {
            // Realiza una consulta para obtener los niveles según el número
            Query query = _levelsRef.WhereEqualTo("num", num);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            // Lista para almacenar los niveles según el número
            List<Level> numLevels = new List<Level>();

            // Itera sobre los resultados y los agrega a la lista
            foreach (DocumentSnapshot queryResult in querySnapshot.Documents)
            {
                numLevels.Add(DataConverter.dictionaryTolevel(queryResult.ToDictionary(), queryResult.Id));
            }

            // Si hay niveles encontrados, los devuelve en la respuesta
            if (numLevels.Count != 0)
            {
                return Ok(new { numLevels });
            }
            else
            {
                // Si no se encuentran niveles, retorna un error
                return StatusCode(404, new { error = "El nivel no existe" });
            }
        }
        catch (Exception e)
        {
            // Si ocurre un error, retorna un error con detalles
            return StatusCode(404, new { error = "El nivel no existe", details = e.Message });
        }
    }

    // Método para actualizar los datos de un nivel
    public async Task<ObjectResult> PutUserlevel(LevelUpdateDTO level, string id)
    {
        try
        {
            // Obtiene una referencia al documento del nivel a modificar usando el ID
            DocumentReference docRef = _levelsRef.Document(id);

            // Actualiza los datos del nivel en Firestore
            await docRef.UpdateAsync(DataConverter.ToDictionary(level));

            // Retorna un mensaje de éxito
            return Ok(new { message = "Nivel editado correctamente" });
        }
        catch (Exception e)
        {
            // Si ocurre un error, retorna un error con detalles
            return StatusCode(400, new { error = "Error al modificar el nivel", details = e.Message });
        }
    }
}