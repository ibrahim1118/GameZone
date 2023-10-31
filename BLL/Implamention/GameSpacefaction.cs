using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implamention
{
    public class GameSpacefaction : Spacefaction<Game>
    {
        public GameSpacefaction()
        {
            Include.Add(g => g.Category);
            Include.Add(g => g.Devices);

        }
    }
}
