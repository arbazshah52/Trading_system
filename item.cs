using System;
using System.Collections.Generic;
using System.IO;

namespace Trading_System
{
    public class Item
    {
        // Single item uploaded by a user
        public class ItemData
        {
            public string OwnerEmail { get; set; } = string.Empty;
            public string ItemName { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;

        // Default collection of data
            public ItemData() { }
        // collection of data for quick initialization
            public ItemData(string ownerEmail, string itemName, string description)
            {
                OwnerEmail = ownerEmail;
                ItemName = itemName;
                Description = description;
            }
        }
       // File path for item storage
        private const string FilePath = "items.txt";
        // uploaded item in memory
                public List<ItemData> Items = new List<ItemData>();
        // Load all items.txt when the program start
        // ensure the previously system uploaded
        public static Item LoadFromFile()
        {
            Item item = new Item();
        // file dose not exit,return an empty item list

            if (!File.Exists(FilePath)) return item;
        // Read each line and collect item data
            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    item.Items.Add(new ItemData(
                        parts[0] ?? string.Empty,
                        parts[1] ?? string.Empty,
                        parts[2] ?? string.Empty
                    ));
                }
            }

            return item;
        }
        // Saves all items to items.txt after upload
        // Ensure all items across sessions
        public void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var item in Items)
                {
                    writer.WriteLine($"{item.OwnerEmail}|{item.ItemName}|{item.Description}");
                }
            }
        }
        // Allows a user to upload a new item
       // valid input and save the item immediately
        public void UploadItem(string ownerEmail)
        {
            Console.Write("Enter item name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter item description: ");
            string? description = Console.ReadLine();
        // Basic input validation
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Item name and description cannot be empty.");
                return;
            }
        // add new item to the list and save to file
            Items.Add(new ItemData(ownerEmail, name, description));
            SaveToFile();
            Console.WriteLine("Item uploaded successfully.");
        }
        // all items uploaded by other users
        // help user for find items that want trade
        public void BrowseItems(string currentUserEmail)
        {
            Console.WriteLine("\n=== Available Items ===");
            bool found = false;

            foreach (var item in Items)
            {
        // skip items owned by the
                if (item.OwnerEmail != currentUserEmail)
                {
                    Console.WriteLine($"Owner: {item.OwnerEmail}");
                    Console.WriteLine($"Item: {item.ItemName}");
                    Console.WriteLine($"Description: {item.Description}");
                    Console.WriteLine("------------------------");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No items available from other users.");
        }
    }
}