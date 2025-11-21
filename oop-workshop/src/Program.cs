using System;
using System.Collections.Generic;
using projekt_workshop.oop_workshop.Domain.Media;
using projekt_workshop.oop_workshop.Domain.Users;

namespace projekt_workshop.oop_workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            MediaCollection mediaCollection = new MediaCollection();
            List<User> users = new List<User>();

            // LOAD CSV DATA - Try multiple possible paths
            string csvPath = null;

            // Try path 1: Relative to executable (3 levels up)
            string path1 = System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                "..", "..", "..", "var", "data.csv"
            );
            path1 = System.IO.Path.GetFullPath(path1);

            // Try path 2: Relative to current directory
            string path2 = System.IO.Path.GetFullPath("var/data.csv");

            // Try path 3: Relative to executable (2 levels up - for different build configs)
            string path3 = System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),
                "..", "..", "var", "data.csv"
            );
            path3 = System.IO.Path.GetFullPath(path3);

            // Try path 4: Direct path from project root
            string path4 = "/Users/daniel/Documents/GitHub/projekt-workshop/oop-workshop/var/data.csv";

            Console.WriteLine("Trying to find CSV file...");
            Console.WriteLine($"Path 1: {path1} - Exists: {System.IO.File.Exists(path1)}");
            Console.WriteLine($"Path 2: {path2} - Exists: {System.IO.File.Exists(path2)}");
            Console.WriteLine($"Path 3: {path3} - Exists: {System.IO.File.Exists(path3)}");
            Console.WriteLine($"Path 4: {path4} - Exists: {System.IO.File.Exists(path4)}");

            if (System.IO.File.Exists(path1))
                csvPath = path1;
            else if (System.IO.File.Exists(path2))
                csvPath = path2;
            else if (System.IO.File.Exists(path3))
                csvPath = path3;
            else if (System.IO.File.Exists(path4))
                csvPath = path4;

            if (csvPath != null)
            {
                Console.WriteLine($"\nUsing CSV path: {csvPath}");
                CsvMediaLoader.LoadMedia(csvPath, mediaCollection);
            }
            else
            {
                Console.WriteLine("\nERROR: Could not find data.csv in any of the expected locations!");
                Console.WriteLine("Please check the file exists in: /Users/daniel/Documents/GitHub/projekt-workshop/oop-workshop/var/data.csv");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine("Welcome to the Digital Library");
            Console.WriteLine("Choose your role:");
            Console.WriteLine("1. Borrower");
            Console.WriteLine("2. Employee");
            Console.WriteLine("3. Admin");

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            User currentUser = null;

            switch (choice)
            {
                case "1":
                    currentUser = new Borrower("Default Borrower", 20, "000000/0000");
                    Console.WriteLine("Logged in as Borrower.");
                    BorrowerMenu((Borrower)currentUser, mediaCollection);
                    break;

                case "2":
                    currentUser = new Employee("Default Employee", 30, "111111/1111");
                    Console.WriteLine("Logged in as Employee.");
                    EmployeeMenu((Employee)currentUser, mediaCollection);
                    break;

                case "3":
                    currentUser = new Admin("Default Admin", 40, "222222/2222");
                    Console.WriteLine("Logged in as Admin.");
                    AdminMenu((Admin)currentUser, mediaCollection, users);
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        // ---------------- BORROWER MENU ----------------
        static void BorrowerMenu(Borrower borrower, MediaCollection collection)
        {
            while (true)
            {
                Console.WriteLine("\n--- Borrower Menu ---");
                Console.WriteLine("1. List all media");
                Console.WriteLine("2. Preview a media item");
                Console.WriteLine("3. Borrow a media item");
                Console.WriteLine("4. Exit");

                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        collection.ListAllMedia();
                        break;

                    case "2":
                        Console.Write("Enter title: ");
                        string previewTitle = Console.ReadLine();
                        Media mediaItem = collection.FindMedia(previewTitle);
                        if (mediaItem != null) mediaItem.Preview();
                        break;

                    case "3":
                        Console.Write("Enter title: ");
                        string borrowTitle = Console.ReadLine();
                        Media mediaToBorrow = collection.FindMedia(borrowTitle);
                        if (mediaToBorrow != null)
                            borrower.BorrowMedia(mediaToBorrow);
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // ---------------- EMPLOYEE MENU ----------------
        static void EmployeeMenu(Employee emp, MediaCollection collection)
        {
            while (true)
            {
                Console.WriteLine("\n--- Employee Menu ---");
                Console.WriteLine("1. Add media");
                Console.WriteLine("2. Remove media");
                Console.WriteLine("3. Exit");

                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Media newMedia = new EBook("Sample Book", "English", "Author", 200, 2020, "123456");
                        emp.AddMedia(collection, newMedia);
                        break;

                    case "2":
                        Console.Write("Enter title to remove: ");
                        string removeTitle = Console.ReadLine();
                        Media found = collection.FindMedia(removeTitle);
                        if (found != null)
                            emp.RemoveMedia(collection, found);
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // ---------------- ADMIN MENU ----------------
        static void AdminMenu(Admin admin, MediaCollection collection, List<User> users)
        {
            while (true)
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. Manage Users");
                Console.WriteLine("2. Add Media");
                Console.WriteLine("3. Remove Media");
                Console.WriteLine("4. Exit");

                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        admin.ManageUsers(users);
                        break;

                    case "2":
                        Media newMedia = new Song("Sample Song", "English", "Composer", "Singer", "Pop", "mp3", 180);
                        admin.AddMedia(collection, newMedia);
                        break;

                    case "3":
                        Console.Write("Enter title to remove: ");
                        string removeTitle = Console.ReadLine();
                        Media found = collection.FindMedia(removeTitle);
                        if (found != null)
                            admin.RemoveMedia(collection, found);
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
