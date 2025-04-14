using Google.Cloud.Firestore;

namespace TFGApi.utils;

public class DAO
{
    // Variable privada para almacenar la conexión a Firestore
    private readonly FirestoreDb _db;

    // Constructor que inicializa la conexión a Firestore
    public DAO()
    {
        // Ruta al archivo de credenciales del servicio de Firebase para autenticar la aplicación
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "utils", "certs", "tfg-proyecto-b5f17-firebase-adminsdk-fbsvc-4c124b9bbf.json");

        // Configura las credenciales de Google Cloud para acceder a Firestore
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

        // Crea una nueva instancia de FirestoreDb utilizando el ID del proyecto de Firebase
        _db = FirestoreDb.Create("tfg-proyecto-b5f17");
    }

    // Método para obtener la conexión a Firestore
    public FirestoreDb GetDbConnection()
    {
        // Devuelve la instancia de FirestoreDb creada anteriormente
        return _db;
    }
}