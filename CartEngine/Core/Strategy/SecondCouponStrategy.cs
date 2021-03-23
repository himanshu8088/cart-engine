using CartEngine.Interface;
using CartEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CartEngine.Core.Strategy
{
    public class SecondCouponStrategy : ICouponStrategy
    {
        /// <summary>
        /// Apply P% of next item in the cart, where P is provided in coupon
        /// </summary>
        /// <param name="items"></param>
        /// <param name="couponId"></param>
        public void ApplyCoupon(List<Item> items, string couponId)
        {
            if (items == default || items.Count == 0 || couponId == default)
                return;

            var couponAtIndex = -1;
            Coupon selectedCoupon = default;
            for (int index = 0; index < items.Count; index++)
            {
                if (string.Equals(items[index].Id, couponId)){
                    couponAtIndex = index;
                    selectedCoupon = items[index] as Coupon;
                }
            }

            if (selectedCoupon == default)
                return;

            var selectedProduct = items
                                     .Skip(couponAtIndex+1)
                                     .ToList()
                                     .FirstOrDefault(item=> item is Product) as Product;
            selectedProduct.DiscountedPrice = (100 - selectedCoupon.Discount.Price)/100 * selectedProduct.Price;
        }
    }
}
