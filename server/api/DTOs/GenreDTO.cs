namespace api.DTOs;

public class GenreCreateDTO
{
    public string Name { get; set; } = null!;
}

public class GenreUpdateDTO
{
    public string Name { get; set; } = null!;
    public string? Id { get; set; }
    
}

public class GenreReadDTO
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    
}