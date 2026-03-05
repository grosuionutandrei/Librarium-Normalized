
using Librarium.Services.application_interfaces;
using Librarium.Services.application_services.ports;
using models.api_models;

namespace Librarium.Services.application_services.services;

public class BookService(IBookRepository bookRepository):IBookService
{
    public async  Task<List<BooksDto>> GetAllBooks()
    {
        var response = await bookRepository.GetAllBooksAsync();
        return response.Select(b=> new BooksDto(b.Title.Value, b.Isbn.Value, b.PublicationYear.Value)).ToList();
    }
    
}