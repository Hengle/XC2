namespace GameDefinitions
{
    using System.Collections.Generic;

    public class Blade
    {
        public Blade(string name, Element element, Role role, WeaponType weaponType)
        {
            this.Name = name;
            this.Role = role;
            this.Element = element;
            this.WeaponType = weaponType;
        }

        public BladeState State { get; set; } = BladeState.UnusedByDriver;

        // This could be changed to a list of approved names
        public string Name { get; }

        public Element Element { get; }

        public List<Reaction> Reactions { get; set; } = new List<Reaction>();

        public Role Role { get; }

        public WeaponType WeaponType { get; }

        public void AddReactions(List<Reaction> reactions)
        {
            this.Reactions = reactions;
        }
    }
}
