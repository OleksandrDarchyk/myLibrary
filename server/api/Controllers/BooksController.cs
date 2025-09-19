using System.ComponentModel.DataAnnotations;
using api.DTOs;
using api.Services;
using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    // READ (Get All Books)
    [HttpGet]
    public async Task<ActionResult<List<BookReadDto>>> GetAllBooks()
    {
        var result = await bookService.GetBooks();
        return result;
    }

    // CREATE
    [HttpPost]
    public async Task<ActionResult<BookReadDto>> CreateBook([FromBody] BookCreateDTO dto)
    {
        
        var result = await bookService.CreateBook(dto);
        return result;
       
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<ActionResult<BookReadDto>> UpdateBook(string id, [FromBody] BookUpdateDTO dto)
    {
       var result = await bookService.UpdateBook(id, dto);
       return result;
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(string id)
    {
      bool result = await bookService.DeleteBook(id);
     return result ? NoContent() : NotFound();
    }
   // READ (Get Book)
    [HttpGet("{id}")]
    public async Task<ActionResult<BookReadDto>> GetBook(string id)
    {
        var result = await bookService.GetBook(id);
        return result;
    }
}
