using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekt_workshop.oop_workshop.Domain;
using projekt_workshop.oop_workshop.Domain.Media;
using projekt_workshop.oop_workshop.Domain.Users;
using projekt_workshop.oop_workshop.Domain.Users.DefaultNamespace;

namespace projekt_workshop.oop_workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediaCollection = new MediaCollection();
            var users = new List<User>();
    
            Console.WriteLine("Welcome to the Digital Library");
            Console.WriteLine("Choose your role:");
            Console.WriteLine("1. Borrower");
            Console.WriteLine("2. Employee");
            Console.WriteLine("3. Admin");
    
            Console.Write("Enter choice: ");
            var choice = Console.ReadLine();
    
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
                var choice = Console.ReadLine();
    
                switch (choice)
                {
                    case "1":
                        collection.ListMedia();
                        break;
    
                    case "2":
                        Console.Write("Enter title: ");
                        var previewTitle = Console.ReadLine();
                        if (collection.FindMedia(previewTitle) != null)
                        {
                            Media mediaItem = collection.FindMedia(previewTitle);
                            mediaItem?.Preview();
                        }
                        else
                        {
                            Console.WriteLine($"Media item {previewTitle} not found.");
                        }
                        
                        
                        break;
    
                    case "3":
                        Console.Write("Enter title: ");
                        var borrowTitle = Console.ReadLine();
                        var mediaToBorrow = collection.FindMedia(borrowTitle);
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
    
        static void EmployeeMenu(Employee emp, MediaCollection collection)
        {
            while (true)
            {
                Console.WriteLine("\n--- Employee Menu ---");
                Console.WriteLine("1. Add media");
                Console.WriteLine("2. Remove media");
                Console.WriteLine("3. Exit");
    
                Console.Write("Choose: ");
                var choice = Console.ReadLine();
    
                switch (choice)
                {
                    case "1":
                        var newMedia = new EBook("Sample Book", "English", "Author", 200, 2020, "123456");
                        emp.AddMedia(collection, newMedia);
                        break;
    
                    case "2":
                        Console.Write("Enter title to remove: ");
                        var removeTitle = Console.ReadLine();
                        var media = collection.FindMedia(removeTitle);
                        if (media != null)
                            emp.RemoveMedia(collection, media);
                        break;
    
                    case "3":
                        return;
    
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        
    
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
                var choice = Console.ReadLine();
    
                switch (choice)
                {
                    case "1":
                        admin.ManageUsers(users);
                        break;
                    
                    case "2":
                        /*
                        var newMedia = new Song("Sample Song", "English", "Composer", "Singer", "Pop", "mp3", 180);
                        admin.AddMedia(collection, newMedia);
                        */
                        break;
    
                    case "3":
                        /*
                        Console.Write("Enter title to remove: ");
                        var removeTitle = Console.ReadLine();
                        var media = collection.FindMedia(removeTitle);
                        if (media != null)
                            admin.RemoveMedia(collection, media);
                            */
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
    