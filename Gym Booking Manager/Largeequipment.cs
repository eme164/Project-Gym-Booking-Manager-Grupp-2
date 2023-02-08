﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Largeequipment : Equipment
    {
        private Litem item;
       

        public Largeequipment(Litem item, String name) : base(name) 
        {
            this.item = item;
            this.name = name;
            calendar = new Calendar();
        }
        public enum Litem
        {
            Bench,
            legpress,
            rowmachine,
            boxingsack
        }
    }
}
