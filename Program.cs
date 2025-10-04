////User registration and authentication (login/logout)
//Item listing for trade
///Browsing other users' items
//Requesting trades for items
//Managing trade requests (accept/deny)
//Viewing completed trades

using Trading_System;

class Program
{
    static void Main(string[] args)
    {
        // Load saved data from file system at startup
        //  program resumes with previous users, items, and trades
        User user = User.LoadFromFile();
        Item item = Item.LoadFromFile();
        Trade trade = Trade.LoadFromFile();


        //  Main Trading System menu until Exit
        while (true)
        {
            //Main menu option
            Console.WriteLine("\n=== Trading System Menu ===");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Logout");
            Console.WriteLine("4. Upload Item");
            Console.WriteLine("5. Browse Items");
            Console.WriteLine("6. Request Trade");
            Console.WriteLine("7. Browse Trade Requests");
            Console.WriteLine("8. Accept Trade");
            Console.WriteLine("9. Deny Trade");
            Console.WriteLine("10. Browse Completed Trades");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();
            Console.WriteLine();

            //User input according to Case
            switch (choice)
            {
                case "1":
            //Register new user
                    user.Register();
                    user.SaveToFile(); //assign
                    break;

                case "2":
            // Log in an existing user
                    user.Login();
                    break;

                case "3":
            // Log out current user
                    user.Logout();
                    break;

                case "4":
            // user upload items
                    if (user.CurrentUser != null)
                        item.UploadItem(user.CurrentUser.Email);
                    else
                        Console.WriteLine("You must be logged in.");
                    break;

                case "5":
            // User Browse items
                    if (user.CurrentUser != null)
                        item.BrowseItems(user.CurrentUser.Email);
                    else
                        Console.WriteLine("You must be logged in.");
                    break;

                case "6":
            // User can Request trades
                    if (user.CurrentUser != null)
                    {
                        trade.RequestTrade(user.CurrentUser.Email);
                        trade.SaveToFile(); // Save after request
                    }
                    else
                        Console.WriteLine("You must be logged in.");
                    break;

                case "7":
                // Incoming Trade requests
                    if (user.CurrentUser != null)
                        trade.BrowseRequests(user.CurrentUser.Email);
                    else
                        Console.WriteLine("You must be logged in.");
                    break;
                
                case "8":
                // Accept trade and save the updated status
                    if (user.CurrentUser != null)
                    {
                        trade.AcceptTrade(user.CurrentUser.Email);
                        trade.SaveToFile(); //  Save after accept
                    }
                    else
                        Console.WriteLine("You must be logged in.");
                    break;

                case "9":
                // Deny a trade and save the updated status
                    if (user.CurrentUser != null)
                    {
                        trade.DenyTrade(user.CurrentUser.Email);
                        trade.SaveToFile(); // Save after deny
                    }
                    else
                        Console.WriteLine("You must be logged in.");
                    break;

                case "10":
                // Completed trades accepted/denied
                    if (user.CurrentUser != null)
                        trade.BrowseCompleted(user.CurrentUser.Email);
                    else
                        Console.WriteLine("You must be logged in.");
                    break;

                case "0":
                    // Save all data before exit
                    user.SaveToFile();
                    item.SaveToFile();
                    trade.SaveToFile();
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                // Handle invalid input
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}