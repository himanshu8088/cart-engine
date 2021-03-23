using CartEngine.Model;

namespace CartEngine.Interface
{
    public interface ICouponStrategyFactory
    {
        ICouponStrategy GetStrategy(ItemType itemType);
    }
}
