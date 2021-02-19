using Rest.models;
using System;
using System.Threading;
using System.Collections.Generic;
using Rest.Models.Context;
using System.Linq;
using Rest.Data.Converter.Implementations;
using Rest.Data.VO;
using Rest.Repository;
using Rest.Repository.Generic;

namespace Rest.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository) 
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindById(long id)       
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
        
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
