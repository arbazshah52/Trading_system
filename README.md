# Trading System (C# Console App)

This is a console-based trading platform built in C#. Users can register, log in, upload items, and trade with others. All data is saved locally using text files.

**#  Support Following file           ##**

1.**Program.cs** 
* Controls the main flow of the application. Handles user input, menu navigation, and coordinates actions like login, upload, and trade.

2. ## item.cs

* Handles item uploading, browsing, and sorting. Stores item data in `items.txt`.

3. ## User.cs

* Manages user registration, login, logout, and tracking. Uses composition to store and retrieve user data from `users.txt`.

4. ## Trade.cs

* Manages trade requests, incoming offers, accept/deny logic, and completed trades. Stores trade data in `trades.txt`.
* it uses composition to trade data logic,stores all trade information in a text files.

5. ## users.txt
Stores registered users in the format like email,password

6. ## Items.txt
Stores uploaded in the format like owner email,item name and discription

7. ## Trades.txt
Stores trade requests in the format like sender email,receiver email ,sender item,receiver item and status


**##  As user how use the following features    ##**

1. Register
arbazhussian067@gmail.com
786786
 2. Login 

 3. Logout 

 4. Upload Item 
 ##  item name and description
 ##  Saves item to "items.txt" with owner’s email

 5. Browse Items 
 ##  Filterout current user item
 ##  showitem name,discription and owner

 6. Request Trade 
 ##  Receiver email, sender's item and receiver item
 ##  New trade with status and update"trades.txt"

 7. Browse Trade Requests 
 ## Receiver Email == Currentuser Email
 ## Display sender info,offered item and requested item

 8. Accept Trade 
## Trade status and save to "Trades.txt"

 9. Deny Trade 
## Denied trade status and save to Trades.txt"

 10. Browse Completed Trades 
 ##  Show sender,reciver and final status

 0. Exit Choose an option: 0
 ## save all user,item and trade data

## How to run
1. open terminal in the project folder
2. Run: dotnet run
3. Follow the menu prompts to interact with the system


**> ## I attached Screen shot of my Project##**
Items collection: ![alt text](<Screenshot 2025-10-04 130150.png>)
Main Features: ![alt text](<Screenshot 2025-10-04 130012.png>)
Final view : ![alt text](<Screenshot 2025-10-04 163108.png>)

##  Design Choices

- Used composition instead of inheritance for simplicity  
- Modular structure: each class handles a specific responsibility  
- Text-based persistence for easy inspection and debugging  
- Enum used for trade status to improve readability and control



**### Requirment to run this program**
.net 8.0
Visual studio code

## Author Name
Syed Arbaz Hussain shah
Student| NBI 
