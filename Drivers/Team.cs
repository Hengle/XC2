namespace Drivers
{
    using System.Collections.Generic;
    using GameDefinitions;

    public class Drivers
    {
        public List<Driver> Team = new List<Driver>
        {
            new Driver("Rex", 4,
                new List<WeaponReactions>
                {
                    new WeaponReactions(WeaponType.AegisSword, Reaction.Topple),
                    new WeaponReactions(WeaponType.Greataxe, Reaction.Launch),
                    new WeaponReactions(WeaponType.Megalance, Reaction.Break),
                    new WeaponReactions(WeaponType.DualScythes, Reaction.Smash),
                    new WeaponReactions(WeaponType.Uchigatana, Reaction.Smash),
                    new WeaponReactions(WeaponType.ChromaKatana, Reaction.Break),
                    new WeaponReactions(WeaponType.KnuckleClaws, Reaction.Blowdown),
                }, 
                new List<Blade>
                {
                    new Blade("Pyra", Element.Fire, Role.Attack, WeaponType.AegisSword),
                    new Blade("Mythra", Element.Light, Role.Attack, WeaponType.AegisSword),
                    new Blade("Roc", Element.Wind, Role.Attack, WeaponType.DualScythes),
                    new Blade("Gorg", Element.Water, Role.Attack, WeaponType.Greataxe),
                    new Blade("Perun", Element.Ice, Role.Attack, WeaponType.Megalance),
                    //new Blade("Electra", Role.Tank, Element.Thunder, WeaponType.SheildHammer),
                    new Blade("Zenobia", Element.Wind, Role.Attack, WeaponType.Greataxe),
                    new Blade("Zenobia", Element.Wind, Role.Attack, WeaponType.Greataxe),
                    //new Blade("Spoiler", Role.Attack, Element.Water, WeaponType.CatalystScimitar),
                    new Blade("Wulfrick", Element.Earth, Role.Attack, WeaponType.Megalance),
                    //
                }),
            new Driver("Nia", 3,
                new List<WeaponReactions>
                {
                    new WeaponReactions(WeaponType.TwinRings, Reaction.Break),
                    new WeaponReactions(WeaponType.Greataxe, Reaction.Topple),
                    new WeaponReactions(WeaponType.Megalance),
                    new WeaponReactions(WeaponType.Bitball, Reaction.Break),
                    new WeaponReactions(WeaponType.EtherCannon, Reaction.Break),
                    new WeaponReactions(WeaponType.SheildHammer, Reaction.Knockback),
                    new WeaponReactions(WeaponType.ChromaKatana),
                    new WeaponReactions(WeaponType.KnuckleClaws, new List<Reaction>{Reaction.Launch, Reaction.Knockback}),
                }, 
                new List<Blade>
                {
                    new Blade("Dromarch", Element.Water, Role.Heal, WeaponType.TwinRings),
                    new Blade("Boreas", Element.Wind, Role.Heal, WeaponType.Bitball),
                    new Blade("Floren", Element.Earth, Role.Heal, WeaponType.Bitball),
                    new Blade("Crossette", Element.Fire, Role.Heal, WeaponType.Bitball),
                    new Blade("Ursula", Element.Ice, Role.Heal, WeaponType.KnuckleClaws),
                    new Blade("Adenine", Element.Wind, Role.Heal, WeaponType.KnuckleClaws),
                }),
            new Driver("Torra", 2,
                new List<WeaponReactions>
                {
                    new WeaponReactions(WeaponType.DrillShield, Reaction.Topple),
                    new WeaponReactions(WeaponType.KnuckleClaws, Reaction.Smash),
                }, 
                new List<Blade>
                {
                    new Blade("Poppy a", Element.Earth, Role.Tank, WeaponType.DrillShield),
                    new Blade("Poppy QT", Element.Fire, Role.Tank, WeaponType.KnuckleClaws),
                    //new Blade("Poppy QTpi", Role.Attack, Element.Ice, WeaponType.VariableSaber),
                }),
            new Driver("Morag", 3,
                new List<WeaponReactions>
                {
                    new WeaponReactions(WeaponType.Uchigatana, Reaction.Smash),
                    new WeaponReactions(WeaponType.Whispswords, Reaction.Smash),
                },
                new List<Blade>
                {
                    new Blade("Brigand", Element.Fire, Role.Tank, WeaponType.Whispswords),
                    new Blade("Corbin", Element.Light, Role.Tank, WeaponType.Uchigatana),
                    new Blade("Perceval", Element.Dark, Role.Tank, WeaponType.Uchigatana),
                }),
        };
    }
}
