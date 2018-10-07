namespace GameRules
{
    using System.Collections.Generic;
    using GameDefinitions;

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
                comboOrder: new List<ComboOrder>
                {
                    new ComboOrder(Element.Fire, Element.Fire, Element.Fire),
                    new ComboOrder(Element.Fire, Element.Water, Element.Fire),
                    new ComboOrder(Element.Light, Element.Thunder, Element.Fire)
                },
                comboName: "Self-Destruct",
                comboFinishType: Element.Fire),
            new Combo(
                new List<ComboOrder>
                {
                    new ComboOrder(Element.Water, Element.Water, Element.Water),
                    new ComboOrder(Element.Thunder, Element.Thunder, Element.Water),
                    new ComboOrder(Element.Light, Element.Light, Element.Water)
                },
                "Stench",
                Element.Water),
            new Combo(
                new List<ComboOrder>
                {
                    new ComboOrder(Element.Earth, Element.Fire, Element.Earth),
                    new ComboOrder(Element.Ice, Element.Ice, Element.Earth),
                    new ComboOrder(Element.Wind, Element.Wind, Element.Earth),
                    new ComboOrder(Element.Dark, Element.Dark, Element.Earth)
                },
                "Shackle Driver",
                Element.Earth),
            new Combo(
                new List<ComboOrder>
                {
                    new ComboOrder(Element.Earth, Element.Earth, Element.Thunder),
                    new ComboOrder(Element.Wind, Element.Wind, Element.Thunder),
                    new ComboOrder(Element.Dark, Element.Light, Element.Thunder)
                }, "Back Attack",
                Element.Thunder),
            new Combo (
                new List<ComboOrder>
                {
                    new ComboOrder(Element.Fire, Element.Water, Element.Ice),
                    new ComboOrder(Element.Thunder, Element.Fire, Element.Ice),
                    new ComboOrder(Element.Wind, Element.Ice, Element.Ice)
                },
                "Shackle Blade",
                Element.Ice),
            new Combo (
                new List<ComboOrder>
                {
                    new ComboOrder(Element.Water, Element.Earth, Element.Wind),
                    new ComboOrder(Element.Fire, Element.Earth, Element.Wind),
                    new ComboOrder(Element.Thunder, Element.Fire, Element.Wind),
                    new ComboOrder(Element.Ice, Element.Water, Element.Wind),
                },
                "Blowdown",
                Element.Wind),
            new Combo (
                new List<ComboOrder>
                {
                    new ComboOrder(Element.Light, Element.Light, Element.Light)
                },
                "Affinity Down",
                Element.Light),
            new Combo (
                new List<ComboOrder>
                {
                    new ComboOrder(Element.Dark, Element.Dark, Element.Dark),
                    new ComboOrder(Element.Water, Element.Water, Element.Dark),
                    new ComboOrder(Element.Ice, Element.Ice, Element.Dark),
                },
                "Reinforcements",
                Element.Dark)
        };
    }
}
