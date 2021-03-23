using CartEngine.Core.Strategy;
using CartEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CartEngine.Test.FunctionalTest
{
    public class FirstCouponStrategyTest
    {
        [Fact]
        public void ApplyCoupon_Should_GiveOffByNPercentageOnEachIndivdualItem()
        {
            //Arrange

            var items = new List<Item>()
            {
                new Product()
                {
                    Id = "P1",
                    Price = 10,
                    Type = ItemType.Pen
                },
                new Coupon()
                {
                    Id = "C1",
                    Type = ItemType.FirstCoupon,
                    Discount = new Amount()
                    {
                        Price = 10,
                        Type = AmountType.Percentile
                    }
                },
                new Product()
                {
                    Id = "P2",
                    Price = 20,
                    Type = ItemType.Pen
                },
            };


            var firstCouponStratey = new FirstCouponStrategy();

            //Act
            firstCouponStratey.ApplyCoupon(items, "C1");

            //Assert
            Assert.Equal(9,(items[0] as Product).DiscountedPrice);
            Assert.Equal(18,(items[2] as Product).DiscountedPrice);
        }
    }
}
