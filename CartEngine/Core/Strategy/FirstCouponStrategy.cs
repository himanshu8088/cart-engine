using CartEngine.Interface;
using CartEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CartEngine.Core.Strategy
{
    public class FirstCouponStrategy : ICouponStrategy
    {
        /// <summary>
        /// Apply N% of each indivdual item in the cart, where N is provided in coupon
        /// </summary>
        /// <param name="items"></param>
        /// <param name="couponId"></param>
        public void ApplyCoupon(List<Item> items, string couponId)
        {
            if (items == default || items.Count == 0 || couponId == default)
                return;

            var selectedCoupon = items.FirstOrDefault(x => x.Id == couponId) as Coupon;
            var selectedItems = items.Where(item => item is Product).ToList();
            selectedItems.ForEach(item => {
                var product = item as Product;
                product.DiscountedPrice = (100 - selectedCoupon.Discount.Price)/100 * product.Price;
            });
        }
    }
}
