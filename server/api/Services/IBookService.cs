using api.DTOs;
using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public interface IBookService
{
    Task<BookReadDto> CreateBook(BookCreateDTO dto);
    Task<BookReadDto> UpdateBook(string id, BookUpdateDTO dto);
    Task<BookReadDto> GetBook(string id);
    Task<List<BookReadDto>> GetBooks();
    Task<bool> DeleteBook(string id);
    
}

public class BookService(MyDbContext dbContext): IBookService
{
    public async Task<BookReadDto> CreateBook(BookCreateDTO dto)
    {
       
        var book = new Book
        {
            Id = Guid.NewGuid().ToString(),
            Title = dto.Title,
            Pages = dto.Pages,
            Createdat = DateTime.UtcNow
        };
        
        dbContext.Books.Add(book); 
         await dbContext.SaveChangesAsync();


        return new BookReadDto()
        {
            Id = book.Id,
            Title = book.Title,
            Pages = book.Pages,
        };
    }

    public async Task<BookReadDto> UpdateBook(string id, BookUpdateDTO dto)
    {
        var book = new Book
        {
            Id = id,
            Title = dto.Title,
            Pages = dto.Pages
        };

        dbContext.Books.Update(book);
        dbContext.SaveChanges();


        return new BookReadDto()
        {
            Title = book.Title,
            Pages = book.Pages,
        };
    }

    public Task<BookReadDto> GetBook(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<BookReadDto>> GetBooks()
    {
        var books = await dbContext.Books
            .Select(book => new BookReadDto
            {
                Id = book.Id,
                Title = book.Title,
                Pages = book.Pages,
            })
            .ToListAsync();

        return books;
    }

    public async Task<bool> DeleteBook(string id)
    {
        var book = dbContext.Books.Find(id);    
        if(book == null) return false;
        
        dbContext.Books.Remove(book);
        await dbContext.SaveChangesAsync();
        
        return true;
    }
}