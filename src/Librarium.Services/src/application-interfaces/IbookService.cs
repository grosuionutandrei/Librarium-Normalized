using models.api_models;

namespace Librarium.Services.application_interfaces;

public interface IBookService
{
    Task <List<BooksDto>> GetAllBooks();
}