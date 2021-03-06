﻿using System.Collections.Generic;
using Rest.models;
using Rest.Repository.Generic;

namespace Rest.Repository.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
        Person Enable(long id);
        List<Person> FindByName(string firstName, string lastName);
    }
}