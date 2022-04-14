﻿using CalcAPI.Model;
using CalcAPI.Model.Base;
using CalcAPI.Model.Context;
using System.Collections.Generic;

namespace CalcAPI.Repository
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
