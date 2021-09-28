# Ivy Inventory System

This is the beginning of our new Ivy inventory system. 
It's currently not doing much, and we need your help to add a few features:

Requirements:
  * To run this code you need .NET 5 (SDK) installed: https://dotnet.microsoft.com/download 

Tasks:
  * We need to make sure the items are available in stock before being able to place an order
  * Calculate shipping cost for the entire order using the weight/quantity of each product. The current formula is:
    * Between 0 and 500g: $1 for each 100g
    * Anything above 500g: $1 for each additional 200g
    * Examples: 0g..99g = $1, 100g..199g = $2, 200g..299 = $3, 300g..399g = $4, 400g..499g = $5, 500g..599g = $6, 600g..699g = $6, 700g..799g = $7, 800g..899g = $7, 900g..999g = $8 
  * Bonus: Customers like discounts so we need to support coupons. Here are the rules:
    * Only one coupon per product
    * If an order contains several products of the same kind the coupon applies to all. For example, if there are 5 pencils at $2 each, a $.5 coupon would reduce the price per pencil from $2 to $1.5 for a total of 5 x $1.5 = $7.5 for the order
    * A coupon should have a maximum dollar amount discount. In the example above, if the coupon discount is $2.5 (5 x $2 - 5 x $1.5 = $2.5), so we'd want to limit that to $2 (the coupon discount maximum).

Notes:
  * Please refactor as needed to make the code clean / understandable
  * Fix missing functionality
  * Add new tests for new functionality