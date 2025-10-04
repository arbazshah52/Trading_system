using System;
using System.Collections.Generic;
using System.IO;

namespace Trading_System
{
    public class User
    {
      // represent individual user data with email and password
       public class UserData
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
      // File for user Storage
        private const string FilePath = "users.txt";
      //  registered users in memory
        public List<UserData> Users = new List<UserData>();
      // Track the currently Logged in user
                public UserData? CurrentUser = null;

        // Loads all users from users.txt when the program starts
        //  ensures the system resumes with previously registered users
        public static User LoadFromFile()
        {
            User user = new User();
        // If the dose not exit /return an empty user

            if (!File.Exists(FilePath)) return user;
        // Read each line and find user data
            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    user.Users.Add(new UserData
                    {
                        Email = parts[0] ?? string.Empty,
                        Password = parts[1] ?? string.Empty
                    });
                }
            }

            return user;
        }

        //  Saves all users to users.txt after registartion
        public void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var u in Users)
                {
                    writer.WriteLine($"{u.Email}|{u.Password}");
                }
            }
        }
        // New user by collecting email and password
        // input and check duplicate registration
        public void Register()
        {
            Console.Write("Enter email: ");
            string? email = Console.ReadLine();
            Console.Write("Enter password: ");
            string? password = Console.ReadLine();
        
         // Basic input Validation
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Email and password cannot be empty.");
                return;
            }
         // check for duplicate email
            foreach (var u in Users)
            {
                if (u.Email == email)
                {
                    Console.WriteLine("Email already registered.");
                    return;
                }
            }
         // Add new user to the list
            Users.Add(new UserData { Email = email, Password = password });
            Console.WriteLine("Registration successful.");
        }
        // Log in a user by matching email and password
        // sests currents user
        public void Login()
        {
            Console.Write("Enter email: ");
            string? email = Console.ReadLine();
            Console.Write("Enter password: ");
            string? password = Console.ReadLine();

            foreach (var u in Users)
            {
                if (u.Email == email && u.Password == password)
                {
                    CurrentUser = u;
                    Console.WriteLine("Login successful.");
                    return;
                }
            }

            Console.WriteLine("Invalid credentials.");
        }
        // Logout the current user and clear
        public void Logout()
        {
            if (CurrentUser != null)
            {
                Console.WriteLine($"User {CurrentUser.Email} logged out.");
                CurrentUser = null;
            }
            else
            {
                Console.WriteLine("No user is currently logged in.");
            }
        }
    }
}