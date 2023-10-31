﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Category
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>(); 
    }
}
