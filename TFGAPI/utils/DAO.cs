using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

namespace TFGApi.utils;

public class DAO
{
    // Variable privada para almacenar la conexión a Firestore
    private readonly FirestoreDb _db;
    private readonly FirebaseAuth _auth;

    // Constructor que inicializa la conexión a Firestore
    public DAO()
    {
        // Ruta al archivo de credenciales del servicio de Firebase para autenticar la aplicación
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "utils", "certs", "tfg-proyecto-b5f17-firebase-adminsdk-fbsvc-39b6d23c61.json");

        // Configura las credenciales de Google Cloud para acceder a Firestore
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

        var defaultApp = FirebaseApp.Create(new AppOptions(){
            Credential = GoogleCredential.GetApplicationDefault(),
            ProjectId = "tfg-proyecto-b5f17"
        });

        _auth = FirebaseAuth.GetAuth(defaultApp);
        // Crea una nueva instancia de FirestoreDb utilizando el ID del proyecto de Firebase
        _db = FirestoreDb.Create("tfg-proyecto-b5f17");
    }

    // Método para obtener la conexión a Firestore
    public FirestoreDb GetDbConnection()
    {
        // Devuelve la instancia de FirestoreDb creada anteriormente
        return _db;
    }

    public FirebaseAuth GetFirebaseAuth()
    {
        return _auth;
    }

}