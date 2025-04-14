namespace TFGApi.Models;
public record class Level
(
    string? id,
    string num,
    string user,
    int score = 0,
    int gems = 0
);