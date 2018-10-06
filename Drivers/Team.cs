﻿using GameDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers
{
    public class Drivers
    {
        public List<Driver> Team = new List<Driver>{
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
                    new Blade("Pyra", Role.Attack, Element.Fire, WeaponType.AegisSword),
                    new Blade("Mythra", Role.Attack, Element.Light, WeaponType.AegisSword),
                    new Blade("Roc", Role.Attack, Element.Wind, WeaponType.DualScythes),
                    new Blade("Gorg", Role.Attack, Element.Water, WeaponType.Greataxe),
                    new Blade("Perun", Role.Attack, Element.Ice, WeaponType.Megalance),
                    //new Blade("Electra", Role.Tank, Element.Thunder, WeaponType.SheildHammer),
                    new Blade("Zenobia", Role.Attack, Element.Wind, WeaponType.Greataxe),
                    //new Blade("Spoiler", Role.Attack, Element.Water, WeaponType.CatalystScimitar),
                    //new Blade("Wulfrick", Role.Attack, Element.Earth, WeaponType.Megalance),
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
                    new Blade("Dromarch", Role.Heal, Element.Water, WeaponType.TwinRings),
                    new Blade("Boreas", Role.Heal, Element.Wind, WeaponType.Bitball),
                    new Blade("Floren", Role.Heal, Element.Earth, WeaponType.Bitball),
                    new Blade("Crossette", Role.Heal, Element.Fire, WeaponType.Bitball),
                    new Blade("Ursula", Role.Heal, Element.Ice, WeaponType.KnuckleClaws),
                    new Blade("Adenine", Role.Heal, Element.Wind, WeaponType.KnuckleClaws),
                }),
            new Driver("Torra", 2,
                new List<WeaponReactions>
                {
                    new WeaponReactions(WeaponType.DrillShield, Reaction.Topple),
                    new WeaponReactions(WeaponType.KnuckleClaws, Reaction.Smash),
                }, 
                new List<Blade>
                {
                    new Blade("Poppy a", Role.Tank, Element.Earth, WeaponType.DrillShield),
                    new Blade("Poppy QT", Role.Tank, Element.Fire, WeaponType.KnuckleClaws),
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
                    new Blade("Brigand", Role.Tank, Element.Fire, WeaponType.Whispswords),
                    new Blade("Corbin", Role.Tank, Element.Light, WeaponType.Uchigatana),
                }),
        };
    }
}