using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenreicRepositry<T> GenreateRepositry<T>() where T : class;

        public int IsComplite(); 
    }
}
