using Rest.models;
using System;
using System.Threading;
using System.Collections.Generic;
using Rest.Models.Context;
using System.Linq;

namespace Rest.Services.Implementations
{
    public class PersonServiceImplementation : IpersonService
    {
        private MySqlContext _context;

        public PersonServiceImplementation(MySqlContext context) 
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result =  _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

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

        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

        public void Delete(long Id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(Id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
    }
}
