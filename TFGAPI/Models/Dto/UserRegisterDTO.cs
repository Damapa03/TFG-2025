namespace TFGApi.Dto;

public record class UserRegisterDTO
(
    string usuario, 
    string password,
    string repeatPassword,
    string email
);