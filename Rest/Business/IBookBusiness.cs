using System.Collections.Generic;
using Rest.models;

namespace Rest.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book Update(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        void Delete(long id);
    }
}