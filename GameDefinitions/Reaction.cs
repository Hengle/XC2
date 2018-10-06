using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDefinitions
{
    public enum Reaction
    {
        Break = 0,
        Topple = 1,
        Launch = 2,
        Smash = 3,
        //Blowdown is a reaction, but isn't used for combos
        Blowdown = 4,
        Knockback = 4,
    }
}
