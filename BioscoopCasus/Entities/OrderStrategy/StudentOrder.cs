﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopCasus.Entities.OrderStrategy
{
    public class StudentOrder : IPriceBehaviour
    {
        public override decimal CalculatePrice(List<MovieTicket> MovieTickets)
        {
            decimal sum = 0;
            bool isEven = false;

            foreach (MovieTicket movieTicket in MovieTickets)
            {
                decimal price = movieTicket.GetPrice();
                if (isEven && !IsWeekDay(movieTicket.GetDateAndtime())) price = 0;
                else if (movieTicket.IsPremiumTicket()) price += 2;
                sum += price;
                isEven = !isEven;
            }
            return sum;
        }
    }
}
