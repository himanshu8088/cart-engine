namespace CartEngine.Model
{
    public class Item
    {
        public ItemType Type { get; set; }
        public string Id { get; set; }
    }

    public enum ItemType { Pen, Pencil, FirstCoupon, SecondCoupon, ThirdCoupon }
}
