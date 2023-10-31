using BLL.Interfaces;
using DAL.Data;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implamention
{
    public class GenreicRepositry<T> : IGenreicRepositry<T> where T : class
    {
        private readonly AppDbContext context;

        public GenreicRepositry(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<T> GetAll (ISpaceFaction<T> spac)
        {
           var type = typeof(T).Name;
            if (type =="Game")
                return context.Game.Include(g=>g.Category).Include(g=>g.Devices).ThenInclude(d=>d.Device).ToList() as IEnumerable<T>;
            return CreatQuere<T>.Createquere(spac , context.Set<T>()).ToList();
        }

        public void Add(T item)
        {
            context.Set<T>().Add(item); 
            context.SaveChanges();  
        }

        public void Delete(T item)
        {
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }

        public T? GetById(int id)
        {
            var type = typeof(T).Name;
            if (type == "Game")
                return context.Game.Include(g => g.Category).Include(g => g.Devices).ThenInclude(d => d.Device).FirstOrDefault(g=>g.Id==id) as T;
            return context.Set<T>().Find(id); 
        }

        public void Update(T item)
        {
           context.Update(item);
           context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
    }
}
