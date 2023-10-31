using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenreicRepositry<T> where T : class
    {
        public IEnumerable<T> GetAll(ISpaceFaction<T> space);
        public IEnumerable<T> GetAll();

        public T? GetById (int id);

        public void Add(T item);

        public void Update(T item);

        public void Delete(T item);
    }
}
