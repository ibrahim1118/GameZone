using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Device
    {

        public int  Id { get; set; }

        public string Name { get; set; }    

        public  string Icont { get; set; }
        public ICollection<GameDevice> Games { get; set; } = new  List<GameDevice>();
    }
}
