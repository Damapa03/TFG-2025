namespace TFGApi.Dto;


public record class LevelInsertDTO
(
    string num,
    string user,
    int? score,
    int? gems
);