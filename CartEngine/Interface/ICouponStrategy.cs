using CartEngine.Model;
using System.Collections.Generic;

namespace CartEngine.Interface
{
    public interface ICouponStrategy
    {
        void ApplyCoupon(List<Item> items, string couponId);
    }
}
