using TFGApi.Repository;
using TFGApi.Service;
using TFGApi.utils;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios a la contenedor
builder.Services.AddControllers(); // <-- Agregar soporte para controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar servicios de autenticación y autorización
builder.Services.AddAuthorization();

// Registrar DAO como Singleton
builder.Services.AddSingleton<DAO>();

// Registrar LevelService y LevelRepository en la inyección de dependencias
builder.Services.AddScoped<LevelService>();
builder.Services.AddScoped<LevelRepository>();

// Registrar UserService y UserRepository en la inyecciòn de dependencias
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<PasswordHasher>();


var app = builder.Build();

// Configurar el pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

