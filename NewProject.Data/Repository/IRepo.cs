﻿using NewProject.Data.Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NewProject.Data.Repository
{
    public interface IRepo<T> where T : Entity
    {
        T Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false);
        T Insert(T o);
        void Save();
        void Delete(T o);
        void Restore(T o);
    }
}