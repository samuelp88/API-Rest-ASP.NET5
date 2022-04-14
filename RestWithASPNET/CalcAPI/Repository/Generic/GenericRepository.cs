using CalcAPI.Model.Base;
using CalcAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalcAPI.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;

        private DbSet<T> dataSet;
        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var result = dataSet.SingleOrDefault(p => p.Id.Equals(id));
            if(result != null)
            {
                try
                {
                    _context.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return dataSet.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindById(long id)
        {
            return dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            var result = dataSet.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            } 
            else
            {
                return null;
            }
        }
    }
}
