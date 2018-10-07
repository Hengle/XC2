using System.Collections.Generic;
using System.Linq;

namespace GameDefinitions
{
    public class Driver
    {
        public Driver(string name, int maxBlades, List<WeaponReactions> weapons, List<Blade> blades)
        {
            Name = name;
            MaxBlades = maxBlades;
            WeaponReactions = weapons;
            Blades = blades;
            Blades.ForEach(x => x.AddReactions(this.WeaponReactions.First(y => y.Type == x.WeaponType).Reactions));
        }

        // This could be changed to a list of approved names
        public string Name { get; }

        public int MaxBlades { get; }

        public List<WeaponReactions> WeaponReactions { get; }

        public List<Blade> Blades { get; }
    }
}
