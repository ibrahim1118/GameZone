using BLL.Interfaces;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLL.Implamention
{
    public static class CreatQuere<T> where T : class
    {
        public static IQueryable<T> Createquere(ISpaceFaction<T> spac , IQueryable<T> query )
        {
            var quer = query;
            if (spac.where is not null)
                quer = quer.Where(spac.where);

            quer = spac.Include.Aggregate(quer, (a, b) => a.Include(b));
           
            return quer;
        }
    }
}
