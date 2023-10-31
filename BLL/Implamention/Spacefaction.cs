using BLL.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implamention
{
    public class Spacefaction<T> : ISpaceFaction<T> where T : class
    {
        public Expression<Func<T, bool>> where { get; set; }
        public IList<Expression<Func<T, object>>> Include { get; set; } = new  List<Expression<Func<T, object>>>();

        public Spacefaction(Expression<Func<T, bool>> where)
        {
            this.where = where;
           

        }
        public Spacefaction()
        {

        }
    }
}
