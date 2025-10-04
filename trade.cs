using System;
using System.Collections.Generic;
using System.IO;

namespace Trading_System
{
    // Enum to represent status of Trade
    public enum TradeStatus
    {
        Pending,    // Trade requested but not responded to
        Accepted,   // Trade accepted by the receiver
        Denied,     // Trade denied by the receiver
        Completed   // Reserved for future extension
    }

    public class Trade
    {
        // Represents a single trade request
        public class TradeData
        {
            public string SenderEmail { get; set; } = string.Empty;            // Email of the user who starts the trade
            public string ReceiverEmail { get; set; } = string.Empty;          // Email of the user receiving the trade
            public string SenderItemName { get; set; } = string.Empty;         // Item offered by the sender
            public string ReceiverItemName { get; set; } = string.Empty;       // Item requested from the receiver
            public TradeStatus Status { get; set; }                           // Current status of the trade
}                    
        }

        // File path for trade storage
        private const string FilePath = "trades.txt";

        // Stores all trade requests in memory
        public List<TradeData> Trades = new List<TradeData>();

        //  Removed constructor to prevent recursion

        // Allows a user to request a trade with another user
        public void RequestTrade(string senderEmail)
        {
            Console.Write("Enter receiver's email: ");
            string receiverEmail = Console.ReadLine() ?? "";
            Console.Write("Enter your item name: ");
            string senderItem = Console.ReadLine() ?? "";
            Console.Write("Enter receiver's item name: ");
            string receiverItem = Console.ReadLine() ?? "";
            
          // create and add new trade to the List
            Trades.Add(new TradeData
            {
                SenderEmail = senderEmail,
                ReceiverEmail = receiverEmail,
                SenderItemName = senderItem,
                ReceiverItemName = receiverItem,
                Status = TradeStatus.Pending
            });

            SaveToFile();      // Save immediately after change
            Console.WriteLine("Trade request sent.");
        }

        // Displays all pending trade requests for the current user
        public void BrowseRequests(string currentUserEmail)
        {
            Console.WriteLine("\n=== Incoming Trade Requests ===");
            bool found = false;

            foreach (var t in Trades)
            {
                if (t.ReceiverEmail == currentUserEmail && t.Status == TradeStatus.Pending)
                {
                    Console.WriteLine($"From: {t.SenderEmail}");
                    Console.WriteLine($"Wants: {t.ReceiverItemName}");
                    Console.WriteLine($"Offers: {t.SenderItemName}");
                    Console.WriteLine("------------------------");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No pending trade requests.");
        }

        // Accepts a trade request from a specific sender
        public void AcceptTrade(string currentUserEmail)
        {
            Console.Write("Enter sender's email to accept: ");
            string senderEmail = Console.ReadLine() ?? "";

            foreach (var t in Trades)
            {
                if (t.ReceiverEmail == currentUserEmail && t.SenderEmail == senderEmail && t.Status == TradeStatus.Pending)
                {
                    t.Status = TradeStatus.Accepted;
                    SaveToFile();         // Save after status change
                    Console.WriteLine("Trade accepted.");
                    return;
                }
            }

            Console.WriteLine("No matching trade found.");
        }

        // Denies a trade request from a specific sender
        public void DenyTrade(string currentUserEmail)
        {
            Console.Write("Enter sender's email to deny: ");
            string senderEmail = Console.ReadLine() ?? "";

            foreach (var t in Trades)
            {
                if (t.ReceiverEmail == currentUserEmail && t.SenderEmail == senderEmail && t.Status == TradeStatus.Pending)
                {
                    t.Status = TradeStatus.Denied;
                    SaveToFile();
                    Console.WriteLine("Trade denied.");
                    return;
                }
            }

            Console.WriteLine("No matching trade found.");
        }

        // Displays all completed trades involving the current user
        public void BrowseCompleted(string currentUserEmail)
        {
            Console.WriteLine("\n=== Completed Trades ===");
            bool found = false;

            foreach (var t in Trades)
            {
                if ((t.SenderEmail == currentUserEmail || t.ReceiverEmail == currentUserEmail) &&
                    (t.Status == TradeStatus.Accepted || t.Status == TradeStatus.Denied))
                {
                    Console.WriteLine($"Sender: {t.SenderEmail}");
                    Console.WriteLine($"Receiver: {t.ReceiverEmail}");
                    Console.WriteLine($"Item Offered: {t.SenderItemName}");
                    Console.WriteLine($"Item Requested: {t.ReceiverItemName}");
                    Console.WriteLine($"Status: {t.Status}");
                    Console.WriteLine("------------------------");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No completed trades.");
        }

        // Saves all trades to trades.txt
        public void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var t in Trades)
                {
                    writer.WriteLine($"{t.SenderEmail}|{t.ReceiverEmail}|{t.SenderItemName}|{t.ReceiverItemName}|{t.Status}");
                }
            }
        }

        // Loads all trades from trades.txt
        public static Trade LoadFromFile()
        {
            Trade trade = new Trade(); // Safe now because constructor is empty

            if (!File.Exists(FilePath)) return trade;

            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 5)
                {
                    trade.Trades.Add(new TradeData
                    {
                        SenderEmail = parts[0] ?? "",
                        ReceiverEmail = parts[1] ?? "",
                        SenderItemName = parts[2] ?? "",
                        ReceiverItemName = parts[3] ?? "",
                        Status = (TradeStatus)Enum.Parse(typeof(TradeStatus), parts[4])
                    });
                }
            }

            return trade;
        }
    }
}
