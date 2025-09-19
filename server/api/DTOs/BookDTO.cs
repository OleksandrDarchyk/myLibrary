namespace api.DTOs;



public class BookCreateDTO
{

    public string Title { get; set; } = null!;

    public int Pages { get; set; }
}
public class BookReadDto
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int Pages { get; set; } 
    public string? GenreName { get; set; }
 
}

public class BookUpdateDTO
{
    public string Title { get; set; } = null!;
    public int Pages { get; set; }
    
}

public class BookDeleteDTO
{
    public string Id { get; set; } = null!;
}

