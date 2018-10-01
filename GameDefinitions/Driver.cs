using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDefinitions
{
    public class Driver
    {
        // This could be changed to a list of approved names
        public string Name { get; }
        public int MaxBlades;
        public List<WeaponReactions> Weapons { get; }
        public List<Blade> Blades { get; }
        public Driver(string name, int maxBlades, List<WeaponReactions> weapons, List<Blade> blades)
        {
            Name = name;
            MaxBlades = maxBlades;
            Weapons = weapons;
            Blades = blades;
        }
    }
}
