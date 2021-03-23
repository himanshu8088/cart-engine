using CartEngine.Interface;
using CartEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartEngine.Core.Service
{
    public class CartService : ICartService
    {
        private readonly ICouponStrategyFactory _couponStrategyFactory;

        public CartService(ICouponStrategyFactory couponStrategyFactory)
        {
            _couponStrategyFactory = couponStrategyFactory;
        }

        public void CalculateTotalPrice(Cart cart)
        {
            if (cart == default)
                return;

            foreach(var item in cart.Items)
            {
                var couponStrategy = _couponStrategyFactory.GetStrategy(item.Type);
                if (couponStrategy == default)
                    continue;
                couponStrategy.ApplyCoupon(cart.Items, item.Id);
            }
            cart.TotalPrice = cart.Items
                                  .Where(item => item is Product)
                                  .Sum(item => (item as Product).DiscountedPrice);
        }

    }
}
