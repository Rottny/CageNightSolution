using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Classes
{
    public class VideoBooking : IItem
    {
        #region Properties
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid CustomerID { get; set; }
        public Guid VideoID { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnedDate { get; set; }

        public Double Cost { get; set; }
        #endregion

        #region Constructors
        public VideoBooking(Guid videoID, Guid customerID, DateTime rentDate, string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            VideoID = videoID;
            CustomerID = customerID;
            RentDate = rentDate;
            ReturnedDate = DateTime.MinValue;
        }

        public VideoBooking(Guid videoBookingId, Guid videoID, Guid customerID, DateTime rentDate, DateTime returnedDate, string name)
        {
            Id = videoBookingId;
            Name = name;

            VideoID = videoID;
            CustomerID = customerID;
            RentDate = rentDate;
            ReturnedDate = returnedDate;
        }
        #endregion
    }
}
