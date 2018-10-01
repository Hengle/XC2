using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDefinitions
{
    // these wont change, so they can be value types that we pass by reference
    public class Combo
    {
        public string ComboName { get; }
        public Element ComboFinishType { get; }
        public List<ComboOrder> ComboOrder { get; }

        public Combo(string comboName, Element comboFinishType, List<ComboOrder> comboOrder)
        {
            ComboName = comboName;
            ComboFinishType = comboFinishType;
            ComboOrder = comboOrder;
        }
    }
}
