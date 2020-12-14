# VendingMachine
A simple .net application using .NET Core 3.1, .NET standard 2.1 and Angular.

**Note the UI is very simple, does not follow the best practice, it is just to show case and test the .net code.**

## Description
We would like you to create a model of virtual vending machine
[(https://en.wikipedia.org/wiki/Vending_machine).](%28https://en.wikipedia.org/wiki/Vending_machine%29.) Complex UI is not required, just make
sure that the requirements are covered.

In the case of a missing requirement please come up with a reasonable solution and
document your decision.
Initial data
Vending machine contains the following products:

 1. Tea (1.30 eur), 10 portions
 2.  Espresso (1.80 eur), 20 portions 
 3.  Juice (1.80 eur), 20 portions
 4.  Chicken soup (1.80 eur), 15 portions

At the start the vending machine wallet contains the following coins (for exchange):

 1. 10 cent 100 coins 
 2. 20 cent, 100 coins 
 3. 50 cent, 100 coins
 4.  1 euro, 100 coins
 
The customer has an unlimited supply of coins.
Vending machine should support the following features:
Accept coins

Customer should be able to insert coins to the vending machine.

Return coins

Customer should be able to take back the inserted coins in case customer decides to
cancel his purchase.

Sell a product

Customer should be able to buy a product:

● If the product price is less than the deposited amount, Vending machine should
show a message “Thank you” and return the difference between the inserted
amount and the price using the smallest number of coins possible.

● If the product price is higher than the amount inserted, Vending machine should
show a message “Insufficient amount”
The amount and type of coins returned should be shown by the UI.
