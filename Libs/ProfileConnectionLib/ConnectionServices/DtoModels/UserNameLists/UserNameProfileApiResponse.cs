namespace ProfileConnectionLib.ConnectionServices.DtoModels.UserNameLists;

public record UserNameProfileApiResponse
{
    public required uint UserId { get; init; }
    
    public required string Name { get; init; }
}
