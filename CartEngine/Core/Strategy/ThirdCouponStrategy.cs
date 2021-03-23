using CartEngine.Interface;
using CartEngine.Model;
using System.Collections.Generic;
using System.Linq;

namespace CartEngine.Core.Strategy
{
    public class ThirdCouponStrategy : ICouponStrategy
    {
        /// <summary>
        /// D$ in the Nth item of type T in the cart
        /// </summary>
        /// <param name="items"></param>
        /// <param name="couponId"></param>
        public void ApplyCoupon(List<Item> items, string couponId)
        {
            if (items == default || items.Count == 0 || couponId == default)
                return;

            var selectedCoupon = items.FirstOrDefault(x => x.Id == couponId) as ThirdCoupon;

            if (selectedCoupon == default)
                return;

            var selectedProducts = items
                                    .Where(item => item is Product && (item as Product).Type == selectedCoupon.ApplyOnType)
                                    .ToList();
                        
            if(selectedCoupon.ApplyAt <= selectedProducts.Count)
            {
                var selectedProduct = selectedProducts[selectedCoupon.ApplyAt - 1] as Product;
                selectedProduct.DiscountedPrice = selectedProduct.Price - selectedCoupon.Discount.Price;
            }
        }
    }
}
