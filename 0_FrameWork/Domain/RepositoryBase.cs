﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_FrameWork.Domain
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T :class
    {
        private readonly DbContext _context;
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }
        public void Creat(T entity)
        {
            _context.Add(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public T Get(TKey Id)
        {
            return _context.Find<T>(Id);
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
