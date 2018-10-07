namespace GameDefinitions
{
    public class ComboOrder
    {
        public Element First { get; }
        public Element Second { get; }

        //A third element doesnt need to be specified since it is always the ComboFinishType that the ComboOrder belongs to
        public Element Third { get; set; }

        public ComboOrder(Element first, Element second, Element third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
}
