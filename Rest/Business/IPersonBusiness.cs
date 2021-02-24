﻿using System.Collections.Generic;
using Rest.Data.VO;

namespace Rest.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        List<PersonVO> FindAll();
        PersonVO Disable(long id);
        PersonVO Enable(long id);
        void Delete(long id);
    }
}
