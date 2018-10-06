using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDefinitions
{
    public class WeaponReactions
    {
        public WeaponType Type { get; }

        // A given weapon can support multiple or no reactions
        public List<Reaction> Reactions { get; }

        public WeaponReactions(WeaponType type, List<Reaction> reactions)
        {
            Type = type;
            Reactions = reactions;
        }

        public WeaponReactions(WeaponType type, Reaction reaction) : 
            this(type, new List<Reaction> { reaction }) { }

        public WeaponReactions(WeaponType type) : 
            this(type, new List<Reaction>()) { }
    }
}
