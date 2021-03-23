using CartEngine.Core.Strategy;
using CartEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CartEngine.Test.FunctionalTest
{
    public class SecondCouponStrategyTest
    {
        [Fact]
        public void ApplyCoupon_Should_GiveOffByNPercentageToTheNextItem()
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
                    Id = "C2",
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
                new Product()
                {
                    Id = "P3",
                    Price = 10,
                    Type = ItemType.Pencil
                },
            };


            var secondCouponStratey = new SecondCouponStrategy();

            //Act
            secondCouponStratey.ApplyCoupon(items, "C2");

            //Assert
            Assert.Equal(0,(items[0] as Product).DiscountedPrice);
            Assert.Equal(18,(items[2] as Product).DiscountedPrice);
            Assert.Equal(0,(items[3] as Product).DiscountedPrice);
        }
    }
}
