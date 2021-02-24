using System.Collections.Generic;
using Rest.Data.VO;
using Rest.Utils;

namespace Rest.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindByName(string firstName, string lastName);
        List<PersonVO> FindAll();
        PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        PersonVO Disable(long id);
        PersonVO Enable(long id);
        void Delete(long id);
    }
}
