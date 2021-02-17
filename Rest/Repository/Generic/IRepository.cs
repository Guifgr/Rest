﻿using System.Collections.Generic;
using Rest.models;
using Rest.models.Base;

namespace Rest.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);

        T FindById(long id);

        List<T> FindAll();

        T Update(T item);

        void Delete(long id);

        bool Exists(long id);
    }
}
