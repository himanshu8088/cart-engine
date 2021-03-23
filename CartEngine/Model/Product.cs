namespace CartEngine.Model
{
    public class Product: Item
    {
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
    }

    public class ThirdCoupon: Coupon
    {
        public ItemType ApplyOnType { get; set; }
        public int ApplyAt { get; set; }
    }
}
