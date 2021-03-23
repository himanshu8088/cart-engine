using CartEngine.Core.Strategy;
using CartEngine.Model;
using System.Collections.Generic;
using Xunit;

namespace CartEngine.Test.FunctionalTest
{
    public class ThirdCouponStrategyTest
    {
        [Fact]
        public void ApplyCoupon_Should_GivePDollarOffToTheNthItemOfTypeT()
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
                new ThirdCoupon()
                {
                    Id = "C3",
                    Type = ItemType.FirstCoupon,
                    Discount = new Amount()
                    {
                        Price = 4,
                        Type = AmountType.Cash
                    },
                    ApplyAt = 2,
                    ApplyOnType = ItemType.Pen
                },
                new Product()
                {
                    Id = "P2",
                    Price = 20,
                    Type = ItemType.Pen
                },
                new Product()
                {
                    Id = "P2",
                    Price = 15,
                    Type = ItemType.Pencil
                },
            };


            var thirdCouponStrategy = new ThirdCouponStrategy();

            //Act
            thirdCouponStrategy.ApplyCoupon(items, "C3");

            //Assert
            Assert.Equal(0,(items[0] as Product).DiscountedPrice);
            Assert.Equal(16,(items[2] as Product).DiscountedPrice);
            Assert.Equal(0,(items[3] as Product).DiscountedPrice);
        }
    }
}
