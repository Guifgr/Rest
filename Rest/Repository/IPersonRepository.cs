using Rest.models;
using System;
using System.Collections.Generic;

namespace Rest.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        void Delete(long id);
        bool Exists(long id);
    }
}
