using GameDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRules
{
    public static class ComboList
    {
        // give preference to 
        // total unique number finish types
        // one art per charicter 
        // finishing combos during reaction twords smash ('fusion combo')
        // comboing in multiple ways
        // ordering of the combo from the player user

        // this should be a dictionary of finish type to combo info
        public static readonly List<Combo> Definition = new List<Combo>
        {
            new Combo(
                comboName: "Self-Destruct",
                comboFinishType: Element.Fire,
                comboOrder: new List<ComboOrder>
                {
                    new ComboOrder(Element.Fire, Element.Fire, Element.Fire),
                    new ComboOrder(Element.Fire, Element.Water, Element.Fire),
                    new ComboOrder(Element.Light, Element.Thunder, Element.Fire)
                }),
            new Combo("Stench", Element.Water, new List<ComboOrder>
                {
                    new ComboOrder(Element.Water, Element.Water, Element.Water),
                    new ComboOrder(Element.Thunder, Element.Thunder, Element.Water),
                    new ComboOrder(Element.Light, Element.Light, Element.Water)
                }),
            new Combo("Shackle Driver", Element.Earth, new List<ComboOrder>
                {
                    new ComboOrder(Element.Earth, Element.Fire, Element.Earth),
                    new ComboOrder(Element.Ice, Element.Ice, Element.Earth),
                    new ComboOrder(Element.Wind, Element.Wind, Element.Earth),
                    new ComboOrder(Element.Dark, Element.Dark, Element.Earth)
                }),
            new Combo("Back Attack", Element.Thunder, new List<ComboOrder>
                {
                    new ComboOrder(Element.Earth, Element.Earth, Element.Thunder),
                    new ComboOrder(Element.Wind, Element.Wind, Element.Thunder),
                    new ComboOrder(Element.Dark, Element.Light, Element.Thunder)
                }),
            new Combo ("Shackle Blade", Element.Ice, new List<ComboOrder>
                {
                    new ComboOrder(Element.Fire, Element.Water, Element.Ice),
                    new ComboOrder(Element.Thunder, Element.Fire, Element.Ice),
                    new ComboOrder(Element.Wind, Element.Ice, Element.Ice)
                }),
            new Combo ("Blowdown", Element.Wind, new List<ComboOrder>
                {
                    new ComboOrder(Element.Water, Element.Earth, Element.Wind),
                    new ComboOrder(Element.Fire, Element.Earth, Element.Wind),
                    new ComboOrder(Element.Thunder, Element.Fire, Element.Wind),
                    new ComboOrder(Element.Ice, Element.Water, Element.Wind),
                }),
            new Combo ("Affinity Down", Element.Light, new List<ComboOrder>
                {
                    new ComboOrder(Element.Light, Element.Light, Element.Light)
                }),
            new Combo ("Reinforcements", Element.Dark, new List<ComboOrder>
                {
                    new ComboOrder(Element.Dark, Element.Dark, Element.Dark),
                    new ComboOrder(Element.Water, Element.Water, Element.Dark),
                    new ComboOrder(Element.Ice, Element.Ice, Element.Dark),
                })
        };
    }
}
