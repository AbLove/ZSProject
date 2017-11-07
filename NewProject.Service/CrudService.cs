﻿using NewProject.Data.IService;
using NewProject.Data.Model;
using NewProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NewProject.Service
{
    public class  CrudService<T> : ICrudService<T> where T : DelEntity, new()
    {
        protected IRepo<T> repo;

        public CrudService(IRepo<T> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<T> GetAll()
        {
            return repo.GetAll();
        }

        public T Get(int id)
        {
            return repo.Get(id);
        }

        public virtual int Create(T item)
        {
            var newItem = repo.Insert(item);
            repo.Save();
            return newItem.Id;
        }

        public void Save()
        {
            repo.Save();
        }

        public virtual void Delete(int id)
        {
            repo.Delete(repo.Get(id));
            repo.Save();
        }

        public void Restore(int id)
        {
            repo.Restore(repo.Get(id));
            repo.Save();
        }

        public void BatchDelete(int[] ids)
        {
            foreach (var id in ids)
            {
                repo.Get(id).IsDeleted = true;
            }

            repo.Save();
        }

        public void BatchRestore(int[] ids)
        {
            foreach (var id in ids)
            {
                repo.Get(id).IsDeleted = false;
            }

            repo.Save();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate, bool showDeleted = false)
        {
            return repo.Where(predicate, showDeleted);
        }
    }
}