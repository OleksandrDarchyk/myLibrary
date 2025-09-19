namespace api.DTOs;

public class AuthorReadDTO
{
    
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;
    
}

public class AuthorCreateDTO
{
    public string Name { get; set; } = null!;
    
}

public class AuthorUpdateDTO
{
    public string Name { get; set; } = null!;
    
}