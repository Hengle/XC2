namespace GameDefinitions
{
    using System.Collections.Generic;

    // these wont change, so they can be value types that we pass by reference
    public class Combo
    {
        public Combo(List<ComboOrder> comboOrder, string comboName, Element comboFinishType)
        {
            ComboName = comboName;
            ComboFinishType = comboFinishType;
            ComboOrder = comboOrder;
        }

        public string ComboName { get; }

        public Element ComboFinishType { get; }

        public List<ComboOrder> ComboOrder { get; }
    }
}
