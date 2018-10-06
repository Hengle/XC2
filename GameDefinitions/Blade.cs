using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDefinitions
{
    public class Blade
    {
        public BladeState State { get; set; } = BladeState.UnusedByDriver;

        // This could be changed to a list of approved names
        public string Name { get; }
        public Element Element { get; }
        public List<Reaction> Reactions { get; set; } = new List<Reaction>();
        public Role Role { get; }
        public WeaponType WeaponType { get; }
        public Blade(string name, Role role, Element element, WeaponType weaponType)
        {
            Name = name;
            Role = role;
            Element = element;
            WeaponType = weaponType;
        }

        public void AddReactions(List<Reaction> reactions)
        {
            Reactions = reactions;
        }
    }
}
