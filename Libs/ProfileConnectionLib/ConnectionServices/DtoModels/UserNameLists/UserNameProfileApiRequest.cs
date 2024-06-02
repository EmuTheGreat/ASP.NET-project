namespace ProfileConnectionLib.ConnectionServices.DtoModels.UserNameLists;

// "{name}{servicename}{request/response}"
public record UserNameProfileApiRequest
{
    public required uint UserId { get; init; }
}
