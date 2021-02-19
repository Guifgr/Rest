using Rest.models;
using System;
using System.Collections.Generic;
using Rest.Data.VO;

namespace Rest.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        void Delete(long id);
    }
}
