using System;
using System.Collections.Generic;
using System.Linq;
using Rest.models;
using Rest.Models.Context;
using Rest.Repository;
using Rest.Repository.Generic;

namespace Rest.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        
        private readonly IRepository<Book> _repository;

        public BookBusinessImplementation(IRepository<Book> repository) 
        {
            _repository = repository;
        }
        
        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}