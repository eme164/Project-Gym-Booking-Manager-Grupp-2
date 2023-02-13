﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    public static class MenuSystem
    {
        public static void Login()
        {
            LocalStorage userdata = new LocalStorage();
            string userID = "";
            string password = "";
            int count = 0;
            Console.Write("   ┌───────────────────────────────────────┐\n");
            Console.Write("   │  Gym Booking Manager (Grp2 Version)   │\n");
            Console.Write("   └───────────────────────────────────────┘\n\n");
            do
            {
                Console.WriteLine(" type 'quit' to quit");
                Console.Write(" Please enter UserID: ");
                userID = Console.ReadLine();
                if (userID == "quit".ToLower())
                {
                    Console.WriteLine("Good Bye!");
                    break;
                }
                if (userID != "")
                {

                    if (userdata.staffs.read("id", userID).Count == 0 && userdata.customer.read("id",userID).Count == 0)
                    {
                        Console.WriteLine($" {userID} was not found in the database");
                    }
                    foreach (Staff user in userdata.staffs.read("id", userID))
                    {
                        Console.WriteLine($" User {userID} selected");
                        do
                        {
                            Console.WriteLine($"try:{count}/5");
                            Console.Write($"   Please enter password for <{userID}>: ");
                            password = Console.ReadLine();
                            if (password != "")
                            {
                                if (user.password == password)
                                {
                                    Console.WriteLine($"   Welcome {user.name}!");
                                    StaffMenuMain();
                                }
                                else
                                {
                                    Console.WriteLine(" Incorrect password");
                                    count++;
                                }
                            }
                            else
                            {
                                Console.WriteLine(" Please type ur password");
                                count++;
                            }
                        }while(count != 5);
                    }
                    foreach (Customer user in userdata.customer.read("id", userID))
                    {
                        Console.WriteLine($" User {userID} selected");
                        do
                        {
                            Console.WriteLine($"try:{count}/5");
                            Console.Write($"   Please enter password for <{userID}>: ");
                            password = Console.ReadLine();
                            if (password != "")
                            {
                                if (user.password == password)
                                {
                                    Console.WriteLine($"   Welcome {user.name}!");
                                    CustomerMenu();
                                }
                                else
                                {
                                    Console.WriteLine(" Incorrect password");
                                    count++;
                                }
                            }
                            else
                            {
                                Console.WriteLine(" Please type ur password");
                                count++;
                            }
                        } while (count != 5);
                    }
                }
                else
                {
                    Console.WriteLine(" Please type ur UserID");
                }
            } while (userID != "quit");
            
        }
        //This menu will appear when a user of the type "staff" logged in: 
        public static void StaffMenuMain()
        {           
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Calendar                                           │\n");
            Console.Write("   │-- [2] Equipment                                          │\n");
            Console.Write("   │-- [3] Spaces                                             │\n");
            Console.Write("   │-- [4] Users                                              │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Logout/Exit                                        │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                      You are at --> Main Menu \n");
            Console.Write("   Please enter your selection >");          
            /* if (selection != "1,2,3,4,5,6,7,8") magic code here!}
             * 1 if (selection == 1) then StaffMenuCalendar();
             * 2 if (selection == 2) then StaffMenuEquipment();
             * 3 if (selection == 3) then StaffMenuSpaces();
             * 4 if (selection == 4) then StaffMenuUsers();
             * 5 if (selection == 5) then deploy the huge documentation PDF!
             * 6 if (selection == 6) the Logout(); NYI
             */
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   Entering Calendar.");
                    Linger();
                    StaffMenuCalendar();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   Entering Equipment.");
                    Linger();

                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   Entering Spaces.");
                    Linger();
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   Entering Users.");
                    Linger();
                    break;
                case 5:
                    StaffHelp();
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("   Logging out.");
                    Linger();
                    //Exit
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("   Invalid choice!");
                    Linger();
                    break;
            }

        }
        public static void StaffMenuCalendar()
        {

            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View All Reservations                              │\n");
            Console.Write("   │-- [2] Vacant Reservations                                │\n");
            Console.Write("   │-- [3] Make Reservation                                   │\n");
            Console.Write("   │-- [4] Delete Reservation(s)                              │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                  You are at --> Calendar Menu \n");
        }
        public static void StaffMenuEquipment()
        {
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Reserved Equipment                                 │\n");
            Console.Write("   │-- [2] Reserve Equipment                                  │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                 You are at --> Equipment Menu \n");
        }

        public static void StaffMenuSpaces()
        {
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View Booked Spaces                                 │\n");
            Console.Write("   │-- [2] Reserve Space                                      │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                        You are at --> PT Menu \n");
        }
        public static void StaffMenuUsers()
        {
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Add User                                           │\n");
            Console.Write("   │-- [2] Delete User                                        │\n");
            Console.Write("   │-- [3] Sell Membership                                    │\n");
            Console.Write("   │-- [4] Sell Daypass                                       │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                      You are at --> User Menu \n");

        }


        public static void CustomerMenu()
        {
            // if customer == member = true then type this
            Console.WriteLine($"<user>(Member) --- Main Menu");
            Console.Write("---------------------------------------------------------");
            Console.Write("-- Calendar Menu");
            // else type this
            Console.WriteLine($"<user>(Non Member Customer) --- Main Menu");
            Console.Write("---------------------------------------------------------");
        }

        //Use  this for later...
        public static void AdminMenuMain()
        {
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Calendar                                           │\n");
            Console.Write("   │-- [2] Equipment                                          │\n");
            Console.Write("   │-- [3] PT                                                 │\n");
            Console.Write("   │-- [4] Schedules                                          │\n");
            Console.Write("   │-- [5] Spaces                                             │\n");
            Console.Write("   │-- [6] User                                               │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [7] Help                                               │\n");
            Console.Write("   │-- [8] Logout/Exit                                        │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                     You are at --> Main Menu  \n");
            //AdminMenuUser();
        }
        public static void AdminMenuCalendar()
        {

            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] View All Reservations                              │\n");
            Console.Write("   │-- [2] Vacant Reservations                                │\n");
            Console.Write("   │-- [3] Make Reservation                                   │\n");
            Console.Write("   │-- [4] Delete Reservation                                 │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                  You are at --> Calendar Menu \n");
        }
        public static void AdminMenuUser()
        {
            Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
            Console.Write("   │-- [1] Add User                                           │\n");
            Console.Write("   │-- [2] Delete User                                        │\n");
            Console.Write("   │-- [3] Sell Membership                                    │\n");
            Console.Write("   │-- [4] Sell Daypass                                       │\n");
            Console.Write("   │                                                          │\n");
            Console.Write("   │-- [5] Help                                               │\n");
            Console.Write("   │-- [6] Main Menu                                          │\n");
            Console.Write("   └──────────────────────────────────────────────────────────┘\n");
            Console.Write("                                     You are at --> Users Menu \n");
        }
        public static void Linger()
        {
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.ResetColor();
        }

        public static void StaffHelp() 
        {
            Console.WriteLine("   Sorry, no help here!");
        }
        public static void CostumerHelp()
        {
            Console.WriteLine("   You want help? FORGET IT! The customer is never right!");
        }

    }

    /*
    Use any of this:?

                Console.Write("   ┌──────────────────────────────────────────────────────────┐\n");
                Console.Write("   │ User: <username>              Logged in <DD/MM HH:MM:SS> │\n");
                Console.Write("   └──────────────────────────────────────────────────────────┘\n");

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    namespace Gym_Booking_Manager
    {
        public class MenuSystem
        {
            private const string UsersFilePath = "Users.csv";
            public static void MainMenu()
            {
                Console.WriteLine(" *** Gym Booking Manager ***");
                Console.WriteLine("Welcome, you need to login, please enter your userID: ");
                string userID = Console.ReadLine();
                // Check if user exists in the database
                User user = GetUser(userID);
                if (user == null)
                {
                    Console.WriteLine("User does not exist, would you like to create a new user?");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "yes")
                    {
                        Console.WriteLine("Enter name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter phone number:");
                        string phone = Console.ReadLine();
                        Console.WriteLine("Enter email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter account type (Customer/Staff):");
                        string accountType = Console.ReadLine();
                        // Create new user and add it to the database
                        User newUser = new User()
                        {
                            id = userID,
                            name = name,
                            phone = phone,
                            email = email,
                            accountType = accountType
                        };
                        AddUser(newUser);
                    }
                    else
                    {
                        Console.WriteLine("User creation cancelled.");
                        return;
                    }
                }
                // User exists or has been created, continue with the program
                Console.WriteLine($"Welcome, {user.name}");
                Console.WriteLine("Type of account: " + user.accountType);
                // Program logic for displaying the main menu
                Console.WriteLine("Main menu options:");
                Console.WriteLine("1. View Log [Admin]");
                Console.WriteLine("2. View Group Schedule [Admin, Staff]");
                Console.WriteLine("3. Make reservation");
                Console.WriteLine("4. Cancel reservation");
                Console.WriteLine("5. Daypass");
                Console.WriteLine("6. Membership");
                Console.WriteLine("7. Add User");
                Console.WriteLine("8. Delete User");
            }
            private static User GetUser(string userID)
            {
                if (!File.Exists(UsersFilePath))
                {
                    return null;
                }
                string[] lines = File.ReadAllLines(UsersFilePath);
                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');
                    if (fields[0] == userID)
                    {
                        User user = new User()
                        {
                            id = fields[0],
                            name = fields[1],
                            phone = fields[2],
                            email = fields[3],
                            accountType = fields[4]
                        };
                        return user;
                    }
                }
                return null
    }
    */
}