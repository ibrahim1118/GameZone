using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISpaceFaction<T> where T : class
    {
        public Expression<Func<T, bool>> where { get;set; }

        public IList<Expression<Func<T,object>>> Include { get; set; }

        
    }
}
