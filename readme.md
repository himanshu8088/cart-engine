## Problem Statement

Cart, Items

Cart.TotalPrice

Item - Coupen or Product

1. N% of each indivdual item in the cart
2. P% of next item in the cart
3. D$ in the Nth item of type T in the cart

10$
2$ 
25%
10%

## Requirements

cart - list items
cart - total price

we can add coupen, it should be extensible

-------------------


## Classes

Cart
	- Items
	- TotolPrice()

Item

Product
	- type
	- price
	- desc
	- discounted-price

Coupen : Item
	- id
	- discount: Amount

Amount
	type: percentile, cash
	price: decimal

## Interfaces

ICartService
	- cart
	- GetTotalPrice

CartService : ICartService 


ICoupenStrategyFactory 
	- GetStrategy: ICoupenStrategy
ICoupenStrategy - 1sCoupentStragy, 2ndCoupenStrategy, 3rdCoupenStrategy
	- ApplyCoupen(cart, coupen): decimal
	

## Implementation

public class 2nCoupenStrategy{
	
	public decimal ApplyCoupen(items, coupen){
		for(var index=0; index<items.Count; index++){
			if(items[index].id == coupen.id){
				var afterCurrentItems = items.Take(index+1);
				var nextItem = afterCurrentItems.FirstOrDefault( x=> x is Product);
				nextItem.Discounted = (100 - coupen.Discount.Price) * nextItem.Price;
			}
		}
	}

}

public class CartService : ICartService{
	
	constructor(ICoupenStrategyFactory factory){
		_factorty = factory;
		_cart = new Cart();
	}

	public decimal GetTotalPrice(Cart cart){
		decimal cartPrice ;
		foreach(var item in cart.items){
			var strategy = _factory.GetStrategy(item);
			if(stragegy){
				strategy.ApplyCoupen(items, item);
			}
			cart+= afterCoupenDiscoutedPrice;
		}
		return cartPrice;
	}
}



