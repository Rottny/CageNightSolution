using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CageNight.Classes
{
        public enum TESTENUM
        {
            LOL,
            ERE, 
            NO,
            yes
        }

        public enum RentTabListViewColumnIndex
        {
            VideoID,
            Film,
            Genre,
            bIsRented,
            AllowedDaysWOPenalty
        }

        public enum BookingTabListViewColumnIndex
        {
            BookingID,
            BookingName,
            CustomerName,
            VideoTitle,
            RentDate,
            ReturnedDate,
            Cost
        }

        public enum RentTabListViewColumnSorting
        {
            Name,
            Genre,
            bIsRented,
            NrOfDaysWOPenalty
        }

        public enum BookingTabListViewColumnSorting
        {
            BookingName,
            CustomerName,
            VideoTitle,
            RentDate,
            ReturnedDate,
            Cost
        }
}
