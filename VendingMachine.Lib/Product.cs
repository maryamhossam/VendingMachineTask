namespace VendingMachine.Lib
{
    public struct Product
    {
        public Product(int index, string name, int price)
        {
            Price = price;
            Index = index;
            Name = name;
        }

        public string Name { get; }
        public int Index { get; }
        public int Price { get; }
    }
}