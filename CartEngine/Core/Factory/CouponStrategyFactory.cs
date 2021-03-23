using CartEngine.Core.Strategy;
using CartEngine.Interface;
using CartEngine.Model;

namespace CartEngine.Core.Factory
{
    public class CouponStrategyFactory : ICouponStrategyFactory
    {
        public ICouponStrategy GetStrategy(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.FirstCoupon:
                    return new FirstCouponStrategy();

                case ItemType.SecondCoupon:
                    return new SecondCouponStrategy();

                case ItemType.ThirdCoupon:
                    return new ThirdCouponStrategy();

                default:
                    return default;
            }
        }
    }
}
