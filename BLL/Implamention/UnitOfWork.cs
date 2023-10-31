using BLL.Interfaces;
using DAL.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implamention
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        private Hashtable Repositry; 
        public UnitOfWork(AppDbContext context)
        {
            Repositry= new Hashtable();
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();  
        }

        public int IsComplite()
        {
           return context.SaveChanges();
        }

        public IGenreicRepositry<T> GenreateRepositry<T>() where T : class
        {
            var type = typeof(T).Name;
            if (!Repositry.ContainsKey(type))
            {
                Repositry.Add(type, new GenreicRepositry<T>(context));
            }
            return Repositry[type] as IGenreicRepositry<T>;
        }
    }
}
