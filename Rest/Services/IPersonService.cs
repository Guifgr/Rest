using Rest.models;
using System;
using System.Collections.Generic;

namespace Rest.Services
{
    public interface IpersonService
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(long Id);
        List<Person> FindAll();
        void Delete(long Id);
    }
}
