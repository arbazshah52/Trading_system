# Trading System (C# Console App)

This is a console-based trading platform built in C#. Users can register, log in, upload items, and trade with others. All data is saved locally using text files.

**#  Support Following file           ##**

1.**Program.cs** 
* To run the whole system like save data from user.text,item.txt and trades.txt 
* ensure the login user

2. ## item.cs

* item file defines the logic for uploading,sorting and browsing item.it  
* it uses compisition to item realted functionally

3. ## User.cs

* User fil handles all user realted including registration,login,logout and tracking
* it uses compisition to user data ,logic and strore all user information.

4. ## Trade.cs

* In this file handles all trade realted including creating trade request,browsing incoming request,accepting/denay and completed trades.
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


**> ## I attached Screen shot of my Project##**
![alt text](<Screenshot 2025-10-04 130150.png>)
![alt text](<Screenshot 2025-10-04 130012.png>)
![alt text](<Screenshot 2025-10-04 163108.png>)



**### Requirment to run this program**
.net 8.0
Visual studio code
