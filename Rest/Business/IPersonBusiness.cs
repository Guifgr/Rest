using Rest.models;
using System;
using System.Collections.Generic;

namespace Rest.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        void Delete(long id);
    }
}
