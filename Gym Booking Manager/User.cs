﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal abstract class User 
    {
        public string id { get; set; }
        public string name { get; set; } // Here the "field" is private, but properties (access of the field) public here - this constellation being purely declarative without change in functionality
        public string phone { get; set; }
        public string email { get; set; }

        protected User(string name)
        {
            this.name = name;
            this.phone = "0";
            this.email = "test@test";
            this.id = "id";
        }
        public User(Dictionary<String, String> constructionArgs)
        {
            this.name = constructionArgs[nameof(name)];
            this.phone= constructionArgs[nameof(phone)];
            this.email= constructionArgs[nameof(email)];
            this.id = constructionArgs[nameof(id)];
        }
        public override string ToString()
        {
            return this.CSVify(); // TODO: Don't use CSVify. Make it more readable.
        }

        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        virtual public string CSVify()
        {
            return $"{nameof(name)}:{name},{nameof(id)}:{id},{nameof(email)}:{email},{nameof(phone)}:{phone}";
        }

    }
}
