﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using _0_FrameWork.Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace _0_FrameWork.Infrasutructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T :class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
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
