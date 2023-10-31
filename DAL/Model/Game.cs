using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }    

        public string Description { get; set; }

        public string Image { get; set; }   

        public int CategoryId { get; set; } 
        public Category  Category { get; set; }

        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();   
    }
}
