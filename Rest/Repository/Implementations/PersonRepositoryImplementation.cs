using Rest.models;
using System;
using System.Collections.Generic;
using Rest.Models.Context;
using System.Linq;

namespace Rest.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private readonly MySqlContext _context;

        public PersonRepositoryImplementation(MySqlContext context) 
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.id.Equals(id));
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.id)) return null;

            var result =  _context.Persons.SingleOrDefault(p => p.id.Equals(person.id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return person;
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.id.Equals(id));
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.id.Equals(id));
            if (result != null)
            {
                _context.Persons.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
